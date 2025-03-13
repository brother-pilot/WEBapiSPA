import { Observable, of } from "rxjs";
import { LogPublisher } from "./LogPublisher";
import { OnInit } from "@angular/core";
import { LogMessage } from "../core/services/LogMessage";

export class LogLocalStorage extends LogPublisher {

  //localStorage: Storage;

  constructor() {
    // Must call `super()`from derived classes
    super();

    // Set location
    this.location = "fileLogging";
  }
    

  // Append log entry to local storage
  log(entry: LogMessage): Observable < boolean > {
    let ret: boolean = false;
    let values: LogMessage[];
   // let localStorage: Storage;
    try {

      let text = localStorage.getItem(this.location);
      if (text) { }
        else { text = JSON.stringify(""); }
      // Get previous values from local storage
      values = JSON. parse(text) || [];
      console.log(values);

      // Add new log entry to array
      values.push(entry);

      // Store array into local storage
      localStorage.setItem(this.location, JSON.stringify(values));

      // Set return value
      ret = true;
    } catch(ex) {
      // Display error in console
      console.log(ex);
    }
        
        return of(ret);
  }

  // Clear all log entries from local storage
  clear(): Observable < boolean > {
    localStorage.removeItem(this.location);
    return of(true);
  }
}
