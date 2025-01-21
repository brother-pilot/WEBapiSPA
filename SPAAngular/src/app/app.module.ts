import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppMessageComponent } from './app.messageComponent';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';

@NgModule({
  declarations: [
    AppMessageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    LoggerModule.forRoot({
      serverLoggingUrl: 'http://localhost:5000/log/', // Replace with YOUR API,
      level: NgxLoggerLevel.TRACE,
      serverLogLevel: NgxLoggerLevel.LOG,
      disableConsoleLogging: false
    })

  ],
  providers: [],
  bootstrap: [AppMessageComponent]
})
export class AppModule { }
