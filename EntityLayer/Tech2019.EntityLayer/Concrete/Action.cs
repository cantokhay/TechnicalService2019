using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Action : IGenericEntity
    {
        public int ActionId { get; set; }
        public int Customer { get; set; }
        public short Employee { get; set; }
        public DateTime AcceptedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string ProductSerialNumber { get; set; }
        public ActionStatus ActionStatus { get; set; }
        public ActionStatusDetail ActionStatusDetail { get; set; }

        public Customer CustomerNavigation { get; set; }
        public Employee EmployeeNavigation { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
