
namespace Tech2019.Presentation.Forms.Products.ProductProductForms
{
    partial class FrmProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductList));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lueProductCategories = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtStock = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSalePrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPurchasePrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProductBrand = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtProductId = new DevExpress.XtraEditors.TextEdit();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.grcProductList = new DevExpress.XtraGrid.GridControl();
            this.gvwProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductCategories.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.btnRefresh);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.lueProductCategories);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtStock);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtSalePrice);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtPurchasePrice);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtProductBrand);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtProductId);
            this.groupControl1.Controls.Add(this.txtProductName);
            this.groupControl1.Location = new System.Drawing.Point(1025, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(340, 536);
            this.groupControl1.TabIndex = 78;
            this.groupControl1.Text = "PRODUCT OPERATIONS";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(34, 489);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(293, 39);
            this.btnRefresh.TabIndex = 9;
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
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(60, 261);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 13);
            this.labelControl6.TabIndex = 108;
            this.labelControl6.Text = "CATEGORY : ";
            // 
            // lueProductCategories
            // 
            this.lueProductCategories.Location = new System.Drawing.Point(127, 258);
            this.lueProductCategories.Name = "lueProductCategories";
            this.lueProductCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProductCategories.Properties.DisplayMember = "CategoryName";
            this.lueProductCategories.Properties.ValueMember = "CategoryId";
            this.lueProductCategories.Size = new System.Drawing.Size(194, 20);
            this.lueProductCategories.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(81, 231);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(43, 13);
            this.labelControl5.TabIndex = 88;
            this.labelControl5.Text = "STOCK : ";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(127, 228);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(194, 20);
            this.txtStock.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(57, 201);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 13);
            this.labelControl4.TabIndex = 88;
            this.labelControl4.Text = "SALE PRICE : ";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(127, 198);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(194, 20);
            this.txtSalePrice.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 171);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 13);
            this.labelControl3.TabIndex = 88;
            this.labelControl3.Text = "PURCHASE PRICE : ";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(127, 168);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(194, 20);
            this.txtPurchasePrice.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(29, 141);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 13);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = "PRODUCT BRAND : ";
            // 
            // txtProductBrand
            // 
            this.txtProductBrand.Location = new System.Drawing.Point(127, 138);
            this.txtProductBrand.Name = "txtProductBrand";
            this.txtProductBrand.Size = new System.Drawing.Size(194, 20);
            this.txtProductBrand.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Enabled = false;
            this.labelControl7.Location = new System.Drawing.Point(52, 85);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 13);
            this.labelControl7.TabIndex = 88;
            this.labelControl7.Text = "PRODUCT ID : ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 111);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 88;
            this.labelControl1.Text = "PRODUCT NAME : ";
            // 
            // txtProductId
            // 
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(127, 82);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(194, 20);
            this.txtProductId.TabIndex = 0;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(127, 108);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(194, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // grcProductList
            // 
            this.grcProductList.Location = new System.Drawing.Point(1, 2);
            this.grcProductList.MainView = this.gvwProducts;
            this.grcProductList.Name = "grcProductList";
            this.grcProductList.Size = new System.Drawing.Size(1018, 536);
            this.grcProductList.TabIndex = 0;
            this.grcProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwProducts});
            // 
            // gvwProducts
            // 
            this.gvwProducts.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.gvwProducts.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.gvwProducts.Appearance.Row.Options.UseBackColor = true;
            this.gvwProducts.Appearance.Row.Options.UseBorderColor = true;
            this.gvwProducts.GridControl = this.grcProductList;
            this.gvwProducts.Name = "gvwProducts";
            this.gvwProducts.OptionsView.ShowGroupPanel = false;
            this.gvwProducts.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwProducts_FocusedRowChanged);
            // 
            // FrmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.grcProductList);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmProductList";
            this.Text = "Product List";
            this.Load += new System.EventHandler(this.FrmProductList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductCategories.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwProducts)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraGrid.GridControl grcProductList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwProducts;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtProductBrand;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPurchasePrice;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lueProductCategories;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtStock;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSalePrice;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtProductId;

        #endregion
    }
}