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
            this.保存 = new System.Windows.Forms.Button();
            this.放弃此次修改 = new System.Windows.Forms.Button();
            this.还原该串的修改 = new System.Windows.Forms.Button();
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
            this.保存.Location = new System.Drawing.Point(270, 230);
            this.保存.Name = "保存";
            this.保存.Size = new System.Drawing.Size(75, 23);
            this.保存.TabIndex = 1;
            this.保存.Text = "保存";
            this.保存.UseVisualStyleBackColor = true;
            this.保存.Click += new System.EventHandler(this.保存_Click);
            // 
            // 放弃此次修改
            // 
            this.放弃此次修改.Location = new System.Drawing.Point(173, 230);
            this.放弃此次修改.Name = "放弃此次修改";
            this.放弃此次修改.Size = new System.Drawing.Size(91, 23);
            this.放弃此次修改.TabIndex = 2;
            this.放弃此次修改.Text = "放弃此次修改";
            this.放弃此次修改.UseVisualStyleBackColor = true;
            this.放弃此次修改.Click += new System.EventHandler(this.放弃此次修改_Click);
            // 
            // 还原该串的修改
            // 
            this.还原该串的修改.Location = new System.Drawing.Point(62, 230);
            this.还原该串的修改.Name = "还原该串的修改";
            this.还原该串的修改.Size = new System.Drawing.Size(105, 23);
            this.还原该串的修改.TabIndex = 3;
            this.还原该串的修改.Text = "还原该串的修改";
            this.还原该串的修改.UseVisualStyleBackColor = true;
            this.还原该串的修改.Click += new System.EventHandler(this.还原该串的修改_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 265);
            this.Controls.Add(this.还原该串的修改);
            this.Controls.Add(this.放弃此次修改);
            this.Controls.Add(this.保存);
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
        private System.Windows.Forms.Button 保存;
        private System.Windows.Forms.Button 放弃此次修改;
        private System.Windows.Forms.Button 还原该串的修改;
    }
}