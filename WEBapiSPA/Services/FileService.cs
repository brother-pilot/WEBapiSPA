using System.IO;
using System.Reflection;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.Model;

namespace WEBapiSPA.Services
{
    public class FileService:IMessageFile
    {
        public string PathModel { get; }
        private readonly ILogger<FileService> log;

        public FileService(ILogger<FileService> logger)
        {
            PathModel = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            log = logger;
            //Console.WriteLine(pathExe);
        }

        public bool SaveMessages(List<Message> listItems)
        {
            var date = DateTime.Now.ToString().Replace(':', '_');
            var fileName = Path.Combine(PathModel, date + ".csv");
            try
            {
                var fs = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter streamW = new StreamWriter(fs);
                listItems.ForEach(m => streamW.WriteLine(m.ToString()));
                streamW.Close();
                log.LogInformation($"Messages was saved in file {date}.csv!");
                return true;
                    
            }
            catch (Exception e)
            {
                log.LogError(e,$"Messages can't be saved in file {date}.csv!");
                //throw new Exception("Не удалось сохранить данные в файл!");
                return false;
            }
        }

        public bool SaveFiles(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
