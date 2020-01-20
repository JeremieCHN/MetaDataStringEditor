namespace MetaDataStringEditor {
    partial class EditForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.Discard = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 203);
            this.textBox1.TabIndex = 0;
            // 
            // 保存
            // 
            this.Save.Location = new System.Drawing.Point(270, 230);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // 放弃此次修改
            // 
            this.Discard.Location = new System.Drawing.Point(173, 230);
            this.Discard.Name = "Discard";
            this.Discard.Size = new System.Drawing.Size(91, 23);
            this.Discard.TabIndex = 2;
            this.Discard.Text = "Discard";
            this.Discard.UseVisualStyleBackColor = true;
            this.Discard.Click += new System.EventHandler(this.Discard_Click);
            // 
            // 还原该串的修改
            // 
            this.Undo.Location = new System.Drawing.Point(62, 230);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(105, 23);
            this.Undo.TabIndex = 3;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 265);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.Discard);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Discard;
        private System.Windows.Forms.Button Undo;
    }
}