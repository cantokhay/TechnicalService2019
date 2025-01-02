using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class InvoiceDetail : IGenericEntity
    {
        public int InvoiceDetailId { get; set; }
        public string ProductName { get; set; }
        public short ProductSaleQuantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int Invoice { get; set; }

        public Invoice InvoiceNavigation { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }

}
