using System;
using System.Collections.Generic;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Customer : IGenericEntity
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
        public CustomerStatus CustomerStatus { get; set; }

        public ICollection<Action> Actions { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }

}
