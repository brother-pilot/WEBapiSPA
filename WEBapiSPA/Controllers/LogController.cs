using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;

namespace WEBapiSPA.Controllers
{
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

            log.LogInformation($"Search request from angular part!");

            // Return OK for now
            ret = Ok(true);

            return ret;
        }
    }
    
}
