using System;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.DTOLayer.ProductTraceDTOs
{
    public class ResultProductTraceDTO
    {
        public int ProductTraceId { get; set; }
        public DateTime ProductTraceDate { get; set; }
        public string ProductTraceDetail { get; set; }
        public DateTime? SaleDate { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public ActionStatusDetail ActionStatusDetail { get; set; }
    }
}
