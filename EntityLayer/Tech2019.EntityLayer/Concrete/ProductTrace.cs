using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class ProductTrace : IGenericEntity
    {
        public int ProductTraceId { get; set; }
        public DateTime ProductTraceDate { get; set; }
        public string ProductSerialNumber { get; set; }
        public string ProductTraceInformation { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }

}
