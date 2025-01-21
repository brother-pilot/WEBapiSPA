import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { LogPublisher, LogWebApi } from "./log-publisher";
//import { LogPublisher, LogConsole, `LogLocalStorage`, LogWebApi } from "./log-publishers";

@Injectable()
export class LogPublishersService {

  //constructor() {
  //  // Build publishers arrays
  //  this.buildPublishers();
  //}

  constructor(private http: Http) {
    // Build publishers arrays
    this.buildPublishers();
  }

  // Public properties
  publishers: LogPublisher[] = [];

  // Build publishers array
  buildPublishers(): void {
    // Create instance of LogConsole Class
    //this.publishers.push(new LogConsole());

    // Create instance of `LogLocalStorage` Class
    //this.publishers.push(new `LogLocalStorage`());

    // Create instance of `LogWebApi` Class
    this.publishers.push(new LogWebApi(this.http));
  }
}
