namespace Tech2019.DTOLayer.CustomerDTO
{
    public class CustomerToInvoiceDTO
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFullName => $"{CustomerFirstName} {CustomerLastName}";
    }
}
