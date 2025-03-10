import { Component } from '@angular/core';

import { ActivatedRoute, Params, Router } from '@angular/router';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [DataService]
})
export class AppComponent {


  constructor(private dataService: DataService,
    private router: Router) { }

  deleteOldMessages() {
    this.router.navigate(["/delete"]);
  }

  saveMessages() {
    this.dataService.saveMessages()
      .subscribe(result => console.info("messages were saved!"),
        error => console.error(error));
  }
}
