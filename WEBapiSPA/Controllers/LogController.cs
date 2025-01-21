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
        private readonly ILogger<MessageMemory> log;

        public LogController(ILogger<MessageMemory> logger)
        {
            log = logger;
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] LogEntry value)
        {
            IActionResult ret;

            log.LogError($"Search request from angular part!");
            log.LogError("Level: "+value.Level.ToString()+
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
