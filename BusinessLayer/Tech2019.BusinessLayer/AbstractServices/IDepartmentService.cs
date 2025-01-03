using System.Collections.Generic;
using Tech2019.DTOLayer.DepartmentDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IDepartmentService : IGenericService<Department>
    {
        List<ResultDepartmentDTO> GetDepartments();
        int GetDepartmentCount();
    }
}
