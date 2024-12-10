using System;

namespace Tech2019.EntityLayer.Concrete
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int Product { get; set; }
        public int Customer { get; set; }
        public short Employee { get; set; }
        public DateTime SaleDate { get; set; }
        public short SaleQuantity { get; set; }
        public decimal SaleTotalPrice { get; set; }
        public string ProductSerialNumber { get; set; }

        public Product ProductNavigation { get; set; }
        public Customer CustomerNavigation { get; set; }
        public Employee EmployeeNavigation { get; set; }
    }
}
