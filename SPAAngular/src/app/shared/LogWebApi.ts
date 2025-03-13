import { HttpClient } from '@angular/common/http';

import { Observable, delay, of, throwError } from "rxjs";
import { LogPublisher } from "./LogPublisher";
import { LogMessage } from '../core/services/LogMessage';




export class LogWebApi extends LogPublisher {

  public isResponceFromPost: boolean = false;

  constructor(private http: HttpClient) {
    // Must call `super()`from derived classes
    super();

    // Set location
    this.location = "http://localhost:5000/log/loggerServ";
  }

  // Add log entry to back end data store
  log(entry: LogMessage): Observable < boolean > {
    this.http.post(this.location, entry)
      .subscribe(
        response => {
          this.isResponceFromPost = true;
          console.log("response:" + response + "isResponceFromPost: " + this.isResponceFromPost);        },
        error => {
          this.handleErrors(error);
          console.log("responseError:" + error + "isResponceFromPost: " + this.isResponceFromPost);
          this.isResponceFromPost = true;
        });
    return of(true);
  }

  // Clear all log entries from local storage
  clear(): Observable < boolean > {
    // TODO: Call Web API to clear all values
    return of(true);
  }
    
    private handleErrors(error: any): Observable < any > {
    let errors: string[] = [];
    let msg: string = "";
    msg = "Status error: " + error.status;
    msg += " - Status Text: " + error.statusText;
    if(error.json()) {
    msg += " - Exception Message: " + error.json().exceptionMessage;
  }
  errors.push(msg);

  console.error('An error occurred', errors);
      return throwError(errors); //Observable.throw(errors);
}
}
