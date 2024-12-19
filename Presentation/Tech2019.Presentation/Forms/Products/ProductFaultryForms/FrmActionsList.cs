using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;

namespace Tech2019.Presentation.Forms.Products.ProductFaultryForms
{
    public partial class FrmActionsList : Form
    {
        public FrmActionsList()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmActionsList_Load(object sender, EventArgs e)
        {
            ActionsList();
            FillChartWithActionData();
        }

        #region Extracted Methods

        private void ActionsList()
        {
            var values = db.Actions.Select(x => new
            {
                x.ActionId,
                Customer = x.CustomerNavigation.CustomerFirstName + " " + x.CustomerNavigation.CustomerLastName,
                Employee = x.EmployeeNavigation.EmployeeFirstName + " " + x.EmployeeNavigation.EmployeeLastName,
                x.ProductSerialNumber,
                x.AcceptedDate,
                x.CompletedDate
            }).ToList();
            grcActionsList.DataSource = values;
        }

        private void FillChartWithActionData()
        {
            var data = db.Actions
                .Join(db.Sales,
                      action => action.ProductSerialNumber,
                      sale => sale.ProductSerialNumber,
                      (action, sale) => new
                      {
                          ProductBrand = sale.ProductNavigation.ProductBrand,
                          ActionId = action.ActionId
                      })
                .GroupBy(x => x.ProductBrand)
                .Select(g => new
                {
                    Brand = g.Key,
            ActionCount = g.Count()
        })
                .ToList();

            chartControl1.Series[0].Points.Clear();
            foreach (var item in data)
            {
                chartControl1.Series[0].Points.AddPoint(item.Brand, item.ActionCount);
            }
        }


        #endregion

    }
}
