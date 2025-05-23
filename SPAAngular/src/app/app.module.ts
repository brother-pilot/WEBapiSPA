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
import { FormsModule } from "@angular/forms";
import { LogService } from './core/services/log.service';
import { LogPublishersService } from "./core/services/LogPublishers.Service";


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
      serverLogLevel: NgxLoggerLevel.TRACE,
      disableConsoleLogging: false
    }),
    RouterModule.forRoot(routes),
    FormsModule

  ],
  providers: [LogService, LogPublishersService],
  bootstrap: [AppComponent]
})
export class AppModule { }


