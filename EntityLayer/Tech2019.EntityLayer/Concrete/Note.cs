using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Note : IGenericEntity
    {
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteDescription { get; set; }
        public NoteStatus NoteStatus { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
