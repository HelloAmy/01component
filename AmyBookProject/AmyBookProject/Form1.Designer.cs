namespace AmyBookProject
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_BookName = new System.Windows.Forms.TextBox();
            this.TXT_BookAuthor = new System.Windows.Forms.TextBox();
            this.BTN_AddBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "书名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "作者:";
            // 
            // TXT_BookName
            // 
            this.TXT_BookName.Location = new System.Drawing.Point(145, 75);
            this.TXT_BookName.Name = "TXT_BookName";
            this.TXT_BookName.Size = new System.Drawing.Size(100, 21);
            this.TXT_BookName.TabIndex = 2;
            // 
            // TXT_BookAuthor
            // 
            this.TXT_BookAuthor.Location = new System.Drawing.Point(145, 117);
            this.TXT_BookAuthor.Name = "TXT_BookAuthor";
            this.TXT_BookAuthor.Size = new System.Drawing.Size(100, 21);
            this.TXT_BookAuthor.TabIndex = 3;
            // 
            // BTN_AddBook
            // 
            this.BTN_AddBook.Location = new System.Drawing.Point(136, 178);
            this.BTN_AddBook.Name = "BTN_AddBook";
            this.BTN_AddBook.Size = new System.Drawing.Size(75, 23);
            this.BTN_AddBook.TabIndex = 4;
            this.BTN_AddBook.Text = "添加";
            this.BTN_AddBook.UseVisualStyleBackColor = true;
            this.BTN_AddBook.Click += new System.EventHandler(this.BTN_AddBook_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 466);
            this.Controls.Add(this.BTN_AddBook);
            this.Controls.Add(this.TXT_BookAuthor);
            this.Controls.Add(this.TXT_BookName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXT_BookName;
        private System.Windows.Forms.TextBox TXT_BookAuthor;
        private System.Windows.Forms.Button BTN_AddBook;
    }
}

