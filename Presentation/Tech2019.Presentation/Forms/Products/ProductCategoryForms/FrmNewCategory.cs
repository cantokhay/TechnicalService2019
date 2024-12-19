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
            InitializePlaceholderEvents();
        }

        private void btnNewSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateCategoryInfo())
                return;

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

        private bool ValidateCategoryInfo()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || txtCategoryName.Text == "Category Name")
            {
                MessageBox.Show("Category Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtCategoryName, "Category Name");
        }

        private void AddPlaceholderEvents(DevExpress.XtraEditors.TextEdit textEdit, string placeholder)
        {
            textEdit.GotFocus += (sender, e) =>
            {
                if (textEdit.Text == placeholder)
                {
                    textEdit.Text = string.Empty;
                }
            };

            textEdit.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textEdit.Text))
                {
                    textEdit.Text = placeholder;
                }
            };
        }

        private void AssignCategoryInfo(Category category)
        {
            category.CategoryName = txtCategoryName.Text;
        }

        #endregion
    }
}
