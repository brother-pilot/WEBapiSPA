using System;
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
            DataInitializer();
        }

        private void DataInitializer()
        {
            var device1 = Guid.NewGuid();
            var seed = 1000;
            Random rnd = new Random(seed);
            for (int i = 0; i < 10; i++)
            {
                var m1 = new Message
                {
                    Id = Guid.NewGuid(),
                    Device = device1,
                    UserName = "User",
                    StartTime = new DateTime(rnd.Next(1990, 2000), rnd.Next(1, 12), rnd.Next(1, 28)),
                    EndTime = DateTime.Now,
                    VersionPA = "1.0.0.56"
                };
                mes.Add(m1);
            }
            var m2 = new Message
            {
                Id = Guid.NewGuid(),
                Device = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                UserName = "User",
                StartTime = new DateTime(rnd.Next(1990, 2000), rnd.Next(1, 12), rnd.Next(1, 28)),
                EndTime = DateTime.Now,
                VersionPA = "1.0.0.56"
            };
            mes.Add(m2);
        }

        public List<Message> GetListMessage(Guid devId)
        {
            var listMes = mes.Where(m => m.Device == devId).ToList();
            if (listMes.Count==0||listMes == null)
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

        public List<Message> GetListDevice()
        {
            var listDev = mes.GroupBy(m => m.Device)
                         .Select(m => m.First())
                         .ToList(); ;
            if (listDev == null)
            {
                throw new Exception($"No devices found!");
            }
            return listDev;
        }
    }
}
