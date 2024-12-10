
namespace Tech2019.Presentation.Forms.Tools
{
    partial class FrmYoutube
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
            this.webYoutube = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webYoutube
            // 
            this.webYoutube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webYoutube.Location = new System.Drawing.Point(0, 0);
            this.webYoutube.MinimumSize = new System.Drawing.Size(20, 20);
            this.webYoutube.Name = "webYoutube";
            this.webYoutube.Size = new System.Drawing.Size(1370, 541);
            this.webYoutube.TabIndex = 0;
            // 
            // FrmYoutube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.webYoutube);
            this.Name = "FrmYoutube";
            this.Text = "Youtube";
            this.Load += new System.EventHandler(this.FrmYoutube_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.WebBrowser webYoutube;

        #endregion

    }
}