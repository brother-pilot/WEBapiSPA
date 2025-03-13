import { LogLevel } from "./LogLevel";
import { LogPublisher } from "../../shared/logConsoler";
import { LogPublishersService } from "./LogPublishers.Service";
import { Injectable } from "@angular/core";
import { LogMessage } from "./LogMessage";

@Injectable()
export class LogService {
  level: LogLevel = LogLevel.All;//
  extraInfo: any[] = [];
  logWithDate: boolean = true;//
  publishers: LogPublisher[] = [];

  constructor(private publishersService: LogPublishersService) {
    // Set publishers куда будем делать логгирование(консоль, файл, емайл)
    this.publishers = this.publishersService.publishers;
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
      let entry: LogMessage = new LogMessage();
      entry.message = msg;
      entry.level = level;
      entry.extraInfo = params;
      entry.logWithDate = this.logWithDate;
      //console.log(entry.buildLogString());
      for (let logger of this.publishers) {
        logger.log(entry).subscribe(response => console.log("Logging in "+logger.location+": "+response));
      }
    }
  }

  /*
  The shouldLog() method determines if logging should occur based on the level property set in the
  LogService class. This service is created as a singleton by Angular, so once this level property is
  set, it remains that value until you change it in your application. The shouldLog() checks the
  parameter passed in against the level property set in the LogService class. If the level passed in
  is greater than or equal to the level property, and logging is not turned off, then a true value is
  returned from this method. A true return value tells the writeToLog() method to log the message.
  */
  private shouldLog(level: LogLevel): boolean {
    let ret: boolean = false;
    if ((level >= this.level && level !== LogLevel.Off) || this.level === LogLevel.All) {
      ret = true;
    }
    return ret;
  }

  logM(msg: any) {
    console.log(new Date() + ": " + JSON.stringify(msg));
  }
}
