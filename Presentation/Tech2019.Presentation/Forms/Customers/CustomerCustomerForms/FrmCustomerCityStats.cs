using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Customers.CustomerCustomerForms
{
    public partial class FrmCustomerCityStats : Form
    {
        private readonly ICustomerService _customerService;
        public FrmCustomerCityStats(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void FrmCustomerCityStats_Load(object sender, EventArgs e)
        {
            grcCustomerCityList.DataSource = _customerService.GetCustomerCityStat();
            gvwCustomerCities.OptionsBehavior.Editable = false;
            FillChartWithCityDatas();
        }

        private void FillChartWithCityDatas()
        {
            var cityStats = _customerService.FillChartWithCityDatas();

            foreach (var stat in cityStats)
            {
                cctCityStats.Series["Series 1"].Points.AddPoint(Convert.ToString(stat.City), int.Parse(stat.Total.ToString()));
            }
        }

    }
}
