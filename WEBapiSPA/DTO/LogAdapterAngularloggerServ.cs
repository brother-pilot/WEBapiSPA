namespace WEBapiSPA.DTO
{
    public class LogAdapterAngularloggerServ
    {
        public DateTime EntryDate { get; set; }
        public string Message { get; set; }
        public LogLevel Level { get; set; }
        public object[] ExtraInfo { get; set; }
    }

    //{"entryDate":"2025-03-13T06:19:21.094Z","message":"Use loggerServ","level":0,"extraInfo":[],"logWithDate":true}
}
