using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Products.ProductProductForms
{
    public partial class FrmNewProduct : Form
    {
        public FrmNewProduct()
        {
            InitializeComponent();
            FillLookUpEditCategories();
        }

        private void btnNewProductSave_Click(object sender, EventArgs e)
        {
            TechDBContext db = new TechDBContext();
            Product product = new Product();
            AssignProductInfo(product);
            product.ProductStatus = false;
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
        }

        #endregion
    }
}
