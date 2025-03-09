import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from "@angular/router";

import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';
import { AppComponent } from './app/app.component';
import { MessageListComponent } from './message-list/message-list.component';
import { DeviceListComponent } from './device-list/device-list.component';
import { routes } from "./app.routes";
import { DeleteMessageComponent } from './delete-message/delete-message.component';


@NgModule({
  declarations: [
    AppComponent,
    MessageListComponent,
    DeviceListComponent,
    DeleteMessageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    LoggerModule.forRoot({
      serverLoggingUrl: 'http://localhost:5000/log/', // Replace with YOUR API,
      level: NgxLoggerLevel.TRACE,
      serverLogLevel: NgxLoggerLevel.LOG,
      disableConsoleLogging: false
    }),
    RouterModule.forRoot(routes)

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


