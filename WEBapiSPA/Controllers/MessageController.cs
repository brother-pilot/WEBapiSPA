using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //GET: MessageController
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }



    }
}
