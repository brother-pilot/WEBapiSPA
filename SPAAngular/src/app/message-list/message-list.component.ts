import { Component, OnInit } from '@angular/core';

import { DataService } from '../core/services/data.service';
import { Message } from '../core/model/message';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css'],
  providers: [DataService]
})

export class MessageListComponent implements OnInit {
  public messages: Message[] = [];                // массив сообщений

  constructor(private dataService: DataService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.getMessageFromRoute();    // загрузка данных при старте компонента
  }

  private getMessageFromRoute() {
    this.activatedRoute.params.forEach((params: Params) => {
      // activatedRoute.params – обращаемся к параметрам
      let id = params["deviceId"];

      if (id) {
        this.dataService.getListMessage(id)
          .subscribe((data: any) => this.messages = data);

/*          getProduct(id).subscribe(
          product => {
            this.currentProduct = product;//записываем в свойство currentProduct значение product которое нам дал сервис 
            this.productForm.patchValue(this.currentProduct);
            // patchValue – благодаря методу будет произведена замена всех значений в форме на то что пришло
          },
          //error => this.errorMessage = error
        );*/
      }
      else {
        //если id нет, то это значит что заходим по ветке создания нового продукта
        //this.currentProduct = new Product(null, null, null);
        //this.productForm.patchValue(this.currentProduct);
      }
    });
  }

  backToDevisesList() {
    this.router.navigate(["/devices"]);
  }

  //delete(p: Product) {
  //  this.dataService.deleteProduct(p.id)
  //    .subscribe(data => this.loadProducts());
  //}

}
