using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.Presentation.Forms.Products.ProductProductForms
{
    public partial class FrmNewProduct : Form
    {
        public FrmNewProduct()
        {
            InitializeComponent();
            FillLookUpEditCategories();
            InitializePlaceholderEvents();
        }

        private void btnNewProductSave_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInfo())
                return;
            TechDBContext db = new TechDBContext();
            Product product = new Product();
            AssignProductInfo(product);
            product.ProductStatus = ProductStatus.ActivelySold;
            db.Products.Add(product);
            db.SaveChanges();
            MessageBox.Show("Product added successfully");
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
        }

        private void FillLookUpEditCategories()
        {
            TechDBContext db = new TechDBContext();
            var categoriesList = from c in db.Categories
                                 select new
                                 {
                                     c.CategoryId,
                                     c.CategoryName
                                 }; //TODO : This comes with categoryid but categoryid should be hidden and only name should be shown.
            lueProductCategories.Properties.DataSource = categoriesList.ToList();
            lueProductCategories.Properties.NullText = "Please pick a value";
        }

        #endregion
    }
}
