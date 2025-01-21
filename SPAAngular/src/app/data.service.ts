import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Message } from './message';
import { NGXLogger } from "ngx-logger";


@Injectable()
export class DataService {

  private url = "http://localhost:5000/message/";

  constructor(private http: HttpClient,
    private logger: NGXLogger) {
  }

  get() {
    this.logger.error("Get request to webapi from angular", "Get request to webapi");
    return this.http.get(this.url);
  }

  getListMessage(deviceId: string) {
    this.logger.error("GetListMessage request to webapi from angular", "GetListMessage request to webapi", deviceId);
    return this.http.get(this.url + deviceId);
  }
  //TO DO: переделать в обычные ошибки

  //log() {
  //  return this.http.post('http://localhost:5000/log/',);
  //}

  //deleteProduct(id: number) {
  //  return this.http.delete(this.url + '/' + id);
  //}
}
