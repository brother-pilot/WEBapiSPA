namespace WEBapiSPA.Services
{
    public class LogService
    {
        // ILoggerFactory - тип, который используется для конфигурации системы логирования и создания экземпляров ILogger на основе
        // зарегистрированных провайдеров ILoggerProvider
        public LogService(ILoggerFactory factory)
        {
            //получаем логгер
            Logger = factory.CreateLogger("MyCategory");
        }

        //сохраняем в свойство и пользуемся
        public ILogger Logger { get; }

        

    }
}
