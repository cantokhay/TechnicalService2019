using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Products.ProductCategoryForms
{
    public partial class FrmCategoryList : Form
    {
        public FrmCategoryList()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext(); //TODO: This should be come with dependency injection.

        private void FrmCategoryList_Load(object sender, EventArgs e)
        {
            CategoryList();
            ClearCategoryInfo();
        }

        private void gvwCategories_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtCategoryId.Text = gvwCategories.GetFocusedRowCellValue("CategoryId").ToString();
            txtCategoryName.Text = gvwCategories.GetFocusedRowCellValue("CategoryName").ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CategoryList();
            ClearCategoryInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryInfo())
                return;

            Category category = new Category();
            AssignCategoryInfo(category);
            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("Category Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CategoryList();
            ClearCategoryInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryId())
                return;

            int id = int.Parse(txtCategoryId.Text);
            var category = db.Categories.Find(id);

            if (category == null)
            {
                MessageBox.Show("Category Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.Categories.Remove(category);
            db.SaveChanges();
            MessageBox.Show("Category Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            CategoryList();
            ClearCategoryInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryId())
                return;

            if (!ValidateCategoryInfo())
                return;

            int id = int.Parse(txtCategoryId.Text);
            var category = db.Categories.Find(id);

            if (category == null)
            {
                MessageBox.Show("Category Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AssignCategoryInfo(category);
            db.SaveChanges();
            MessageBox.Show("Category Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            CategoryList();
            ClearCategoryInfo();
        }

        #region Extracted Methods

        private void CategoryList()
        {
            var values = from x in db.Categories
                         select new
                         {
                             x.CategoryId,
                             x.CategoryName
                         };
            grcCategoryList.DataSource = values.ToList();
        }

        private void ClearCategoryInfo()
        {
            txtCategoryId.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
        }

        private void AssignCategoryInfo(Category category)
        {
            category.CategoryName = txtCategoryName.Text;
        }

        #endregion

        #region Validation Methods

        private bool ValidateCategoryInfo()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateCategoryId()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                MessageBox.Show("Category ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!byte.TryParse(txtCategoryId.Text, out _))
            {
                MessageBox.Show("Category ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
    }
}
