using Tech2019.EntityLayer.Enum;

namespace Tech2019.DTOLayer.NoteDTOs
{
    public class ResultUnreadNoteDTO
    {
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteDescription { get; set; }
        public string NoteStatus { get; set; }
    }
}
