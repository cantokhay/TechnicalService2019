using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IMessageService : IGenericService<Message>
    {
        string GetMessageSenderNameAndTitleByOrder(int takeOrder);
    }
}
