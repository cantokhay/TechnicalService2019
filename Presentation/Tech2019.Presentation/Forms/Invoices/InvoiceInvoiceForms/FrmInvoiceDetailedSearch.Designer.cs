
namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    partial class FrmInvoiceDetailedSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoiceDetailedSearch));
            this.grcInvoiceDetailList = new DevExpress.XtraGrid.GridControl();
            this.gvwInvoiceDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceId = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lueInvoiceSerial = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceSequence = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceDetailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceSequence.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcInvoiceDetailList
            // 
            this.grcInvoiceDetailList.Location = new System.Drawing.Point(1, 60);
            this.grcInvoiceDetailList.MainView = this.gvwInvoiceDetails;
            this.grcInvoiceDetailList.Name = "grcInvoiceDetailList";
            this.grcInvoiceDetailList.Size = new System.Drawing.Size(1368, 481);
            this.grcInvoiceDetailList.TabIndex = 0;
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
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "INVOICE ID : ";
            // 
            // txtInvoiceId
            // 
            this.txtInvoiceId.Location = new System.Drawing.Point(108, 17);
            this.txtInvoiceId.Name = "txtInvoiceId";
            this.txtInvoiceId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtInvoiceId.Properties.Appearance.Options.UseFont = true;
            this.txtInvoiceId.Size = new System.Drawing.Size(100, 24);
            this.txtInvoiceId.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.Location = new System.Drawing.Point(794, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lueInvoiceSerial
            // 
            this.lueInvoiceSerial.Location = new System.Drawing.Point(378, 17);
            this.lueInvoiceSerial.Name = "lueInvoiceSerial";
            this.lueInvoiceSerial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lueInvoiceSerial.Properties.Appearance.Options.UseFont = true;
            this.lueInvoiceSerial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueInvoiceSerial.Size = new System.Drawing.Size(100, 24);
            this.lueInvoiceSerial.TabIndex = 2;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(498, 21);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(145, 18);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "SEQUENCE NUMBER :";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(228, 20);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(144, 18);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "SERIAL CHARACTER :";
            // 
            // txtInvoiceSequence
            // 
            this.txtInvoiceSequence.Location = new System.Drawing.Point(650, 17);
            this.txtInvoiceSequence.Name = "txtInvoiceSequence";
            this.txtInvoiceSequence.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtInvoiceSequence.Properties.Appearance.Options.UseFont = true;
            this.txtInvoiceSequence.Properties.Mask.EditMask = "\\d?\\d?\\d?\\d?\\d?\\d?";
            this.txtInvoiceSequence.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtInvoiceSequence.Size = new System.Drawing.Size(100, 24);
            this.txtInvoiceSequence.TabIndex = 3;
            // 
            // FrmInvoiceDetailedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.lueInvoiceSerial);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtInvoiceSequence);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtInvoiceId);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grcInvoiceDetailList);
            this.Name = "FrmInvoiceDetailedSearch";
            this.Text = "Invoice Detail Search";
            this.Load += new System.EventHandler(this.FrmInvoiceDetailedSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceDetailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceSequence.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcInvoiceDetailList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwInvoiceDetails;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtInvoiceId;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LookUpEdit lueInvoiceSerial;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtInvoiceSequence;
    }
}