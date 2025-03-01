﻿using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.EmployeeDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Create(Employee entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _employeeDal.TCreate(entity);
        }

        public void Delete(Employee entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _employeeDal.TDelete(entity);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.TGetById(id);
        }

        public int GetEmployeeCount()
        {
            return _employeeDal.TGetEmployeeCount();
        }

        public string GetMaxEmployeeDepartment()
        {
            return _employeeDal.TGetMaxEmployeeDepartment();
        }

        public string GetMinEmployeeDepartment()
        {
            return _employeeDal.TGetMinEmployeeDepartment();
        }

        public Employee GetFirstEmployeeByDepartmentId(byte departmentId)
        {
            return _employeeDal.TGetFirstEmployeeByDepartmentId(departmentId);
        }

        public void Update(Employee entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _employeeDal.TUpdate(entity);
        }

        public List<EmployeeWithDepartmentDTO> GetEmployeesByDepartments()
        {
            return _employeeDal.TGetEmployeesByDepartments();
        }

        public List<EmployeeToSaleDTO> GetEmployeesToSale()
        {
            return _employeeDal.TGetEmployeesToSale();
        }

        public List<EmployeeToInvoiceDTO> GetEmployeesToInvoice()
        {
            return _employeeDal.TGetEmployeesToInvoice();
        }
    }
}
