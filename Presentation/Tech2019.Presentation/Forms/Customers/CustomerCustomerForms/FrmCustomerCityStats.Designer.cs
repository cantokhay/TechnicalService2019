
namespace Tech2019.Presentation.Forms.Customers.CustomerCustomerForms
{
    partial class FrmCustomerCityStats
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
            this.grcCustomerCityList = new DevExpress.XtraGrid.GridControl();
            this.gvwCustomerCities = new DevExpress.XtraGrid.Views.Grid.GridView(); 
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerCityList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCustomerCities)).BeginInit();
            this.SuspendLayout();
            // 
            // grcCustomerCityList
            // 
            this.grcCustomerCityList.Location = new System.Drawing.Point(1, 2);
            this.grcCustomerCityList.MainView = this.gvwCustomerCities;
            this.grcCustomerCityList.Name = "grcCustomerCityList";
            this.grcCustomerCityList.Size = new System.Drawing.Size(384, 536);
            this.grcCustomerCityList.TabIndex = 9;
            this.grcCustomerCityList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
this.gvwCustomerCities});
            // 
            // gvwCustomerCities
            // 
            this.gvwCustomerCities.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.gvwCustomerCities.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.gvwCustomerCities.Appearance.Row.Options.UseBackColor = true;
            this.gvwCustomerCities.Appearance.Row.Options.UseBorderColor = true;
            this.gvwCustomerCities.GridControl = this.grcCustomerCityList;
            this.gvwCustomerCities.Name = "gvwCustomerCities";
            this.gvwCustomerCities.OptionsView.ShowGroupPanel = false;
            // 
            // FrmCustomerCityStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.grcCustomerCityList);
            this.Name = "FrmCustomerCityStats";
            this.Text = "Customer City Stats";
            this.Load += new System.EventHandler(this.FrmCustomerCityStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerCityList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCustomerCities)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraGrid.GridControl grcCustomerCityList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwCustomerCities;

        #endregion

    }
}