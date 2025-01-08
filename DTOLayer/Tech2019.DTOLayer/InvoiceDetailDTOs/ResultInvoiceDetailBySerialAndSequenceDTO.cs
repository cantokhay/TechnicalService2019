using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DTOLayer.InvoiceDetailDTOs
{
    public class ResultInvoiceDetailBySerialAndSequenceDTO
    {
        public int InvoiceDetailId { get; set; }
        public string ProductName { get; set; }
        public short ProductSaleQuantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public Invoice InvoiceNavigation { get; set; }
    }
}
