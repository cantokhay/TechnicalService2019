using System;
using System.Collections.Generic;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Department : IGenericEntity
    {
        public byte DepartmentId { get; set; } 
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
