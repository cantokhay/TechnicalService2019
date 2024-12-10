using System.Collections.Generic;

namespace Tech2019.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public short Stock { get; set; }
        public bool ProductStatus { get; set; }
        public byte Category { get; set; }

        public Category CategoryNavigation { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }

}
