using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        int GetEmployeeCount();
        string GetMaxEmployeeDepartment();
        string GetMinEmployeeDepartment();
    }
}
