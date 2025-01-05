namespace Tech2019.DTOLayer.InvoiceDTOs
{
    public class ResultInvoiceDTO
    {
        public int InvoiceId { get; set; }
        public string InvoiceSequenceNumber { get; set; }
        public string InvoiceSerialCharacter { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceHour { get; set; }
        public string InvoiceTaxOffice { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public short EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
