using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Products.ProductStatisticForms
{
    public partial class FrmBrandStats : Form
    {
        private readonly IProductService _productService;
        public FrmBrandStats(IProductService productService)
        {
            _productService = productService;
            InitializeComponent();
        }

        private void FrmBrandStats_Load(object sender, EventArgs e)
        {
            grcBrandsList.DataSource = _productService.GetProductBrandStats();

            lblTotalProductStat.Text = _productService.GetTotalProductCount().ToString();
            lblTotalBrandsStat.Text = _productService.GetTotalBrandCount().ToString();
            lblMostStockedBrandStat.Text = _productService.GetMostStockedBrand();
            lblMostPricedProductBrandStat.Text = _productService.GetMostExpensiveProduct();
            gvwBrands.OptionsBehavior.Editable = false;

            //SqlConnection sqlConnection = new SqlConnection(@"Data Source=CAN-TOKHAY-MASA\CANTOKHAY;initial Catalog=Tech2019DB;integrated Security=True;");
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-OHO9G30\SQLEXPRESS;initial Catalog=Tech2019DB;integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand("SELECT ProductBrand,Count(*) FROM Products GROUP BY ProductBrand", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(sqlDataReader[0].ToString(), int.Parse(sqlDataReader[1].ToString()));
            }
            sqlConnection.Close();
            //TODO : populate the charts
        }
    }
}
