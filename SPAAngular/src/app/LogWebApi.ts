import { LogPublisher } from "./LogPublisher";




export class LogWebApi extends LogPublisher {
  constructor(private http: Http) {
    // Must call `super()`from derived classes
    super();

    // Set location
    this.location = "http://localhost:5000/log/";
  }

  // Add log entry to back end data store
  log(entry: LogEntry): Observable < boolean > {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return this.http.post(this.location, entry, options).map(response => response.json()).catch(this.handleErrors);
  }

  // Clear all log entries from local storage
  clear(): Observable < boolean > {
    // TODO: Call Web API to clear all values
    return Observable.of(true);
  }
    
    private handleErrors(error: any): Observable < any > {
    let errors: string[] = [];
    let msg: string = "";

    msg = "Status: " + error.status;
    msg += " - Status Text: " + error.statusText;
    if(error.json()) {
    msg += " - Exception Message: " + error.json().exceptionMessage;
  }
  errors.push(msg);

  console.error('An error occurred', errors);
  return Observable.throw(errors);
}
}
