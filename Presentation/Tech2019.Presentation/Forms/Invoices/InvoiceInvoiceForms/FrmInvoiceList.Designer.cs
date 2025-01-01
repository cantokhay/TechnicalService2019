
namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    partial class FrmInvoiceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoiceList));
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceSequence = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceId = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtInvoiceTaxOffice = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceHour = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceDate = new DevExpress.XtraEditors.TextEdit();
            this.lueInvoiceEmployee = new DevExpress.XtraEditors.LookUpEdit();
            this.lueInvoiceCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.lueInvoiceSerial = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.grcInvoiceList = new DevExpress.XtraGrid.GridControl();
            this.gvwInvoices = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceSequence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTaxOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(34, 489);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(293, 39);
            this.btnRefresh.TabIndex = 13;
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
            this.btnUpdate.TabIndex = 12;
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
            this.btnDelete.TabIndex = 10;
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
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(28, 137);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(104, 13);
            this.labelControl12.TabIndex = 33;
            this.labelControl12.Text = "SEQUENCE NUMBER :";
            // 
            // txtInvoiceSequence
            // 
            this.txtInvoiceSequence.Location = new System.Drawing.Point(135, 134);
            this.txtInvoiceSequence.Name = "txtInvoiceSequence";
            this.txtInvoiceSequence.Properties.Mask.EditMask = "\\d?\\d?\\d?\\d?\\d?\\d?";
            this.txtInvoiceSequence.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtInvoiceSequence.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceSequence.TabIndex = 3;
            // 
            // txtInvoiceId
            // 
            this.txtInvoiceId.Enabled = false;
            this.txtInvoiceId.Location = new System.Drawing.Point(135, 74);
            this.txtInvoiceId.Name = "txtInvoiceId";
            this.txtInvoiceId.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceId.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.txtInvoiceTaxOffice);
            this.groupControl1.Controls.Add(this.txtInvoiceHour);
            this.groupControl1.Controls.Add(this.txtInvoiceDate);
            this.groupControl1.Controls.Add(this.lueInvoiceEmployee);
            this.groupControl1.Controls.Add(this.lueInvoiceCustomer);
            this.groupControl1.Controls.Add(this.lueInvoiceSerial);
            this.groupControl1.Controls.Add(this.btnRefresh);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.txtInvoiceSequence);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.txtInvoiceId);
            this.groupControl1.Location = new System.Drawing.Point(1025, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(340, 536);
            this.groupControl1.TabIndex = 19;
            this.groupControl1.Text = "INVOICE OPERATIONS";
            // 
            // txtInvoiceTaxOffice
            // 
            this.txtInvoiceTaxOffice.Location = new System.Drawing.Point(135, 224);
            this.txtInvoiceTaxOffice.Name = "txtInvoiceTaxOffice";
            this.txtInvoiceTaxOffice.Properties.Mask.EditMask = "t";
            this.txtInvoiceTaxOffice.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceTaxOffice.TabIndex = 6;
            // 
            // txtInvoiceHour
            // 
            this.txtInvoiceHour.Location = new System.Drawing.Point(135, 194);
            this.txtInvoiceHour.Name = "txtInvoiceHour";
            this.txtInvoiceHour.Properties.Mask.EditMask = "t";
            this.txtInvoiceHour.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceHour.TabIndex = 5;
            this.txtInvoiceHour.EnabledChanged += new System.EventHandler(this.txtInvoiceHour_LostFocus);
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.Location = new System.Drawing.Point(135, 164);
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Properties.Mask.EditMask = "d";
            this.txtInvoiceDate.Size = new System.Drawing.Size(190, 20);
            this.txtInvoiceDate.TabIndex = 4;
            this.txtInvoiceDate.EnabledChanged += new System.EventHandler(this.txtInvoiceDate_LostFocus);
            // 
            // lueInvoiceEmployee
            // 
            this.lueInvoiceEmployee.Location = new System.Drawing.Point(135, 284);
            this.lueInvoiceEmployee.Name = "lueInvoiceEmployee";
            this.lueInvoiceEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueInvoiceEmployee.Size = new System.Drawing.Size(190, 20);
            this.lueInvoiceEmployee.TabIndex = 8;
            // 
            // lueInvoiceCustomer
            // 
            this.lueInvoiceCustomer.Location = new System.Drawing.Point(135, 254);
            this.lueInvoiceCustomer.Name = "lueInvoiceCustomer";
            this.lueInvoiceCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueInvoiceCustomer.Size = new System.Drawing.Size(190, 20);
            this.lueInvoiceCustomer.TabIndex = 7;
            // 
            // lueInvoiceSerial
            // 
            this.lueInvoiceSerial.Location = new System.Drawing.Point(135, 104);
            this.lueInvoiceSerial.Name = "lueInvoiceSerial";
            this.lueInvoiceSerial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueInvoiceSerial.Size = new System.Drawing.Size(190, 20);
            this.lueInvoiceSerial.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(74, 287);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 33;
            this.labelControl5.Text = "EMPLOYEE :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(70, 257);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 33;
            this.labelControl4.Text = "CUSTOMER :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(66, 227);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "TAX OFFICE :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(51, 197);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 13);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "INVOICE HOUR :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(54, 167);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "INVOICE DATE :";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(26, 107);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(106, 13);
            this.labelControl11.TabIndex = 33;
            this.labelControl11.Text = "SERIAL CHARACTER :";
            // 
            // labelControl7
            // 
            this.labelControl7.Enabled = false;
            this.labelControl7.Location = new System.Drawing.Point(66, 77);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(66, 13);
            this.labelControl7.TabIndex = 33;
            this.labelControl7.Text = "INVOICE ID : ";
            // 
            // grcInvoiceList
            // 
            this.grcInvoiceList.Location = new System.Drawing.Point(1, 2);
            this.grcInvoiceList.MainView = this.gvwInvoices;
            this.grcInvoiceList.Name = "grcInvoiceList";
            this.grcInvoiceList.Size = new System.Drawing.Size(1018, 539);
            this.grcInvoiceList.TabIndex = 18;
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
            this.gvwInvoices.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwInvoices_FocusedRowChanged);
            // 
            // FrmInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grcInvoiceList);
            this.Name = "FrmInvoiceList";
            this.Text = "Invoice List";
            this.Load += new System.EventHandler(this.FrmInvoiceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceSequence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTaxOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvoiceSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtInvoiceSequence;
        private DevExpress.XtraEditors.TextEdit txtInvoiceId;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.GridControl grcInvoiceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwInvoices;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtInvoiceHour;
        private DevExpress.XtraEditors.TextEdit txtInvoiceDate;
        private DevExpress.XtraEditors.LookUpEdit lueInvoiceEmployee;
        private DevExpress.XtraEditors.LookUpEdit lueInvoiceCustomer;
        private DevExpress.XtraEditors.LookUpEdit lueInvoiceSerial;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtInvoiceTaxOffice;
    }
}