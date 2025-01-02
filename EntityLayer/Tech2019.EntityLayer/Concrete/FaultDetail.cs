using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class FaultDetail : IGenericEntity
    {
        public int FaultDetailId { get; set; }
        public int Action { get; set; }
        public string FaultProblem { get; set; }
        public string FaultDescription { get; set; }
        public decimal FaultPrePrice { get; set; }
        public decimal FaultNetPrice { get; set; }
        public string FaultOperation { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
