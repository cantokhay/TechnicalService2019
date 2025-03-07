
namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    partial class FrmInvoiceDetailPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoiceDetailPopUp));
            this.grcInvoiceDetailList = new DevExpress.XtraGrid.GridControl();
            this.gvwInvoiceDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcInvoiceList = new DevExpress.XtraGrid.GridControl();
            this.gvwInvoices = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.picPdfButton = new DevExpress.XtraEditors.PictureEdit();
            this.picXlsButton = new DevExpress.XtraEditors.PictureEdit();
            this.picClose = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceDetailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPdfButton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXlsButton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcInvoiceDetailList
            // 
            this.grcInvoiceDetailList.Location = new System.Drawing.Point(1, 133);
            this.grcInvoiceDetailList.MainView = this.gvwInvoiceDetails;
            this.grcInvoiceDetailList.Name = "grcInvoiceDetailList";
            this.grcInvoiceDetailList.Size = new System.Drawing.Size(853, 408);
            this.grcInvoiceDetailList.TabIndex = 1;
            this.grcInvoiceDetailList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwInvoiceDetails});
            // 
            // gvwInvoiceDetails
            // 
            this.gvwInvoiceDetails.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.gvwInvoiceDetails.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.gvwInvoiceDetails.Appearance.Row.Options.UseBackColor = true;
            this.gvwInvoiceDetails.Appearance.Row.Options.UseBorderColor = true;
            this.gvwInvoiceDetails.GridControl = this.grcInvoiceDetailList;
            this.gvwInvoiceDetails.Name = "gvwInvoiceDetails";
            this.gvwInvoiceDetails.OptionsView.ShowGroupPanel = false;
            // 
            // grcInvoiceList
            // 
            this.grcInvoiceList.Location = new System.Drawing.Point(1, 2);
            this.grcInvoiceList.MainView = this.gvwInvoices;
            this.grcInvoiceList.Name = "grcInvoiceList";
            this.grcInvoiceList.Size = new System.Drawing.Size(853, 74);
            this.grcInvoiceList.TabIndex = 19;
            this.grcInvoiceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwInvoices});
            // 
            // gvwInvoices
            // 
            this.gvwInvoices.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.gvwInvoices.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.gvwInvoices.Appearance.Row.Options.UseBackColor = true;
            this.gvwInvoices.Appearance.Row.Options.UseBorderColor = true;
            this.gvwInvoices.GridControl = this.grcInvoiceList;
            this.gvwInvoices.Name = "gvwInvoices";
            this.gvwInvoices.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 94);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(268, 21);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Invoice Detail of the Invoice Above : ";
            // 
            // picPdfButton
            // 
            this.picPdfButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPdfButton.EditValue = ((object)(resources.GetObject("picPdfButton.EditValue")));
            this.picPdfButton.Location = new System.Drawing.Point(548, 77);
            this.picPdfButton.Name = "picPdfButton";
            this.picPdfButton.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picPdfButton.Properties.Appearance.Options.UseBackColor = true;
            this.picPdfButton.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picPdfButton.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picPdfButton.Size = new System.Drawing.Size(96, 55);
            this.picPdfButton.TabIndex = 21;
            this.picPdfButton.Click += new System.EventHandler(this.picPdfButton_Click);
            // 
            // picXlsButton
            // 
            this.picXlsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picXlsButton.EditValue = ((object)(resources.GetObject("picXlsButton.EditValue")));
            this.picXlsButton.Location = new System.Drawing.Point(649, 77);
            this.picXlsButton.Name = "picXlsButton";
            this.picXlsButton.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picXlsButton.Properties.Appearance.Options.UseBackColor = true;
            this.picXlsButton.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picXlsButton.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picXlsButton.Size = new System.Drawing.Size(96, 55);
            this.picXlsButton.TabIndex = 21;
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.EditValue = ((object)(resources.GetObject("picClose.EditValue")));
            this.picClose.Location = new System.Drawing.Point(750, 77);
            this.picClose.Name = "picClose";
            this.picClose.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Properties.Appearance.Options.UseBackColor = true;
            this.picClose.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picClose.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picClose.Size = new System.Drawing.Size(96, 55);
            this.picClose.TabIndex = 21;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // FrmInvoiceDetailPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(855, 543);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picXlsButton);
            this.Controls.Add(this.picPdfButton);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grcInvoiceList);
            this.Controls.Add(this.grcInvoiceDetailList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInvoiceDetailPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Detail";
            this.Load += new System.EventHandler(this.FrmInvoiceDetailPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceDetailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPdfButton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXlsButton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcInvoiceDetailList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwInvoiceDetails;
        private DevExpress.XtraGrid.GridControl grcInvoiceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwInvoices;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit picPdfButton;
        private DevExpress.XtraEditors.PictureEdit picXlsButton;
        private DevExpress.XtraEditors.PictureEdit picClose;
    }
}