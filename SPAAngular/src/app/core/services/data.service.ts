import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Message } from '../model/message';
import { NGXLogger } from "ngx-logger";


@Injectable()
export class DataService {

  private url = "http://localhost:5000/message/";

  constructor(private http: HttpClient,
    private logger: NGXLogger) {
  }

  get() {
    this.logger.info("Get request to webapi from angular",this.url);
    return this.http.get(this.url);
  }

  getListMessage(deviceId: string) {
    this.logger.info("GetListMessage request to webapi from angular", " GetListMessage request to webapi", deviceId);
    return this.http.get(this.url + deviceId);
  }
  //TO DO: переделать в обычные ошибки

  //log() {
  //  return this.http.post('http://localhost:5000/log/',);
  //}

  deleteMessages(date: Date) {
    this.logger.info("Get delete request to webapi from angular", date);
    //return this.http.post(this.url, date);
    return this.http.post(this.url+"delete",date);
  }
}

export class Logmes {
    public id: string;
    public device: string;

  constructor(
    id: string,
    device: string)
  {
    this.id = id;
    this.device = device;
  }
  
}
