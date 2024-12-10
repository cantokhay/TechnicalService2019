using System;
using System.Windows.Forms;

namespace Tech2019.Presentation.Forms.Tools
{
    public partial class FrmYoutube : Form
    {
        public FrmYoutube()
        {
            InitializeComponent();
        }

        private void FrmYoutube_Load(object sender, EventArgs e)
        {
            webYoutube.Navigate("https://www.youtube.com/");
        }
    }
}
