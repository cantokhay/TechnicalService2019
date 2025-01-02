using System;
using System.Collections.Generic;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Employee : IGenericEntity
    {
        public short EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public byte Department { get; set; }
        public string EmployeeProfilePhoto { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeePhoneNumber { get; set; }

        public Department DepartmentNavigation { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
