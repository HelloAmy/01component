namespace AmyBookProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelMainCenter = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PanelMainCenter
            // 
            this.PanelMainCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMainCenter.Location = new System.Drawing.Point(0, 0);
            this.PanelMainCenter.Name = "PanelMainCenter";
            this.PanelMainCenter.Size = new System.Drawing.Size(1048, 594);
            this.PanelMainCenter.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 594);
            this.Controls.Add(this.PanelMainCenter);
            this.Name = "MainForm";
            this.Text = "主窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMainCenter;
    }
}