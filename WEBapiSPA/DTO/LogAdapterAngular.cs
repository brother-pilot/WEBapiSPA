public class LogAdapterAngular
{
    //public DateTime EntryDate { get; set; }
    //public string Message { get; set; }
    //public LogLevel Level { get; set; }
    //public object[] ExtraInfo { get; set; }
    public LogLevel Level { get; set; }
    public object Additional { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public string FileName { get; set; }
    public int LineNumber { get; set; }
    public int ColumnNumber { get; set; }
}

//{ "level":5,"additional":[],"message":"Your log message goes here","timestamp":"2025-01-21T06:14:31.658Z","fileName":"main.js","lineNumber":351,"columnNumber":17}
/*
 {
  "entryDate": "2025-01-21T06:03:36.126Z",
  "message": "string",
  "level": 0,
  "extraInfo": [
    "string"
  ]
}
*/