using System.Collections.Generic;
using Tech2019.DTOLayer.ActionDTOs;
using Tech2019.DTOLayer.CustomerDTO;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IActionService : IGenericService<EntityLayer.Concrete.Action>
    {
        List<ResultActionDTO> GetActions();
        List<ResultActionToChartDTO> GetActionDataToChart();
        ResultCustomerInfoBySerialDTO GetCustomerInfoBySerial(string productSerialNumber);
        bool IsAnyActionBySerial(string productSerialNumber);
        int GetActionCount();

    }
}
