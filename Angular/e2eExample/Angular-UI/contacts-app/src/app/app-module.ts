import { NgModule, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { ContactView } from './Components/contact-view/contact-view';
import { ContactList } from './Components/contact-list/contact-list';
import { EditContact } from './Components/edit-contact/edit-contact';
import { NewContact } from './Components/new-contact/new-contact';
import { ErrorPage } from './Components/error-page/error-page';
import { Navbar } from './Components/navbar/navbar';
import { HttpClient, HttpClientModule, provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    App,
    ContactView,
    ContactList,
    EditContact,
    NewContact,
    ErrorPage,
    Navbar
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClient
    //HttpClient
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection(),
    provideHttpClient()
  ],
  bootstrap: [App]
})
export class AppModule { }
