using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Message : IGenericEntity
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
