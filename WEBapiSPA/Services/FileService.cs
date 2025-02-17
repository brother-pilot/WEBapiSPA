using System.IO;
using System.Reflection;
using WEBapiSPA.Model;

namespace WEBapiSPA.Services
{
    public class FileService
    {
        public string PathModel { get; }

        public FileService()
        {
            PathModel = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Console.WriteLine(pathExe);
        }

        public bool WriteData(List<Message> listItems)
        {
            var fileName = Path.Combine(PathModel, DateTime.Now + ".csv");
            try
            {
                var fs = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter streamW = new StreamWriter(fs);
                listItems.ForEach(m => streamW.WriteLine(m.ToString()));
                streamW.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Не удалось сохранить данные в файл!");
                return false;
            }
        }
    }
}
