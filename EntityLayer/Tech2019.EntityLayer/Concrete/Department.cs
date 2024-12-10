using System.Collections.Generic;

namespace Tech2019.EntityLayer.Concrete
{
    public class Department
    {
        public byte DepartmentId { get; set; } 
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
