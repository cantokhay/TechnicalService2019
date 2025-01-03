using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
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
    }
}
