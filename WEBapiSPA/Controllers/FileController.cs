using Microsoft.AspNetCore.Mvc;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.Model;

namespace WEBapiSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private IMessageFile MF { get; }
        private IMessageMemory MM { get; }
        private readonly ILogger<FileController> log;

        public FileController(
            IMessageFile messageFile, 
            IMessageMemory messageMemory, 
            ILogger<FileController> logger)
        {
            log = logger;
            MM= messageMemory;
            MF = messageFile;
        }

        [HttpHead]
        public IActionResult SaveMessages()
        {
            var res = MF.SaveMessages(MM.GetListMessage());
            if (res)
                log.LogInformation($"Messages was saved in file!");
            else
                log.LogError($"Messages can't be saved in file!");
            return res ? Ok() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
