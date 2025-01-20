import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Message } from './message';


@Component({
  selector: 'app-root',
  templateUrl: './app.messageComponent.html',
  providers: [DataService]
})
export class AppMessageComponent implements OnInit {

  //message: Message = new Message();   // изменяемый товар
  public messages: Message[]=[];                // массив сообщений
  //tableMode: boolean = true;          // табличный режим

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadMessages();    // загрузка данных при старте компонента
  }
  // получаем данные через сервис
  loadMessages() {
    this.dataService.get()
      .subscribe((data:any) => this.messages = data);
    //console.log(this.messages);
    //console.log(typeof this.messages);
  }
  
  //delete(p: Product) {
  //  this.dataService.deleteProduct(p.id)
  //    .subscribe(data => this.loadProducts());
  //}
  
}

//@Component({
//  selector: 'app-root',
//  templateUrl: './app.component.html',
//  styleUrls: ['./app.component.css']
//})
//export class AppComponent implements OnInit {
//  public forecasts: WeatherForecast[] = [];

//  constructor(private http: HttpClient) { }



//  getForecasts() {
//    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
//      (result) => {
//        this.forecasts = result;
//      },
//      (error) => {
//        console.error(error);
//      }
//    );
//  }

//  title = 'angularapp1.client';
