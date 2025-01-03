using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IEmployeeDal : IGenericDal<Employee>
    {
        int TGetEmployeeCount();
        string TGetMaxEmployeeDepartment();
        string TGetMinEmployeeDepartment();
    }
}
