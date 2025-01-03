using System.Collections.Generic;
using Tech2019.DTOLayer.DepartmentDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IDepartmentDal : IGenericDal<Department>
    {
        List<ResultDepartmentDTO> TGetDepartments();
        int TGetDepartmentCount();
    }
}
