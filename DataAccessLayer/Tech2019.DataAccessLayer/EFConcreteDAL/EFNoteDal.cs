using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.NoteDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFNoteDal : EFGenericDal<Note>, INoteDal
    {
        private readonly TechDBContext _context;
        public EFNoteDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultReadNoteDTO> TGetReadNotes()
        {
            return _context.Notes.Where(n => n.DataStatus != EntityLayer.Enum.DataStatus.Deleted && n.NoteStatus == EntityLayer.Enum.NoteStatus.Read).Select(x => new ResultReadNoteDTO
            {
                NoteId = x.NoteId,
                NoteTitle = x.NoteTitle,
                NoteDescription = x.NoteDescription,
                NoteStatus = x.NoteStatus.ToString(),
                DueDate = x.DueDate
            }).ToList();
        }

        public List<ResultUnreadNoteDTO> TGetUnreadNotes()
        {
            return _context.Notes.Where(n => n.DataStatus != EntityLayer.Enum.DataStatus.Deleted && n.NoteStatus == EntityLayer.Enum.NoteStatus.Unread).Select(x => new ResultUnreadNoteDTO
            {
                NoteId = x.NoteId,
                NoteTitle = x.NoteTitle,
                NoteDescription = x.NoteDescription,
                NoteStatus = x.NoteStatus.ToString(),
                DueDate = x.DueDate
            }).ToList();
        }
    }
}
