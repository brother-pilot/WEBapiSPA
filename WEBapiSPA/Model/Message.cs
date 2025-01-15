namespace WEBapiSPA.Model
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid Device { get; set; }
        public string UserName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string VersionPA { get; set; }
    }
}
