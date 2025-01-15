using WEBapiSPA.DI;
using WEBapiSPA.Model;

namespace WEBapiSPA.DAL
{
    public class MessageMemory : IMessageMemory
    {
        private readonly List<Message> mes;

        public MessageMemory()
        {
            mes = new List<Message>();
        }

        public List<Message> GetListMessage(Guid devId)
        {
            var listMes = mes.Where(m => m.Device == devId).ToList();
            if (listMes == null)
            {
                throw new Exception($"Device with id {devId} not found!");
            }
            return listMes;
        }


        public bool SaveMessage(Message message)
        {
            try
            {
                mes.Add(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
