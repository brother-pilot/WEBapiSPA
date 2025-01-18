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
        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 2).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = "sddd"
        //    })
        //    .ToArray();
        //}

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
        public List<Message> Index()
        {        
            return MM.GetListDevice();
        }

        [HttpGet("{deviceId:guid}")]
        public List<Message> GetListMessage(Guid deviceId)
        {
            try
            {
                return MM.GetListMessage(deviceId);
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
