using System;
using System.Collections.Generic;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Invoice : IGenericEntity
    {
        public int InvoiceId { get; set; }
        public string InvoiceSerialCharacter { get; set; }
        public string InvoiceSequenceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceTaxOffice { get; set; }
        public int Customer { get; set; }
        public short Employee { get; set; } 

        public Customer CustomerNavigation { get; set; }
        public Employee EmployeeNavigation { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
