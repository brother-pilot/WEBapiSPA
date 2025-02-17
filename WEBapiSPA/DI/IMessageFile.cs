using WEBapiSPA.Model;

namespace WEBapiSPA.DI
{
    public interface IMessageFile
    {
        bool SaveMessages(List<Message> messages);
    }
}
