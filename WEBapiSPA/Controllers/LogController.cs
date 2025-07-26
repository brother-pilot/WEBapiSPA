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
        /// <summary>
        /// Контроллер для получений сообщений от NGXLogger
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /log
        ///     {
        ///        "level": 5,
        ///        "additional": "somising additional information",
        ///        "message": "Your log message",
        ///        "timestamp": "2025-07-26T10:17:53.899Z",
        ///        "fileName": "main.js",
        ///        "lineNumber": 300,
        ///        "columnNumber": 20
        ///     }
        ///     
        /// </remarks>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <response code="200">Всегда ответ об успешном выполении</response>
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] LogAdapterAngularNGXLorrer value)
        {
            IActionResult ret;
            log.LogInformation("*********Search request from angular part!**********\n" +
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

        /// <summary>
        /// Контроллер для получений сообщений от сервиса LoggerService
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /log/loggerServ
        ///     {
        ///       "entryDate":"2025-03-13T06:19:21.094Z",
        ///       "message":"Use loggerServ",
        ///       "level":0,
        ///       "extraInfo":[
        ///       "somising additional information"
        ///       ]
        ///     }
        ///     
        /// </remarks>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <response code="200">Всегда ответ об успешном выполении</response>
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
