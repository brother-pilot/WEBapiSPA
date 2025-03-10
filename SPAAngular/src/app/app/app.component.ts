import { Component } from '@angular/core';

import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  constructor(private router: Router) { }

  deleteOldMessages() {
    this.router.navigate(["/delete"]);
  }

  saveMessages() {
    this.router.navigate(["/delete"]);
  }
}
