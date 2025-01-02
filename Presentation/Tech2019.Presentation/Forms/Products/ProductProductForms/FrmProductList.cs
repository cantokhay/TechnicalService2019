using System;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.Presentation.Forms.Products.ProductProductForms
{
    public partial class FrmProductList : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FrmProductList(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }


        private void FrmProductList_Load(object sender, EventArgs e)
        {
            LoadProductList();
            FillLookUpEditCategoriesAndProductStatus();
            ClearProductInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInfo()) return;

            var product = new Product
            {
                ProductName = txtProductName.Text,
                ProductBrand = txtProductBrand.Text,
                ProductSalePrice = decimal.Parse(txtSalePrice.Text),
                ProductPurchasePrice = decimal.Parse(txtPurchasePrice.Text),
                Stock = short.Parse(txtStock.Text),
                Category = byte.Parse(lueProductCategories.EditValue.ToString())
            };
            _productService.Create(product);
            MessageBox.Show("Product Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProductList();
            ClearProductInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateProductId()) return;

            int id = int.Parse(txtProductId.Text);
            var product = _productService.GetById(id);
            _productService.Delete(product);
            MessageBox.Show("Product Deleted Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadProductList();
            ClearProductInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateProductId() || !ValidateProductInfo()) return;

            int id = int.Parse(txtProductId.Text);
            var product = _productService.GetById(id);
            product.ProductName = txtProductName.Text;
            product.ProductBrand = txtProductBrand.Text;
            product.ProductSalePrice = decimal.Parse(txtSalePrice.Text);
            product.ProductPurchasePrice = decimal.Parse(txtPurchasePrice.Text);
            product.Stock = short.Parse(txtStock.Text);
            product.Category = byte.Parse(lueProductCategories.EditValue.ToString());
            product.ProductStatus = (ProductStatus)Enum.Parse(typeof(ProductStatus), lueProductStatus.EditValue.ToString());
            _productService.Update(product);
            MessageBox.Show("Product Updated Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadProductList();
            ClearProductInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProductList();
            ClearProductInfo();
        }

        private void gvwProducts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtProductId.Text = gvwProducts.GetFocusedRowCellValue("ProductId").ToString();
            txtProductName.Text = gvwProducts.GetFocusedRowCellValue("ProductName").ToString();
            txtProductBrand.Text = gvwProducts.GetFocusedRowCellValue("ProductBrand").ToString();
            txtSalePrice.Text = gvwProducts.GetFocusedRowCellValue("ProductSalePrice").ToString();
            txtPurchasePrice.Text = gvwProducts.GetFocusedRowCellValue("ProductPurchasePrice").ToString();
            txtStock.Text = gvwProducts.GetFocusedRowCellValue("Stock").ToString();
            lueProductCategories.EditValue = gvwProducts.GetFocusedRowCellValue("CategoryId");
            var productStatusValue = gvwProducts.GetFocusedRowCellValue("ProductStatus");
            lueProductStatus.EditValue = (int)Enum.Parse(typeof(ProductStatus), productStatusValue.ToString());
        }

        private void FillLookUpEditCategoriesAndProductStatus()
        {
            var categoryList = _categoryService.GetAll()
                .Select(c => new
                {
                    c.CategoryId,
                    c.CategoryName
                })
                .ToList();

            lueProductCategories.Properties.DataSource = categoryList;
            lueProductCategories.Properties.DisplayMember = "CategoryName";
            lueProductCategories.Properties.ValueMember = "CategoryId";
            lueProductCategories.Properties.NullText = "Please pick a value";

            var productStatusList = Enum.GetValues(typeof(ProductStatus))
                .Cast<ProductStatus>()
                .Select(status => new
                {
                    StatusValues = (int)status,
                    StatusDisplays = status.ToString()
                })
                .ToList();

            lueProductStatus.Properties.DataSource = productStatusList;
            lueProductStatus.Properties.DisplayMember = "StatusDisplays";
            lueProductStatus.Properties.ValueMember = "StatusValues";
            lueProductStatus.Properties.NullText = "Please pick a value";
        }

        private void LoadProductList()
        {
            var productList = _productService.GetProductsWithCategories();

            grcProductList.DataSource = productList;
        }

        private void ClearProductInfo()
        {
            txtProductId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductBrand.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
            txtPurchasePrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            lueProductCategories.EditValue = null;
            lueProductStatus.EditValue = null;
        }

        #region Validation Methods

        private bool ValidateProductInfo()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductBrand.Text))
            {
                MessageBox.Show("Product Brand cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPurchasePrice.Text) || !decimal.TryParse(txtPurchasePrice.Text, out _))
            {
                MessageBox.Show("Please provide a valid purchase price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSalePrice.Text) || !decimal.TryParse(txtSalePrice.Text, out _))
            {
                MessageBox.Show("Please provide a valid sale price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStock.Text) || !short.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Please provide a valid stock quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueProductCategories.EditValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueProductStatus.EditValue == null)
            {
                MessageBox.Show("Please select a status for this product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateProductId()
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                MessageBox.Show("Product ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtProductId.Text, out _))
            {
                MessageBox.Show("Product ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

    }
}
