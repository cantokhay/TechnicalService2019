
namespace Tech2019.Presentation.Forms.Tools
{
    partial class FrmCurrency
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
            this.webCurrency = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webCurrency
            // 
            this.webCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webCurrency.Location = new System.Drawing.Point(0, 0);
            this.webCurrency.MinimumSize = new System.Drawing.Size(20, 20);
            this.webCurrency.Name = "webCurrency";
            this.webCurrency.Size = new System.Drawing.Size(1370, 541);
            this.webCurrency.TabIndex = 0;
            // 
            // FrmCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.webCurrency);
            this.Name = "FrmCurrency";
            this.Text = "TCMB Curreny Rates";
            this.Load += new System.EventHandler(this.FrmCurrency_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.WebBrowser webCurrency;

        #endregion

    }
}