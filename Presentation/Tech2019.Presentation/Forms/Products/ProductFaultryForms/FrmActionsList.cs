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

        #endregion

        //TODO: One doughnut chart is expected to be in here
    }
}
