using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
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
            string message = $"Action '{context.ActionDescriptor.DisplayName}' is starting in {DateTime.Now}.";
            WriteLog(message);
            //  Этот метод выполняется до метода контроллера
            _logger.LogInformation(message);
        }

        //сохранение специально сделано в отдельный файл, для демострации работы фильтра
        private void WriteLog(string message)
        {
            var fileName = Path.Combine(logFileFilterPath, "logFilter.txt");
            try
            {
                StreamWriter streamWriter = new StreamWriter(fileName, true);
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Can't save log file!");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string message = $"Action '{context.ActionDescriptor.DisplayName}' has completed in {DateTime.Now}.";
            WriteLog(message);
            // Этот метод выполняется после метода контроллера
            _logger.LogInformation(message);
        }

        private static string logFileFilterPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    }
}
