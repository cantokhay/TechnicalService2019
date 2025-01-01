
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
            this.webYoutube = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webYoutube)).BeginInit();
            this.SuspendLayout();
            // 
            // webYoutube
            // 
            this.webYoutube.AllowExternalDrop = true;
            this.webYoutube.CreationProperties = null;
            this.webYoutube.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webYoutube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webYoutube.Location = new System.Drawing.Point(0, 0);
            this.webYoutube.Name = "webYoutube";
            this.webYoutube.Size = new System.Drawing.Size(1370, 541);
            this.webYoutube.TabIndex = 1;
            this.webYoutube.ZoomFactor = 1D;
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
            ((System.ComponentModel.ISupportInitialize)(this.webYoutube)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webYoutube;
    }
}