using Microsoft.AspNetCore.Mvc.Filters;
using WEBapiSPA.Model;
using WEBapiSPA.Services;

namespace WEBapiSPA.Filters
{
    /// <summary>
    /// It just logging of start and finish methods of controllers.
    /// </summary>
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string message = $"Action '{context.ActionDescriptor.DisplayName}' is starting.";
            WriteLog(message);
            //  Этот метод выполняется до метода контроллера
            _logger.LogInformation(message);
        }

        private void WriteLog(string message)
        {
            StreamWriter streamWriter = new StreamWriter("App_Data/log.txt", true);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string message = $"Action '{context.ActionDescriptor.DisplayName}' has completed.";
            WriteLog(message);
            // Этот метод выполняется после метода контроллера
            _logger.LogInformation(message);
        }

    }
}
