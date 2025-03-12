import { Component, OnInit, SimpleChanges } from '@angular/core';

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
  messages: Message[]=[];                // массив сообщений
  public showDownloadingMessage: boolean = true;

  constructor(private dataService: DataService,
    private router: Router) { }

  ngOnInit() {
    this.loadMessages();    // загрузка данных при старте компонента
  }

  // получаем данные через сервис
  private loadMessages() {
    this.dataService.get()
      .subscribe((data: any) => {
        this.messages = data;
        this.showDownloadingMessage = false;});
  }

  getListMessage(message: Message) {
    this.router.navigate(["/messages", message.device]);
    //console.log(this.messages);
    //console.log(typeof this.messages);
  }
}
