using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Products.ProductCategoryForms
{
    public partial class FrmCategoryList : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategoryList(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private void FrmCategoryList_Load(object sender, EventArgs e)
        {
            LoadCategoryList();
            ClearCategoryInfo();
        }

        private void gvwCategories_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtCategoryId.Text = gvwCategories.GetFocusedRowCellValue("CategoryId").ToString();
            txtCategoryName.Text = gvwCategories.GetFocusedRowCellValue("CategoryName").ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategoryList();
            ClearCategoryInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryInfo())
                return;

            Category category = new Category();
            AssignCategoryInfo(category);
            _categoryService.Create(category);
            MessageBox.Show("Category Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCategoryList();
            ClearCategoryInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryId())
                return;

            int id = int.Parse(txtCategoryId.Text);
            var category = _categoryService.GetById(id);
            _categoryService.Delete(category);
            MessageBox.Show("Category Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadCategoryList();
            ClearCategoryInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryId() || !ValidateCategoryInfo()) return;

            int id = int.Parse(txtCategoryId.Text);
            var category = _categoryService.GetById(id);
            AssignCategoryInfo(category);
            _categoryService.Update(category);
            MessageBox.Show("Category Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadCategoryList();
            ClearCategoryInfo();
        }

        #region Extracted Methods

        private void LoadCategoryList()
        {
            var categoriesList = _categoryService.GetCategories();

            grcCategoryList.DataSource = categoriesList;
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
