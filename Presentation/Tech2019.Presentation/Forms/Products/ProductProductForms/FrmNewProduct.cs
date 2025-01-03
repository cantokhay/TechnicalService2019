using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.Presentation.Forms.Products.ProductProductForms
{
    public partial class FrmNewProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FrmNewProduct(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }


        private void FrmNewProduct_Load(object sender, EventArgs e)
        {
            FillLookUpEditCategoriesAndProductStatus();
            InitializePlaceholderEvents();
        }

        private void btnNewProductSave_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInfo())
                return;
            var product = new Product();
            AssignProductInfo(product);
            _productService.Create(product);
            MessageBox.Show("Product Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnNewProductQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Exracted Methods

        private bool ValidateProductInfo()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) || txtProductName.Text == "Product Name")
            {
                MessageBox.Show("Product Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductBrand.Text) || txtProductBrand.Text == "Product Brand")
            {
                MessageBox.Show("Product Brand cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueProductCategories.EditValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSalePrice.Text) || !decimal.TryParse(txtSalePrice.Text, out _) || txtSalePrice.Text == "Sale Price")
            {
                MessageBox.Show("Please provide a valid sale price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPurchasePrice.Text) || !decimal.TryParse(txtPurchasePrice.Text, out _) || txtPurchasePrice.Text == "Purchase Price")
            {
                MessageBox.Show("Please provide a valid purchase price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStock.Text) || !short.TryParse(txtStock.Text, out _) || txtStock.Text == "Stock Quantity")
            {
                MessageBox.Show("Please provide a valid stock quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueProductStatus.EditValue == null)
            {
                MessageBox.Show("Please select a status for this product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtProductName, "Product Name");
            AddPlaceholderEvents(txtProductBrand, "Product Brand");
            AddPlaceholderEvents(txtPurchasePrice, "Purchase Price");
            AddPlaceholderEvents(txtSalePrice, "Sale Price");
            AddPlaceholderEvents(txtStock, "Stock Quantity");
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

        private void AssignProductInfo(Product product)
        {
            product.ProductName = txtProductName.Text;
            product.ProductBrand = txtProductBrand.Text;
            product.ProductSalePrice = decimal.Parse(txtSalePrice.Text);
            product.ProductPurchasePrice = decimal.Parse(txtPurchasePrice.Text);
            product.Stock = short.Parse(txtStock.Text);
            product.Category = byte.Parse(lueProductCategories.EditValue.ToString());
            product.ProductStatus = (ProductStatus)Enum.Parse(typeof(ProductStatus), lueProductStatus.EditValue.ToString());
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

        #endregion
    }
}
