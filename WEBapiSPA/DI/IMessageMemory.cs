using WEBapiSPA.Model;

namespace WEBapiSPA.DI
{
    public interface IMessageMemory
    {
        public List<Message> GetListMessage(Guid deviceId);
        bool SaveMessage(Message message);
    }
}