using System;

namespace Tech2019.DTOLayer.CustomerDTO
{
    public class ResultCustomerInfoBySerialDTO
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
