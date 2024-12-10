using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;

namespace Tech2019.Presentation.Forms.Products.ProductStatisticForms
{
    public partial class FrmProductStats : Form
    {
        public FrmProductStats()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmProductStats_Load(object sender, EventArgs e)
        {
            lblTotalProductStat.Text = db.Products.Count().ToString();
            lblTotalCategoriesStat.Text = db.Categories.Count().ToString();
            lblTotalStockStat.Text = db.Products.Sum(x => x.Stock).ToString();
            lblCritLevelStat.Text = db.Products.Count(x => x.Stock <= 20).ToString();
            //lblTodaySoldProductsStat
            lblMaxStockProductStat.Text = db.Products.OrderByDescending(x => x.Stock).Select(y => y.ProductName).FirstOrDefault();
            lblMinStockProductStat.Text = db.Products.OrderBy(x => x.Stock).Select(y => y.ProductName).FirstOrDefault();
            lblMostProductCategoryStat.Text = db.Categories.Where(x => x.CategoryId == db.Products.GroupBy(y => y.Category).OrderByDescending(z => z.Count()).Select(a => a.Key).FirstOrDefault()).Select(b => b.CategoryName).FirstOrDefault();
            lblMaxPricedProductStat.Text = db.Products.OrderByDescending(x => x.ProductSalePrice).Select(y => y.ProductName).FirstOrDefault();
            lblMinPricedProductStat.Text = db.Products.OrderBy(x => x.ProductSalePrice).Select(y => y.ProductName).FirstOrDefault();
            lblTotalBrandsStat.Text = db.Products.Select(x => x.ProductBrand).Distinct().Count().ToString();
            lblMostStockedBrandStat.Text = db.Products.GroupBy(x => x.ProductBrand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            //lblFaultyProductsStat
            //lblProductsUnderRepairStat
            //lblTodayFaultyProductsStat
            lblTotalApplianceStat.Text = db.Products.Where(x => x.CategoryNavigation.CategoryName == "Appliance").Sum(x => x.Stock).ToString();
            lblTotalComputersStat.Text = db.Products.Where(x => x.CategoryNavigation.CategoryName == "Computer").Sum(x => x.Stock).ToString();
            lblTotalGamingStat.Text = db.Products.Where(x => x.CategoryNavigation.CategoryName == "Gaming").Sum(x => x.Stock).ToString();
            //lblProductsAfterRepairStat
            //lblProductsReadyCargoStat
        }
    }
}
