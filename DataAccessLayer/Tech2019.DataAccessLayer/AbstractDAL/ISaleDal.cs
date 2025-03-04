﻿using System.Collections.Generic;
using Tech2019.DTOLayer.SaleDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface ISaleDal : IGenericDal<Sale>
    {
        List<ResultSaleDTO> TGetSales();
    }
}
