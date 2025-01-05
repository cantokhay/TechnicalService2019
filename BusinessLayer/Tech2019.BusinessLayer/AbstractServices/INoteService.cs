using System.Collections.Generic;
using Tech2019.DTOLayer.NoteDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface INoteService : IGenericService<Note>
    {
        List<ResultReadNoteDTO> GetReadNotes();
        List<ResultUnreadNoteDTO> GetUnreadNotes();
    }
}
