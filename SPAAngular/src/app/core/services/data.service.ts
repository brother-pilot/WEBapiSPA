import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Message } from '../model/message';
import { NGXLogger } from "ngx-logger";
import { LogService } from './log.service';


@Injectable()
export class DataService {

  private url = "http://localhost:5000/message/";

  constructor(private http: HttpClient,
    private logger: NGXLogger,
    private loggerServ: LogService) {
  }

  get() {
    this.logger.log("Get request to webapi from angular with NGXLogger", this.url);//отправляются сообщения уровня error
    this.loggerServ.log("Get request to webapi from angular with LogService", this.url);
    return this.http.get(this.url);
  }

  getListMessage(deviceId: string) {
    this.logger.info("GetListMessage request to webapi from angular", " GetListMessage request to webapi", deviceId);
    this.loggerServ.log("GetListMessage request to webapi with LogService", deviceId);
    return this.http.get(this.url + deviceId);
  }

  //log() {
  //  return this.http.post('http://localhost:5000/log/',);
  //}

  deleteMessages(date: Date) {
    this.logger.info("Get delete request to webapi from angular", date);
    this.loggerServ.log("Get delete request to webapi from angular with LogService", date);
    //return this.http.post(this.url, date);
    return this.http.post(this.url+"delete",date);
  }

  saveMessages() {
    this.logger.info("Get file save request to webapi from angular");
    this.loggerServ.log("Get file save request to webapi from angular with LogService");
    return this.http.head('http://localhost:5000/file/');
  }
}

