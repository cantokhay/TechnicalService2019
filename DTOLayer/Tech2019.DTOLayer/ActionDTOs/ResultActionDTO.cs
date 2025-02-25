using System;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.DTOLayer.ActionDTOs
{
    public class ResultActionDTO
    {
        public int ActionId { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AcceptedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string ProductSerialNumber { get; set; }
        public ActionStatus ActionStatus { get; set; }
        public ActionStatusDetail ActionStatusDetail { get; set; }
    }
}
