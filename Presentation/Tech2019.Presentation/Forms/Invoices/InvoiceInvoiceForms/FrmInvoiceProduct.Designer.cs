
namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    partial class FrmInvoiceProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoiceProduct));
            this.gvwInvoiceDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcInvoiceDetailList = new DevExpress.XtraGrid.GridControl();
            this.txtInvoiceDetailProductName = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceDetailTotal = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceDetailPrice = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceDetailQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceDetailId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lueInvoices = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceDetailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoices.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.gvwInvoiceDetails.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwInvoiceDetails_FocusedRowChanged);
            // 
            // grcInvoiceDetailList
            // 
            this.grcInvoiceDetailList.Location = new System.Drawing.Point(1, 2);
            this.grcInvoiceDetailList.MainView = this.gvwInvoiceDetails;
            this.grcInvoiceDetailList.Name = "grcInvoiceDetailList";
            this.grcInvoiceDetailList.Size = new System.Drawing.Size(1018, 539);
            this.grcInvoiceDetailList.TabIndex = 0;
            this.grcInvoiceDetailList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwInvoiceDetails});
            // 
            // txtInvoiceDetailProductName
            // 
            this.txtInvoiceDetailProductName.Location = new System.Drawing.Point(133, 248);
            this.txtInvoiceDetailProductName.Name = "txtInvoiceDetailProductName";
            this.txtInvoiceDetailProductName.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceDetailProductName.TabIndex = 5;
            // 
            // txtInvoiceDetailTotal
            // 
            this.txtInvoiceDetailTotal.Location = new System.Drawing.Point(133, 218);
            this.txtInvoiceDetailTotal.Name = "txtInvoiceDetailTotal";
            this.txtInvoiceDetailTotal.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceDetailTotal.TabIndex = 4;
            // 
            // txtInvoiceDetailPrice
            // 
            this.txtInvoiceDetailPrice.Location = new System.Drawing.Point(133, 188);
            this.txtInvoiceDetailPrice.Name = "txtInvoiceDetailPrice";
            this.txtInvoiceDetailPrice.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceDetailPrice.TabIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.lueInvoices);
            this.groupControl1.Controls.Add(this.txtInvoiceDetailProductName);
            this.groupControl1.Controls.Add(this.txtInvoiceDetailTotal);
            this.groupControl1.Controls.Add(this.txtInvoiceDetailPrice);
            this.groupControl1.Controls.Add(this.btnRefresh);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.txtInvoiceDetailQuantity);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.txtInvoiceDetailId);
            this.groupControl1.Location = new System.Drawing.Point(1025, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(340, 536);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "INVOICE DETAIL OPERATIONS";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(34, 489);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(293, 39);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "REFRESH LIST";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(34, 444);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(293, 39);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(34, 399);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(292, 39);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(34, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(293, 39);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(44, 251);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "PRODUCT NAME :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(91, 221);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "TOTAL :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(93, 191);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "PRICE :";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(72, 161);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(58, 13);
            this.labelControl12.TabIndex = 33;
            this.labelControl12.Text = "QUANTITY :";
            // 
            // txtInvoiceDetailQuantity
            // 
            this.txtInvoiceDetailQuantity.Location = new System.Drawing.Point(133, 158);
            this.txtInvoiceDetailQuantity.Name = "txtInvoiceDetailQuantity";
            this.txtInvoiceDetailQuantity.Properties.Mask.EditMask = "\\d?\\d?\\d?\\d?\\d?\\d?";
            this.txtInvoiceDetailQuantity.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceDetailQuantity.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Enabled = false;
            this.labelControl7.Location = new System.Drawing.Point(71, 131);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(59, 13);
            this.labelControl7.TabIndex = 33;
            this.labelControl7.Text = "DETAIL ID : ";
            // 
            // txtInvoiceDetailId
            // 
            this.txtInvoiceDetailId.Enabled = false;
            this.txtInvoiceDetailId.Location = new System.Drawing.Point(133, 128);
            this.txtInvoiceDetailId.Name = "txtInvoiceDetailId";
            this.txtInvoiceDetailId.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceDetailId.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(81, 281);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 33;
            this.labelControl4.Text = "INVOICE :";
            // 
            // lueInvoices
            // 
            this.lueInvoices.Location = new System.Drawing.Point(133, 278);
            this.lueInvoices.Name = "lueInvoices";
            this.lueInvoices.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueInvoices.Size = new System.Drawing.Size(190, 20);
            this.lueInvoices.TabIndex = 6;
            // 
            // FrmInvoiceProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.grcInvoiceDetailList);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmInvoiceProduct";
            this.Text = "Add Products To Invoice";
            this.Load += new System.EventHandler(this.FrmInvoiceProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceDetailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDetailId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoices.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gvwInvoiceDetails;
        private DevExpress.XtraGrid.GridControl grcInvoiceDetailList;
        private DevExpress.XtraEditors.TextEdit txtInvoiceDetailProductName;
        private DevExpress.XtraEditors.TextEdit txtInvoiceDetailTotal;
        private DevExpress.XtraEditors.TextEdit txtInvoiceDetailPrice;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtInvoiceDetailQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtInvoiceDetailId;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lueInvoices;
    }
}