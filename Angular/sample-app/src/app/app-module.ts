import { NgModule, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Second } from './Components/second/second';
import { Emp } from './Components/emp/emp';
import { Calc } from './Components/calc/calc';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmpDetails } from './Components/emp-details/emp-details';
import { Master } from './Components/master/master';
import { ValidationForm } from './validation-form/validation-form';
import { Navbar } from './navbar/navbar';
import { ReactiveForm } from './Components/reactive-form/reactive-form';
import { Admin } from './Modules/admin/admin';
import { AdminModule } from './Modules/admin/admin-module';

@NgModule({
  declarations: [
    App,
    Second,
    Emp,
    Calc,
    EmpDetails,
    Master,
    ValidationForm,
    Navbar,
    ReactiveForm,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    AdminModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection()
  ],
  //bootstrap: [App,Second,Emp,Calc]
  bootstrap: [App]
})
export class AppModule { }
