﻿using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IMessageDal : IGenericDal<Message>
    {
        string TGetMessageSenderNameAndTitleByOrder(int takeOrder);
    }
}
