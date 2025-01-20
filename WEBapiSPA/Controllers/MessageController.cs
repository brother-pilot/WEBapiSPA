using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBapiSPA.DI;
using WEBapiSPA.Model;

namespace WEBapiSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {

        private IMessageMemory MM { get; }

        public MessageController(IMessageMemory messageMemory)
        {
            MM = messageMemory;
        }

        //public MessageController()
        //{
            
        //}

        //GET: MessageController
        [HttpGet]
        public IEnumerable<Message> Index()
        {        
            return MM.GetListDevice().ToArray();
        }

        [HttpGet("{deviceId:guid}")]
        public IEnumerable<Message> GetListMessage(Guid deviceId)
        {
            try
            {
                return MM.GetListMessage(deviceId).ToArray();
            }
            catch (Exception)
            {
                return new List<Message>();
            }
        }

        [HttpPost]
        public IActionResult SaveMessage(Message message)
        {
            return MM.SaveMessage(message)?Ok(): View("Can't save message!");
        }


    }
}
