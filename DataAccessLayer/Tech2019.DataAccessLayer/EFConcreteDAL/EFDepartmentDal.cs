using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.DepartmentDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFDepartmentDal : EFGenericDal<Department>, IDepartmentDal
    {
        private readonly TechDBContext _context;
        public EFDepartmentDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultDepartmentDTO> TGetDepartments()
        {
            return _context.Departments
                .Where(d => d.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Select(item => new ResultDepartmentDTO
                {
                    DepartmentId = item.DepartmentId,
                    DepartmentName = item.DepartmentName,
                    DepartmentDescription = item.DepartmentDescription
                })
                .ToList();
        }

        public int TGetDepartmentCount()
        {
            return _context.Departments
                .Where(d => d.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Count();
        }

        public string TGetDepartmentNameByDepartmentId(byte departmentId)
        {
            return _context.Departments
                .Where(d => d.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .FirstOrDefault(x => x.DepartmentId == departmentId).DepartmentName
                .ToString();
        }
    }
}
