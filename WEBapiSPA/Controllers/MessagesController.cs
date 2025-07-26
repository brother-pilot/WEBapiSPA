using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.Model;

namespace WEBapiSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : Controller
    {

        private IMessageMemory MM { get; }
        private readonly ILogger<MessageMemory> log;

        public MessagesController(IMessageMemory messageMemory, ILogger<MessageMemory> logger)
        {
            log = logger;
            MM = messageMemory;
        }
        //TO DO: сообщения логов выводятся от сервиса MessageMemory, а не от MessageController

        //public MessageController()
        //{

        //}

        /// <summary>
        /// Получение списка устройств
        /// </summary>
        /// /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /messages
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение или пустой список устройств при ошибке</response>
        //GET: MessageController
        [HttpGet]
        public IEnumerable<Message> Index()
        {      
            var res = MM.GetListDevice().ToArray();
            if (res.Length != 0)
                log.LogInformation($"Search request to find devices is done!");
            else
                log.LogError($"Search request to find devices. No devices found!");
            return res;
        }

        /// <summary>
        /// Получение списка сообщений для выбранного устройства
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /messages/3fa85f64-5717-4562-b3fc-2c963f66afa6
        ///
        /// </remarks>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение или пустой список сообщений при ошибке</response>
        [HttpGet("{deviceId:guid}")]
        public IEnumerable<Message> GetListMessage(Guid deviceId)
        {
            try
            {
                var res= MM.GetListMessage(deviceId).ToArray();
                if (res.Length!=0)
                    log.LogInformation($"Search request to find messages for device {deviceId} is done!");
                else
                    log.LogError($"Search request to find messages for device {deviceId}. No messages found!");
                return res;
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return new List<Message>();
            }
        }

        /// <summary>
        /// Сохранение сообщения об устройстве в оперативную память
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /messages
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "device": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "userName": "User",
        ///         "startTime": "2025-07-26T10:05:53.705Z",
        ///         "endTime": "2025-07-26T10:05:53.705Z",
        ///         "versionPA": "1.0.0.56"
        ///     }
        ///
        /// </remarks>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="500">Ошибка сохранения сообщения в оперативную память</response>
        [HttpPost]
        public IActionResult SaveMessage(Message message)
        {
            var res = MM.SaveMessage(message);
            if (res)
                log.LogInformation($"Message {message.Id} was saved!");
            else
                log.LogError($"Message {message.Id} can't be saved!");
            return res ? Ok() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Удаление сообщений старее заданной даты
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /messages/delete
        ///     {
        ///         "2020-07-26T10:05:53.705Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="500">Ошибка удаления сообщения</response>
        [HttpPost("delete")]
        //[HttpPost]
        public IActionResult DeleteMessage([FromBody]DateTime dateTime)
        {
            var res = MM.DellMessageOlderDate(dateTime);
            if (res)
                log.LogInformation($"Message {dateTime} was removed!");
            else
                log.LogError($"Message {dateTime} can't be removed!");
            return res ? Ok() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
