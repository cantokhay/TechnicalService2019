
namespace Tech2019.Presentation.Forms.Customers.CustomerSaleForms
{
    partial class FrmSaleList
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
            this.grcSaleList = new DevExpress.XtraGrid.GridControl();
            this.gvwSales = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grcSaleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSales)).BeginInit();
            this.SuspendLayout();
            // 
            // grcSaleList
            // 
            this.grcSaleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcSaleList.Location = new System.Drawing.Point(0, 0);
            this.grcSaleList.MainView = this.gvwSales;
            this.grcSaleList.Name = "grcSaleList";
            this.grcSaleList.Size = new System.Drawing.Size(1370, 541);
            this.grcSaleList.TabIndex = 8;
            this.grcSaleList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwSales});
            // 
            // gvwSales
            // 
            this.gvwSales.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.gvwSales.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.gvwSales.Appearance.Row.Options.UseBackColor = true;
            this.gvwSales.Appearance.Row.Options.UseBorderColor = true;
            this.gvwSales.GridControl = this.grcSaleList;
            this.gvwSales.Name = "gvwSales";
            this.gvwSales.OptionsView.ShowGroupPanel = false;
            // 
            // FrmSaleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.grcSaleList);
            this.Name = "FrmSaleList";
            this.Text = "Sale List";
            this.Load += new System.EventHandler(this.FrmSaleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcSaleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSales)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraGrid.GridControl grcSaleList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwSales;

        #endregion
    }
}