using System.Collections.Generic;
using Tech2019.DTOLayer.EmployeeDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        int GetEmployeeCount();
        string GetMaxEmployeeDepartment();
        string GetMinEmployeeDepartment();
        Employee GetFirstEmployeeByDepartmentId(byte departmentId);
        List<EmployeeWithDepartmentDTO> GetEmployeesByDepartments();
    }
}
