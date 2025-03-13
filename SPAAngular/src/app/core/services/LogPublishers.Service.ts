import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import {LogConsole } from "../../shared/logConsoler";
import { LogPublisher} from "../../shared/LogPublisher";
import { LogLocalStorage } from '../../shared/LogLocalStorage';
import { LogWebApi } from '../../shared/LogWebApi';

@Injectable()
export class LogPublishersService {

  //constructor() {
  //  // Build publishers arrays
  //  this.buildPublishers();
  //}

  constructor(private http: HttpClient) {
    // Build publishers arrays
    this.buildPublishers();
  }

  // Public properties
  publishers: LogPublisher[] = [];

  // Build publishers array
  buildPublishers(): void {
     //Create instance of LogConsole Class
    this.publishers.push(new LogConsole());

    // Create instance of `LogLocalStorage` Class
    this.publishers.push(new LogLocalStorage());

    // Create instance of `LogWebApi` Class
    this.publishers.push(new LogWebApi(this.http));
  }
}
