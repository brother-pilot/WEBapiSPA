import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppMessageComponent } from './app.messageComponent';

@NgModule({
  declarations: [
    AppMessageComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppMessageComponent]
})
export class AppModule { }
