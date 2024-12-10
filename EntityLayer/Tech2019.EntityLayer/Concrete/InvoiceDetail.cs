namespace Tech2019.EntityLayer.Concrete
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public string ProductName { get; set; }
        public short ProductSaleQuantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int Invoice { get; set; }

        public Invoice InvoiceNavigation { get; set; }
    }

}
