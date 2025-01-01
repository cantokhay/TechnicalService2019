using System;
using System.Collections.Generic;

namespace Tech2019.EntityLayer.Concrete
{
    public class Invoice
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
    }
}
