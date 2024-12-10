using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;

namespace Tech2019.Presentation.Forms.Products.ProductStatisticForms
{
    public partial class FrmBrandStats : Form
    {
        public FrmBrandStats()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmBrandStats_Load(object sender, EventArgs e)
        {
            var values = db.Products.OrderBy(x => x.ProductBrand).GroupBy(y => y.ProductBrand).Select(z => new
            {
                Brand = z.Key,
                Total = z.Count()
            }).ToList();
            grcBrandsList.DataSource = values;

            lblTotalProductStat.Text = db.Products.Count().ToString();
            lblTotalBrandsStat.Text = db.Products.Select(x => x.ProductBrand).Distinct().Count().ToString();
            lblMostStockedBrandStat.Text = db.Products.GroupBy(x => x.ProductBrand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            lblMostPricedProductBrandStat.Text = db.Products.OrderByDescending(x => x.ProductSalePrice).Select(y => y.ProductBrand).FirstOrDefault();

            //TODO : 2 Charts will be planned to add!! one doughnut chart, one line chart
        }
    }
}
