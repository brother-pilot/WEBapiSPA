using WEBapiSPA.Model;

namespace WEBapiSPA.DI
{
    public interface IMessageMemory
    {
        public List<Message> GetListMessage();
        public List<Message> GetListMessage(Guid deviceId);
        public List<Message> GetListDevice();
        bool SaveMessage(Message message);
        bool DellMessageOlderDate(DateTime dateTime);
    }
}