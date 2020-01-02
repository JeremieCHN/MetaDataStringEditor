using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetaDataStringEditor {
    public partial class EditForm : Form {
        public EditForm() {
            InitializeComponent();
        }

        private EditorListItem item;

        public void ShowDialog(IWin32Window Owner, EditorListItem item) {
            this.item = item;
            if (item.NewStrBytes != null) {
                textBox1.Text = Encoding.UTF8.GetString(item.NewStrBytes);
            } else {
                textBox1.Text = Encoding.UTF8.GetString(item.OriginStrBytes);
            }
            ShowDialog(Owner);
        }

        private void 保存_Click(object sender, EventArgs e) {
            Owner.Invoke(new Action(delegate {
                item.SetNewStr(textBox1.Text.Replace("\r", ""));
            }));
            Close();
        }

        private void 放弃此次修改_Click(object sender, EventArgs e) {
            Close();
        }

        private void 还原该串的修改_Click(object sender, EventArgs e) {
            Owner.Invoke(new Action(delegate {
                item.Discard();
            }));
            Close();
        }
    }
}
