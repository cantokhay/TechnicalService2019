using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.ActionDTOs;
using Tech2019.DTOLayer.CustomerDTO;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class ActionManager : IActionService
    {
        private readonly IActionDal _actionDal;

        public ActionManager(IActionDal actionDal)
        {
            _actionDal = actionDal;
        }

        public void Create(EntityLayer.Concrete.Action entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _actionDal.TCreate(entity);
        }

        public void Delete(EntityLayer.Concrete.Action entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _actionDal.TDelete(entity);
        }

        public List<ResultActionDTO> GetActions()
        {
            return _actionDal.TGetActions();
        }

        public IEnumerable<EntityLayer.Concrete.Action> GetAll()
        {
            return _actionDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public EntityLayer.Concrete.Action GetById(int id)
        {
            return _actionDal.TGetById(id);
        }

        public List<ResultActionToChartDTO> GetActionDataToChart()
        {
            return _actionDal.TGetActionDataToChart();
        }

        public void Update(EntityLayer.Concrete.Action entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _actionDal.TUpdate(entity);
        }

        public ResultCustomerInfoBySerialDTO GetCustomerInfoBySerial(string productSerialNumber)
        {
            return _actionDal.TGetCustomerInfoBySerial(productSerialNumber);
        }

        public bool IsAnyActionBySerial(string productSerialNumber)
        {
            return _actionDal.TIsAnyActionBySerial(productSerialNumber);
        }

        public int GetActionCount()
        {
            return _actionDal.TGetActionCount();
        }

        public int GetOnRepairActionCount()
        {
            return _actionDal.TGetOnRepairActionCount();
        }

        public int GetRepairFinishedActionCount()
        {
            return _actionDal.TGetRepairFinishedActionCount();
        }

        public string GetMostFaultyProductBrand()
        {
            return _actionDal.TGetMostFaultyProductBrand();
        }

        public int GetActionCountByPendingSparePartActionStatusDetail()
        {
            return _actionDal.TGetActionCountByPendingSparePartActionStatusDetail();
        }

        public int GetActionCountByCancelledActionStatusDetail()
        {
            return _actionDal.TGetActionCountByCancelledActionStatusDetail();

        }

        public int GetActionCountByPendingCustomerApproveActionStatusDetail()
        {
            return _actionDal.TGetActionCountByPendingCustomerApproveActionStatusDetail();

        }
    }
}
