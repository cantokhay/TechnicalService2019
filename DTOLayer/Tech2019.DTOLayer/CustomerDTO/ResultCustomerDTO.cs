using Tech2019.EntityLayer.Enum;

namespace Tech2019.DTOLayer.CustomerDTO
{
    public class ResultCustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerBank { get; set; }
        public string CustomerTaxNumber { get; set; }
        public string CustomerTaxOffice { get; set; }
        public string CustomerStatus { get; set; }
    }
}
