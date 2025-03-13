import { LogLevel } from "./LogLevel";


export class LogMessage {
  //класс для построения сообщения лога
  // Public Properties
  entryDate: Date = new Date();
  message: string = "";
  level: LogLevel = LogLevel.All;//
  extraInfo: any[] = [];
  logWithDate: boolean = true;//

  buildLogString(): string {
    let ret: string = "";

    if (this.logWithDate) {
      ret = new Date() + " - ";
    }

    ret += "Type: " + LogLevel[this.level];
    ret += " - Message: " + this.message;
    if (this.extraInfo.length) {
      ret += " - Extra Info: " + this.formatParams(this.extraInfo);
    }

    //{ "entryDate": "2025-03-13T06:19:21.094Z", "message": "Use loggerServ", "level": 0, "extraInfo": [], "logWithDate": true }
    return ret;
  }

  //create a comma-delimited list of the parameter array
  private formatParams(params: any[]): string {
    let ret: string = params.join(",");

    // Is there at least one object in the array?
    if (params.some(p => typeof p == "object")) {
      ret = "";

      // Build comma-delimited string
      for (let item of params) {
        ret += JSON.stringify(item) + ",";
      }
    }

    return ret;
  }

}
