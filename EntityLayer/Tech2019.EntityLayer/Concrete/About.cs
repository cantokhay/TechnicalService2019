using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class About : IGenericEntity
    {
        public int AboutId { get; set; }
        public string AboutDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
