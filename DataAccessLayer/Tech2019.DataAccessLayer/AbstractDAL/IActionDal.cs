using System.Collections.Generic;
using Tech2019.DTOLayer.ActionDTOs;
using Tech2019.DTOLayer.CustomerDTO;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IActionDal : IGenericDal<EntityLayer.Concrete.Action>
    {
        List<ResultActionDTO> TGetActions();
        List<ResultActionToChartDTO> TGetActionDataToChart();
        ResultCustomerInfoBySerialDTO TGetCustomerInfoBySerial(string productSerialNumber);
        bool TIsAnyActionBySerial(string productSerialNumber);
        int TGetActionCount();
        int TGetOnRepairActionCount();
        int TGetRepairFinishedActionCount();
        string TGetMostFaultyProductBrand();
        int TGetActionCountByPendingSparePartActionStatusDetail();
        int TGetActionCountByCancelledActionStatusDetail();
        int TGetActionCountByPendingCustomerApproveActionStatusDetail();
    }
}
