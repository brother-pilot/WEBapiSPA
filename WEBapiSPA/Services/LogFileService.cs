using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using WEBapiSPA.DI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEBapiSPA.Services
{
    public class LogFileService : ILogger 
    {
        private static object _lock = new object();

        public IDisposable BeginScope<TState>(TState state)
        {
            return default!;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    var fileName = Path.Combine(logFilePath, "log.txt");
                    try
                    {
                        var fs = new FileStream(fileName, FileMode.Append);
                        StreamWriter streamW = new StreamWriter(fs);
                        streamW.WriteLine(DateTime.Now
                        +formatter(state, exception) + Environment.NewLine);
                        streamW.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message, $"Log's can't be saved in log file!");
                    }
                }
            }
        }


        private static string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        

        //public static class LogServiceExtention
        //{ 
        //public static void WriteLog<T>(this ILogger<T> logger, string method, string logMes)
        //{

        //    var fileName = Path.Combine(logFilePath, "log.txt");
        //    try
        //    {
        //        var fs = new FileStream(fileName, FileMode.OpenOrCreate);
        //        StreamWriter streamW = new StreamWriter(fs);
        //        streamW.WriteLine(logMes);
        //        streamW.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError(e, $"Log's can't be saved in log file!");
        //    }
        //}


    }
}
