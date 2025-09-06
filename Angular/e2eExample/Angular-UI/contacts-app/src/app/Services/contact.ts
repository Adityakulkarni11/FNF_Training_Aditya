import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { contact } from '../Models/contact';

@Injectable({
  providedIn: 'root'
})
export class Contact {
  url:string="http://localhost:5182/contacts";
  constructor(private httpClient:HttpClient){

}
  public getAllContacts():Observable<contact[]>{
    return this.httpClient.get<contact[]>(this.url);
  }
  public getContact(id: string): Observable<contact> {
    const url = `${this.url}/${id}`;
    return this.httpClient.get<contact>(url);
  }

  public deleteContact(id:number):Observable<void>{
    const temp=`${this.url}/${id}`;
    return this.httpClient.delete<void>(temp);
  }
  public updateContact(contact: contact): Observable<contact> {
    const url = `${this.url}/${contact.id}`;
    return this.httpClient.put<contact>(url, contact);
  }
  public addContact(contact: contact): Observable<contact> {
    return this.httpClient.post<contact>(this.url, contact);
    
  }
}
