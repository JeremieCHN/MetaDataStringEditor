using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetaDataStringEditor {

    public class EditorListItem : ListViewItem {

        public bool IsEdit { private set; get; }
        public byte[] OriginStrBytes { private set; get; }
        public byte[] NewStrBytes { private set; get; }

        public EditorListItem(byte[] OriginStrBytes) {
            this.OriginStrBytes = OriginStrBytes;
            IsEdit = false;

            Text = Encoding.UTF8.GetString(OriginStrBytes);
            SubItems.Add("");
            SubItems.Add("");
        }

        public void SetNewStr(string newString) {
            NewStrBytes = Encoding.UTF8.GetBytes(newString);
            IsEdit = !Equals(OriginStrBytes, NewStrBytes);

            SubItems[1].Text = IsEdit ? newString : "";
            SubItems[2].Text = IsEdit ? "*" : "";
        }

        public void Discard() {
            NewStrBytes = null;
            IsEdit = false;

            SubItems[1].Text = "";
            SubItems[2].Text = "";
        }

        public bool MatchKeyWord(string keyWord) {
            return Text.ToLower().Contains(keyWord.ToLower()) ||
                SubItems[0].Text.ToLower().Contains(keyWord.ToLower()) ||
                SubItems[1].Text.ToLower().Contains(keyWord.ToLower());
        }
    }
}
