using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Reflection;
using WEBapiSPA.DI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEBapiSPA.Services
{
    public static class LogServiceExtension
    {
        // ILoggerFactory - тип, который используется для конфигурации системы логирования и создания экземпляров ILogger на основе
        // зарегистрированных провайдеров ILoggerProvider
        //public LogService(ILoggerFactory factory)
        //{
        //    //получаем логгер
        //    Logger = factory.CreateLogger("MyCategory");
        //}

        //public LogServiceExtension(ILogger<LogService> logger)
        //{
        //    Logger = logger;
        //}

        ////сохраняем в свойство и пользуемся
        //public ILogger Logger { get; }

        private static string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void WriteLog<T>(this ILogger<T> logger, string method, string logMes)
        {

            var fileName = Path.Combine(logFilePath, "log.txt");
            try
            {
                var fs = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter streamW = new StreamWriter(fs);
                streamW.WriteLine(logMes);
                streamW.Close();
            }
            catch (Exception e)
            {
                logger.LogError(e, $"Log's can't be saved in log file!");
            }
        }

        
    }
}
