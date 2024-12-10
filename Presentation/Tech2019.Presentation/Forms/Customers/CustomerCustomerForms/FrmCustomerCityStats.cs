using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;

namespace Tech2019.Presentation.Forms.Customers.CustomerCustomerForms
{
    public partial class FrmCustomerCityStats : Form
    {
        public FrmCustomerCityStats()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmCustomerCityStats_Load(object sender, EventArgs e)
        {
            grcCustomerCityList.DataSource = db.Customers.OrderBy(x => x.CustomerCity).GroupBy(y => y.CustomerCity).Select(z => new
            {
                City = z.Key,
                Total = z.Count()
            }).ToList();
        }

        //TODO -- 1 pie chart will be planning to added here with the codes below : 
        /* 
            SqlConnection connection = new SqlConnection(@"Data Source=CAN-TOKHAY-MASA\CANTOKHAY;Initial Catalog=TeknikServisDB;Integrated Security=True");
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OHO9G30\SQLEXPRESS;Initial Catalog=TeknikServisDB;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("select CustomerCity, count(*) from Customers group by CustomerCity", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            connection.Close();
        */
    }
}
