import { Observable } from "rxjs";
import { LogEntry } from "./log.service";
import 'rxjs/add/observable/of';
import { LogPublisher } from "./LogPublisher";
//import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';


export class LogConsole extends LogPublisher {

  log(entry: LogEntry): Observable<boolean> {
    // Log to console
    console.log(entry.buildLogString());
    return Observable.of(true);
  }


      clear(): Observable < boolean > {
        console.clear();
        return Observable.of(true);
      }
}


export { LogPublisher };
