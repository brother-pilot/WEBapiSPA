using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEBapiSPA.Services
{
    public  class  LogService
    {
        // ILoggerFactory - тип, который используется для конфигурации системы логирования и создания экземпляров ILogger на основе
        // зарегистрированных провайдеров ILoggerProvider
        //public LogService(ILoggerFactory factory)
        //{
        //    //получаем логгер
        //    Logger = factory.CreateLogger("MyCategory");
        //}

        public LogService(ILogger<FileService> logger)
        {
            Logger = logger;
        }

        //сохраняем в свойство и пользуемся
        public ILogger Logger { get; }

        private static string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);;

        public void WriteLog(string logMes)
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
                Logger.LogError(e, $"Log's can't be saved in log file!");
            }
        }



    }
}
