using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Create(Message entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _messageDal.TCreate(entity);
        }

        public void Delete(Message entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _messageDal.TDelete(entity);
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Message GetById(int id)
        {
            return _messageDal.TGetById(id);
        }

        public string GetMessageSenderNameAndTitleByOrder(int takeOrder)
        {
            return _messageDal.TGetMessageSenderNameAndTitleByOrder(takeOrder);
        }

        public void Update(Message entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _messageDal.TUpdate(entity);
        }
    }
}
