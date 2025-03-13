import { Observable, of } from "rxjs";
import { LogPublisher } from "./LogPublisher";
import { LogMessage } from "../core/services/LogMessage";
//import { Http, Response, Headers, RequestOptions } from '@angular/http';


export class LogConsole extends LogPublisher {
  //override location = "Console";
  constructor() {
    // Must call `super()`from derived classes
    super();

    // Set location
    this.location = "Console";
  }

  log(entry: LogMessage): Observable<boolean> {
    // Log to console
    console.log(entry.buildLogString());
    return of(true); //всегда возращаем обзевебл тру
  }

      clear(): Observable < boolean > {
        console.clear();
        return of(true);
      }
}


export { LogPublisher };
