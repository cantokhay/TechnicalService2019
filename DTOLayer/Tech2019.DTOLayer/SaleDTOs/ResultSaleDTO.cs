using System;

namespace Tech2019.DTOLayer.SaleDTOs
{
    public class ResultSaleDTO
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public short SaleQuantity { get; set; }
        public decimal SaleTotalPrice { get; set; }
        public string ProductSerialNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public short EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
