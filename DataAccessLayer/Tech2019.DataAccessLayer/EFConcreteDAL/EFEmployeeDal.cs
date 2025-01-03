using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.EmployeeDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFEmployeeDal : EFGenericDal<Employee>, IEmployeeDal
    {
        TechDBContext _context;
        public EFEmployeeDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public Employee TGetFirstEmployeeByDepartmentId(byte departmentId)
        {
            return _context.Employees
                .Where(e => e.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .FirstOrDefault(e => e.Department == departmentId);
        }

        public int TGetEmployeeCount()
        {
            return _context.Employees
                .Where(e => e.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Count();
        }

        public string TGetMaxEmployeeDepartment()
        {
            return _context.Employees
                .GroupBy(e => e.DepartmentNavigation.DepartmentId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault().DepartmentNavigation.DepartmentName)
                .FirstOrDefault();
        }

        public string TGetMinEmployeeDepartment()
        {
            return _context.Employees
                .GroupBy(e => e.DepartmentNavigation.DepartmentId)
                .OrderBy(g => g.Count())
                .Select(g => g.FirstOrDefault().DepartmentNavigation.DepartmentName)
                .FirstOrDefault();
        }

        public List<EmployeeWithDepartmentDTO> TGetEmployeesByDepartments()
        {
            var employees = _context.Employees
                .Where(e => e.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .ToList();

            var departments = _context.Departments
                .Where(d => d.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .ToList();

            var employeeList = employees
                .Join(departments, e => e.Department, d => d.DepartmentId, (employee, department) => new EmployeeWithDepartmentDTO
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    EmployeeMail = employee.EmployeeMail,
                    EmployeePhoneNumber = employee.EmployeePhoneNumber,
                    EmployeeProfilePhoto = employee.EmployeeProfilePhoto,
                    DepartmentId = employee.Department,
                    DepartmentName = department.DepartmentName
                })
                .ToList();

            return employeeList;
        }
    }
}
