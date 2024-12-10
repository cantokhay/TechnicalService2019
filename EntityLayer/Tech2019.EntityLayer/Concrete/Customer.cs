using System.Collections.Generic;

namespace Tech2019.EntityLayer.Concrete
{
    public class Customer
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

        public ICollection<Action> Actions { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }

}
