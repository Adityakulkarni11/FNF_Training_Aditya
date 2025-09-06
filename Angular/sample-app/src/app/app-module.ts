import { NgModule, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Second } from './Components/second/second';
import { Emp } from './Components/emp/emp';
import { Calc } from './Components/calc/calc';
import { FormsModule } from '@angular/forms';
import { EmpDetails } from './Components/emp-details/emp-details';
import { Master } from './Components/master/master';

@NgModule({
  declarations: [
    App,
    Second,
    Emp,
    Calc,
    EmpDetails,
    Master
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection()
  ],
  //bootstrap: [App,Second,Emp,Calc]
  bootstrap: [Master]
})
export class AppModule { }
