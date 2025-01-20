import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Message } from './message';

@Injectable()
export class DataService {

  private url = "http://localhost:5000/message/";

  constructor(private http: HttpClient) {
  }

  get() {
    return this.http.get(this.url);
  }

  getListMessage(deviceId: string) {
    return this.http.get(this.url + deviceId);
  }

  //deleteProduct(id: number) {
  //  return this.http.delete(this.url + '/' + id);
  //}
}
