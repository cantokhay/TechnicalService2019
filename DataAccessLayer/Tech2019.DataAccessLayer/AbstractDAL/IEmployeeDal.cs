using System.Collections.Generic;
using Tech2019.DTOLayer.EmployeeDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IEmployeeDal : IGenericDal<Employee>
    {
        int TGetEmployeeCount();
        string TGetMaxEmployeeDepartment();
        string TGetMinEmployeeDepartment();
        Employee TGetFirstEmployeeByDepartmentId(byte departmentId);
        List<EmployeeWithDepartmentDTO> TGetEmployeesByDepartments();
        List<EmployeeToInvoiceDTO> TGetEmployeesToInvoice();
        List<EmployeeToSaleDTO> TGetEmployeesToSale();
    }
}
