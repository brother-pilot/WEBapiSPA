import { Component } from '@angular/core';

import { Router } from "@angular/router";
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-delete-message',
  templateUrl: './delete-message.component.html',
  styleUrls: ['./delete-message.component.css'],
  providers: [DataService]
})
export class DeleteMessageComponent {
  public date: Date=new Date;

  constructor(private dataService: DataService,
    private router: Router) { }

  backToDevisesList() {
    this.router.navigate(["/devices"]);
  }

  deleteMessages() {
    console.info("Selected date:"+this.date);
    this.dataService.deleteMessages(new Date(this.date)).
      subscribe(result => console.info("messages after " + result + " was delleted!"),
         error => console.error(error));
   this.router.navigate(["/devices"]);
  }

}
