using System;
using System.Windows.Forms;

namespace Tech2019.Presentation.Forms.Tools
{
    public partial class FrmCurrency : Form
    {
        public FrmCurrency()
        {
            InitializeComponent();
        }

        private void FrmCurrency_Load(object sender, EventArgs e)
        {
            webCurrency.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
