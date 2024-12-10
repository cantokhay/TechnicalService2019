using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Products.ProductCategoryForms
{
    public partial class FrmNewCategory : Form
    {
        public FrmNewCategory()
        {
            InitializeComponent();
        }

        private void btnNewSave_Click(object sender, System.EventArgs e)
        {
            TechDBContext db = new TechDBContext();
            Category category = new Category();
            AssignCategoryInfo(category);
            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("Category added succesfully");
            this.Close();
        }
        private void btnNewQuit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #region Extracted Methods

        private void AssignCategoryInfo(Category category)
        {
            category.CategoryName = txtCategoryName.Text;
        }

        #endregion
    }
}
