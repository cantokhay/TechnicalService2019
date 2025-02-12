using System.Collections.Generic;
using Tech2019.DTOLayer.NoteDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface INoteDal : IGenericDal<Note>
    {
        List<ResultReadNoteDTO> TGetReadNotes();
        List<ResultUnreadNoteDTO> TGetUnreadNotes();
        List<NotesTodayDueDateDTO> TGetNotesTodayDueDate();
    }
}
