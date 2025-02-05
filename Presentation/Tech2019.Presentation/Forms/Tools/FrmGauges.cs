using System.Windows.Forms;

namespace Tech2019.Presentation.Forms.Tools
{
    public partial class FrmGauges : Form
    {
        public FrmGauges()
        {
            InitializeComponent();
        }

        private void FrmGauges_Load(object sender, System.EventArgs e)
        {

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            ascGauge1.Value++;
            if (ascGauge1.Value == 180)
            { 
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            ascGauge1.Value--;
            if (ascGauge1.Value == 0)
            {
                timer1.Start();
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, System.EventArgs e)
        {
            ascGauge2.Value++;
            if (ascGauge2.Value == 100)
            {
                timer3.Stop();
                timer4.Start();
            }
        }

        private void timer4_Tick(object sender, System.EventArgs e)
        {
            ascGauge2.Value--;
            if (ascGauge2.Value == 0)
            {
                timer3.Start();
                timer4.Stop();
            }
        }

        private void timer5_Tick(object sender, System.EventArgs e)
        {
            ascGauge3.Value++;
            if (ascGauge3.Value == 90)
            {
                timer5.Stop();
                timer6.Start();
            }
        }

        private void timer6_Tick(object sender, System.EventArgs e)
        {
            ascGauge3.Value--;
            if (ascGauge3.Value == 10)
            {
                timer5.Start();
                timer6.Stop();
            }
        }

        private void timer7_Tick(object sender, System.EventArgs e)
        {
            ascGauge4.Value++;
            if (ascGauge4.Value == 200)
            {
                timer7.Stop();
                timer8.Start();
            }
        }

        private void timer8_Tick(object sender, System.EventArgs e)
        {
            ascGauge4.Value--;
            if (ascGauge4.Value == 0)
            {
                timer7.Start();
                timer8.Stop();
            }
        }
    }
}
