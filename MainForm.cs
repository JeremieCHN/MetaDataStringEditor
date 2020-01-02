using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetaDataStringEditor {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

            Logger.LogAction += delegate (string msg) {
                if (InvokeRequired) {
                    Invoke(new Action(delegate { toolStripStatusLabel1.Text = msg; }));
                } else {
                    toolStripStatusLabel1.Text = msg;
                }
            };

            ProgressBar.SetMaxAction += delegate (int max) {
                if (InvokeRequired) {
                    Invoke(new Action(delegate {
                        toolStripProgressBar1.Maximum = max;
                        toolStripProgressBar1.Value = 0;
                    }));
                } else {
                    toolStripProgressBar1.Maximum = max;
                    toolStripProgressBar1.Value = 0;
                }
            };

            ProgressBar.PlusOneAction += delegate {
                if (InvokeRequired) {
                    Invoke(new Action(delegate { toolStripProgressBar1.Value++; }));
                } else {
                    toolStripProgressBar1.Value++;
                }
            };

            ProgressBar.ReportAction += delegate (int val) {
                if (InvokeRequired) {
                    Invoke(new Action(delegate { toolStripProgressBar1.Value = val; }));
                } else {
                    toolStripProgressBar1.Value = val;
                }
            };
        }

        private FormStatus status = FormStatus.Waiting;
        private MetadataFile file;
        private EditForm editForm = new EditForm();

        // 菜单栏
        private void 加载ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (status == FormStatus.Loading || status == FormStatus.Saving) {
                Logger.E("后台操作进行中");
                return;
            }

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK) {
                status = FormStatus.Loading;
                ClearForm();
                ThreadPool.QueueUserWorkItem(delegate {
                    try {
                        file = new MetadataFile(openFileDialog1.FileName);
                        Invoke(new Action(delegate { Text = openFileDialog1.FileName; }));
                        Invoke(new Action(RefreshListView));
                        status = FormStatus.Editing;
                        Logger.I("加载完成");
                    } catch (Exception ex) {
                        Logger.E(ex.ToString());
                        file?.Dispose();
                        file = null;
                        status = FormStatus.Waiting;
                    }
                });
            }
        }

        private void RefreshListView() {
            Logger.I("刷新列表");

            listView1.BeginUpdate();
            for (int i = 0; i < file.strBytes.Count; i++) {
                EditorListItem item = new EditorListItem(file.strBytes[i]) {
                    Tag = i
                };
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (status != FormStatus.Editing) {
                Logger.E("状态错误");
                return;
            }

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK) {
                status = FormStatus.Saving;
                
                ThreadPool.QueueUserWorkItem(delegate {
                    file.WriteToNewFile(saveFileDialog1.FileName);
                    status = FormStatus.Editing;
                });
            }
        }

        private void 关闭文件ToolStripMenuItem_Click(object sender, EventArgs e) {
            ClearForm();
            status = FormStatus.Waiting;
        }
        
        // 搜索
        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text.Length > 0)
                SearchToNext();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\r' && textBox1.Text.Length > 0)
                SearchToNext();
        }

        private void SearchToNext() {
            string keyWord = textBox1.Text;
            int start = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[0] : -1;
            for (int i = 0; i < listView1.Items.Count; i++) {
                var item = listView1.Items[(i + start + 1) % listView1.Items.Count] as EditorListItem;
                if (item.MatchKeyWord(keyWord)) {
                    item.Selected = true;
                    item.EnsureVisible();
                    return;
                }

            }
            Logger.I("找不到搜索字符串");
        }

        // 修改

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            var item = listView1.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                item.Selected = true;
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            var item = listView1.SelectedItems[0] as EditorListItem;
            startEditor(item);
        }


        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = listView1.SelectedItems[0] as EditorListItem;
            startEditor(item);
        }

        private void startEditor(EditorListItem item)
        {
            editForm.ShowDialog(this, item);
            if (item.IsEdit)
                file.strBytes[(int)item.Tag] = item.NewStrBytes;
            else
                file.strBytes[(int)item.Tag] = item.OriginStrBytes;
        }

        // 通用
        private void ClearForm() {
            listView1.Items.Clear();
            file?.Dispose();
            file = null;
            Text = "MetadataStringEditor";
        }

        private enum FormStatus { Waiting, Loading, Saving, Editing }

    }

    public static class Logger {
        public static Action<string> LogAction;

        private static void Log(string level, string msg) {
            LogAction($"[{level}] {msg}");
        }

        public static void D(string msg) { Log("debug", msg); }
        public static void I(string msg) { Log("info", msg); }
        public static void E(string msg) { Log("error", msg); }
    }

    public static class ProgressBar {
        public static Action<int> SetMaxAction;
        public static Action PlusOneAction;
        public static Action<int> ReportAction;

        public static void SetMax(int max) => SetMaxAction(max);
        public static void Report(int val) => ReportAction(val);
        public static void Report() => PlusOneAction();
    }

}
