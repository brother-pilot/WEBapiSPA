using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.DTO;
using WEBapiSPA.Services;

namespace WEBapiSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : Controller
    {
        private readonly ILogger<LogController> log;

        public LogController(ILogger<LogController> logger)
        {
            log = logger;
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] LogAdapterAngularNGXLorrer value)
        {
            IActionResult ret;
            log.LogInformation("*********Search request from angular part!**********\n"+
                "Level: " + value.Level.ToString() +
                " Additional: " + value.Additional.ToString() +
                " Message: " + value.Message +
                " Timestamp: " + value.Timestamp +
                " FileName : " + value.FileName +
                " LineNumber: " + value.LineNumber +
                " ColumnNumber: " + value.ColumnNumber
                );

            // Return OK for now
            ret = Ok(true);

            return ret;
        }

        [HttpPost("loggerServ")]
        public IActionResult Post([FromBody] LogAdapterAngularloggerServ value)
        {
            IActionResult ret;
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.WriteLine("*****************");
            //Console.BackgroundColor = ConsoleColor.Black;
            log.LogInformation("***************** Search request from angular part service loggerServ!\n" +
                "Level: " + value.Level.ToString() +
                " Message: " + value.Message +
                " Timestamp: " + value.EntryDate +
                " Additional: " + value.ExtraInfo.ToString()
                );

            // Return OK for now
            ret = Ok(true);
            //ret = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return ret;
        }
    }
    
}
