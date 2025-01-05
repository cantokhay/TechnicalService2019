using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.NoteDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public void Create(Note entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _noteDal.TCreate(entity);
        }

        public void Delete(Note entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _noteDal.TDelete(entity);
        }

        public IEnumerable<Note> GetAll()
        {
            return _noteDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Note GetById(int id)
        {
            return _noteDal.TGetById(id);
        }

        public List<ResultReadNoteDTO> GetReadNotes()
        {
            return _noteDal.TGetReadNotes();
        }

        public List<ResultUnreadNoteDTO> GetUnreadNotes()
        {
            return _noteDal.TGetUnreadNotes();

        }

        public void Update(Note entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _noteDal.TUpdate(entity);
        }
    }
}
