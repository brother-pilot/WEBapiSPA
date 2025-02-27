using System.IO;
using WEBapiSPA.Services;

namespace WEBapiSPA.Providers
{
    public class LogFileServiceProvider : ILoggerProvider
    {
        public LogFileServiceProvider()
        {
            
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new LogFileService();
        }

        public void Dispose() { }
    }
}
