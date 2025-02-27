using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;

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
        public IActionResult Post([FromBody] LogEntry value)
        {
            IActionResult ret;

            //ConsoleColor.Green;
            log.LogInformation($"Search request from angular part!");
            log.LogInformation("Level: "+value.Level.ToString()+
                " Additional: "+value.Additional.ToString()+
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
    }
    
}
