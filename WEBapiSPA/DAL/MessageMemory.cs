using System;
using WEBapiSPA.DI;
using WEBapiSPA.Model;
using WEBapiSPA.Services;

namespace WEBapiSPA.DAL
{
    public class MessageMemory : IMessageMemory
    {
        private readonly List<Message> mes;
        private readonly ILogger<MessageMemory> log;

        public MessageMemory(ILogger<MessageMemory> logger)
        {
            log = logger;
            mes = new List<Message>();
            DataInitializer();
        }

        private void DataInitializer()
        {
            var device1 = Guid.NewGuid();
            var seed = 1000;
            Random rnd = new Random(seed);
            for (int i = 0; i < 100; i++)
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
            log.LogInformation("Initial data were created!");
        }

        public List<Message> GetListMessage(Guid devId)
        {
            var listMes = mes.Where(m => m.Device == devId).ToList();
            if (listMes.Count==0||listMes == null)
            {
                log.LogError($"Messages for device {devId} not found!");
                throw new Exception($"Messages for device {devId} not found!");
            }
            log.LogInformation($"List messages with device id {devId} is recieved!");
            return listMes;
        }


        public bool SaveMessage(Message message)
        {
            try
            {
                mes.Add(message);
                log.LogInformation($"Message {message.Id} was saved!");
                return true;
            }
            catch (Exception)
            {
                log.LogError($"Message {message.Id} can't be saved!");
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
                log.LogError($"No devices found!");
                throw new Exception($"No devices found!");
            }
            log.LogInformation($"List devices is recieved!");
            return listDev;
        }

        public bool DellMessageOlderDate(DateTime dateTime)
        {
            try
            {
                mes.RemoveAll(m=>m.StartTime<=dateTime|| m.EndTime <= dateTime);
                log.LogInformation($"Message older {dateTime} was removed!");
                return true;
            }
            catch (Exception)
            {
                log.LogError($"Message older {dateTime} can't be removed!");
                return false;
            }
        }
    }
}
