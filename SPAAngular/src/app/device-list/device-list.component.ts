import { Component, OnInit } from '@angular/core';

import { Router } from "@angular/router";
import { DataService } from '../core/services/data.service';
import { Message } from '../core/model/message';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css'],
  providers: [DataService]
})
export class DeviceListComponent implements OnInit {
  public messages: Message[] = [];                // массив сообщений

  constructor(private dataService: DataService,
    private router: Router) { }

  ngOnInit() {
    this.loadMessages();    // загрузка данных при старте компонента
  }
  // получаем данные через сервис
  private loadMessages() {
    this.dataService.get()
      .subscribe((data: any) => this.messages = data);
    console.log(this.messages);
    //console.log(typeof this.messages);
  }

  getListMessage(message: Message) {
    this.router.navigate(["/messages", message.device]);
    //console.log(this.messages);
    //console.log(typeof this.messages);
  }

  //delete(p: Product) {
  //  this.dataService.deleteProduct(p.id)
  //    .subscribe(data => this.loadProducts());
  //}

}
