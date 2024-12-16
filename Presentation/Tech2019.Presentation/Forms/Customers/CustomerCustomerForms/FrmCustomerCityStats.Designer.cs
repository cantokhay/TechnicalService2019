
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
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            this.grcCustomerCityList = new DevExpress.XtraGrid.GridControl();
            this.gvwCustomerCities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cctCityStats = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerCityList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCustomerCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cctCityStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
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
            // cctCityStats
            // 
            this.cctCityStats.AppearanceNameSerializable = "The Trees";
            this.cctCityStats.BackColor = System.Drawing.Color.Transparent;
            this.cctCityStats.Legend.BackColor = System.Drawing.Color.Transparent;
            this.cctCityStats.Legend.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cctCityStats.Legend.Name = "Default Legend";
            this.cctCityStats.Legend.TextColor = System.Drawing.Color.DarkRed;
            this.cctCityStats.Location = new System.Drawing.Point(390, 2);
            this.cctCityStats.Name = "cctCityStats";
            this.cctCityStats.PaletteName = "Urban";
            series1.LegendTextPattern = "{A}";
            series1.Name = "Series 1";
            series1.View = pieSeriesView1;
            this.cctCityStats.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.cctCityStats.Size = new System.Drawing.Size(975, 536);
            this.cctCityStats.TabIndex = 10;
            // 
            // FrmCustomerCityStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.cctCityStats);
            this.Controls.Add(this.grcCustomerCityList);
            this.Name = "FrmCustomerCityStats";
            this.Text = "Customer City Stats";
            this.Load += new System.EventHandler(this.FrmCustomerCityStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerCityList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCustomerCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cctCityStats)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraGrid.GridControl grcCustomerCityList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwCustomerCities;

        #endregion

        private DevExpress.XtraCharts.ChartControl cctCityStats;
    }
}