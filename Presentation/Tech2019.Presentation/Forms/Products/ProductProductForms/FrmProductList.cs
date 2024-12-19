using System.Windows.Forms;
using System.Linq;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Products.ProductProductForms
{
    public partial class FrmProductList : Form
    {
        public FrmProductList()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext(); //TODO: This should be come with dependency injection.

        private void FrmProductList_Load(object sender, System.EventArgs e)
        {
            ProductList();
            FillLookUpEditCategories();
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
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateProductInfo())
                return;

            Product product = new Product(); //TODO: This should be come with dependency injection.
            AssignProductInfo(product); //TODO: This method should check for existing product with the same name and other properties.
            product.ProductStatus = false;
            db.Products.Add(product);
            db.SaveChanges();
            MessageBox.Show("Product Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductList();
            ClearProductInfo();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (!ValidateProductId())
                return;

            int id = int.Parse(txtProductId.Text);
            var product = db.Products.Find(id);

            if (product == null)
            {
                MessageBox.Show("Product Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.Products.Remove(product);
            db.SaveChanges();
            MessageBox.Show("Product Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ProductList();
            ClearProductInfo();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (!ValidateProductId())
                return;

            if (!ValidateProductInfo())
                return;

            int id = int.Parse(txtProductId.Text);
            var product = db.Products.Find(id);

            if (product == null)
            {
                MessageBox.Show("Product not found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AssignProductInfo(product);
            db.SaveChanges();
            MessageBox.Show("Product Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ProductList();
            ClearProductInfo();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            ProductList();
            ClearProductInfo();
        }

        #region Extracted Methods

        private void ClearProductInfo()
        {
            txtProductId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductBrand.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
            txtPurchasePrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            lueProductCategories.EditValue = null;
        }

        private void FillLookUpEditCategories()
        {
            var categoriesList = from c in db.Categories
                                 select new
                                 {
                                     c.CategoryId,
                                     c.CategoryName
                                 }; //TODO : This comes with categoryid but categoryid should be hidden and only name should be shown.
            lueProductCategories.Properties.DataSource = categoriesList.ToList();
            lueProductCategories.Properties.NullText = "Please pick a value";
        }

        private void ProductList()
        {
            var productsList = from p in db.Products
                               join c in db.Categories on p.Category equals c.CategoryId
                               select new
                               {
                                   p.ProductId,
                                   p.ProductName,
                                   p.ProductBrand,
                                   p.ProductSalePrice,
                                   p.ProductPurchasePrice,
                                   p.Stock,
                                   c.CategoryName,
                                   c.CategoryId
                               };//TODO : This comes with categoryid but categoryid should be hidden and only name should be shown.
            grcProductList.DataSource = productsList.ToList();
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

        #endregion

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
            return true;
        }

        private bool ValidateProductId()
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                MessageBox.Show("Product ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!byte.TryParse(txtProductId.Text, out _))
            {
                MessageBox.Show("Product ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
    }
}
