using Microsoft.AspNetCore.Mvc;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.Model;

namespace WEBapiSPA.Controllers
{
    public class FileController : Controller
    {
        private IMessageFile MF { get; }
        private IMessageMemory MM { get; }
        private readonly ILogger<MessageMemory> log;

        public FileController(
            IMessageFile messageFile, 
            IMessageMemory messageMemory, 
            ILogger<MessageMemory> logger)
        {
            log = logger;
            MM= messageMemory;
            MF = messageFile;
        }

        [HttpPost]
        public IActionResult SaveMessages()
        {
            var res = MF.SaveMessages(MM.GetListMessage());
            if (res)
                log.LogInformation($"Messages was saved in file!");
            else
                log.LogError($"Messages can't be saved in file!");
            return res ? Ok() : View("Can't save messages in file!");
        }
    }
}
