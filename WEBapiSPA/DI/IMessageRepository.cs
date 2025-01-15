using WEBapiSPA.Model;

namespace WEBapiSPA.DI
{
    public interface IMessageRepository
    {
        Task<Message> GetListMessageAsync(Guid deviceId);
        Task<bool> SaveMessageAsync(Message mes);
    }
}
