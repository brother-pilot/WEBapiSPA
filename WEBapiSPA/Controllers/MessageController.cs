using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.Model;

namespace WEBapiSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {

        private IMessageMemory MM { get; }
        private readonly ILogger<MessageMemory> log;

        public MessageController(IMessageMemory messageMemory, ILogger<MessageMemory> logger)
        {
            log = logger;
            MM = messageMemory;
        }
        //TO DO: сообщения логов выводятся от сервиса MessageMemory, а не от MessageController

        //public MessageController()
        //{

        //}

        //GET: MessageController
        [HttpGet]
        public IEnumerable<Message> Index()
        {
            var res = MM.GetListDevice().ToArray();
            if (res.Length != 0)
                log.LogInformation($"Search request to find devices is done!");
            else
                log.LogError($"Search request to find devices. No devices found!");
            return res;
        }

        [HttpGet("{deviceId:guid}")]
        public IEnumerable<Message> GetListMessage(Guid deviceId)
        {
            try
            {
                var res= MM.GetListMessage(deviceId).ToArray();
                if (res.Length!=0)
                    log.LogInformation($"Search request to find messages for device {deviceId} is done!");
                else
                    log.LogError($"Search request to find messages for device {deviceId}. No messages found!");
                return res;
            }
            catch (Exception)
            {
                log.LogError($"Search request to find messages for device {deviceId}. Internal server error!");
                return new List<Message>();
            }
        }

        [HttpPost]
        public IActionResult SaveMessage(Message message)
        {
            var res = MM.SaveMessage(message);
            if (res)
                log.LogInformation($"Message {message.Id} was saved!"); 
            else
                log.LogError($"Message {message.Id} can't be saved!");
            return res?Ok(): View("Can't save message!");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(DateTime dateTime)
        {
            var res = MM.DellMessageOlderDate(dateTime);
            if (res)
                log.LogInformation($"Message {dateTime} was removed!");
            else
                log.LogError($"Message {dateTime} can't be removed!");
            return res ? Ok() : View("Can't delete message!");
        }
    }
}
