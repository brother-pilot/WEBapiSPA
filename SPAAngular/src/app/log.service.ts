import { LogLevel } from "./LogLevel";
import { LogPublisher } from "./log-publisher";
import { LogPublishersService } from "./LogPublishers.Service";


export class LogEntry {
  // Public Properties
  entryDate: Date = new Date();
  message: string = "";
  level: LogLevel = LogLevel.All;
  extraInfo: any[] = [];
  logWithDate: boolean = true;
  publishers: LogPublisher[] = [];

  constructor(private publishersService: LogPublishersService) {
    // Set publishers
    this.publishers = this.publishersService.publishers;
  }

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

    return ret;
  }

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

  debug(msg: string, ...optionalParams: any[]) {
    this.writeToLog(msg, LogLevel.Debug, optionalParams);
  }

  info(msg: string, ...optionalParams: any[]) {
    this.writeToLog(msg, LogLevel.Info, optionalParams);
  }

  warn(msg: string, ...optionalParams: any[]) {
    this.writeToLog(msg, LogLevel.Warn, optionalParams);
  }

  error(msg: string, ...optionalParams: any[]) {
    this.writeToLog(msg, LogLevel.Error, optionalParams);
  }

  fatal(msg: string, ...optionalParams: any[]) {
    this.writeToLog(msg, LogLevel.Fatal, optionalParams);
  }

  log(msg: string, ...optionalParams: any[]) {
    this.writeToLog(msg, LogLevel.All, optionalParams);
  }

  private writeToLog(msg: string, level: LogLevel, params: any[]) {
    if (this.shouldLog(level)) {
      let value: string = "";

      // Build log string
      if (this.logWithDate) {
        value = new Date() + " - ";
      }

      value += "Type: " + LogLevel[this.level];
      value += " - Message: " + msg;
      if (params.length) {
        value += " - Extra Info: " + this.formatParams(params);
      }

      for (let logger of this.publishers) {
        logger.log(value).subscribe(response => console.log(response));
      }
      // Log the value
      console.log(value);
    }
  }

  private shouldLog(level: LogLevel): boolean {
    let ret: boolean = false;
    if ((level >= this.level && level !== LogLevel.Off) || this.level === LogLevel.All) {
      ret = true;
    }
    return ret;
  }
}

export class LogService {
  log(msg: any) {
    console.log(new Date() + ": " + JSON.stringify(msg));
  }
}

//export class LogEntry {
//  // Public Properties
//  entryDate: Date = new Date();
//  message: string = "";
//  level: LogLevel = LogLevel.Debug;
//  extraInfo: any[] = [];
//  logWithDate: boolean = true;

//  buildLogString(): string {
//    let ret: string = "";

//    if (this.logWithDate) {
//      ret = new Date() + " - ";
//    }

//    ret += "Type: " + LogLevel[this.level];
//    ret += " - Message: " + this.message;
//    if (this.extraInfo.length) {
//      ret += " - Extra Info: " + this.formatParams(this.extraInfo);
//    }

//    return ret;
//  }

//  private formatParams(params: any[]): string {
//    let ret: string = params.join(",");

//    // Is there at least one object in the array?
//    if (params.some(p => typeof p == "object")) {
//      ret = "";

//      // Build comma-delimited string
//      for (let item of params) {
//        ret += JSON.stringify(item) + ",";
//      }
//    }

//    return ret;
//  }
//}
