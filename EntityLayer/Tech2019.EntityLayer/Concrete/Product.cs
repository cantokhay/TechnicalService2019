using System;
using System.Collections.Generic;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Product : IGenericEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public short Stock { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public byte Category { get; set; }

        public Category CategoryNavigation { get; set; }
        public ICollection<Sale> Sales { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
