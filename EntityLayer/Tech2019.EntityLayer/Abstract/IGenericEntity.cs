using System;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Abstract
{
    public interface IGenericEntity
    {
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime? DeletedDate { get; set; }
        DataStatus DataStatus { get; set; }
    }
}