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

            SqlConnection sqlConnectionPC = new SqlConnection(@"Data Source=CAN-TOKHAY-MASA\CANTOKHAY;initial Catalog=Tech2019DB;integrated Security=True;");
            SqlConnection sqlConnectionLAPTOP = new SqlConnection(@"Data Source=DESKTOP-OHO9G30\SQLEXPRESS;initial Catalog=Tech2019DB;integrated Security=True;");

            var brandCountConnection = sqlConnectionPC;
            brandCountConnection.Open();
            SqlCommand brandCountCommand = new SqlCommand("SELECT ProductBrand,Count(*) FROM Products GROUP BY ProductBrand", brandCountConnection);
            SqlDataReader brandCountDataReader = brandCountCommand.ExecuteReader();
            while (brandCountDataReader.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(brandCountDataReader[0].ToString(), int.Parse(brandCountDataReader[1].ToString()));
            }
            brandCountConnection.Close();

            var categoryProductConnection = sqlConnectionPC;
            categoryProductConnection.Open();
            SqlCommand categoryProductCommand = new SqlCommand("SELECT Categories.CategoryName, Count(*) FROM Products INNER JOIN Categories ON Categories.CategoryId = Products.Category GROUP BY Categories.CategoryName", categoryProductConnection);
            SqlDataReader categoryProductDataReader = categoryProductCommand.ExecuteReader();
            while (categoryProductDataReader.Read())
            {
                chartControl2.Series["Categories"].Points.AddPoint(categoryProductDataReader[0].ToString(), int.Parse(categoryProductDataReader[1].ToString()));
            }
            categoryProductConnection.Close();
            //TODO : populate the charts
        }
    }
}
