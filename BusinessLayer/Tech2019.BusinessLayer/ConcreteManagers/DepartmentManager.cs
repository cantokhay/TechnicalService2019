using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.DepartmentDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal context)
        {
            _departmentDal = context;
        }

        public void Create(Department entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _departmentDal.TCreate(entity);
        }

        public void Delete(Department entity)
        {
            entity.DeletedDate = DateTime.Now; 
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _departmentDal.TDelete(entity);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Department GetById(int id)
        {
            return _departmentDal.TGetById(id);
        }

        public int GetDepartmentCount()
        {
            return _departmentDal.TGetDepartmentCount();
        }

        public List<ResultDepartmentDTO> GetDepartments()
        {
            return _departmentDal.TGetDepartments();
        }

        public void Update(Department entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _departmentDal.TUpdate(entity);
        }
    }
}