import { Component, OnInit } from '@angular/core';
import { Contact } from '../../Services/contact';
import { contact } from '../../Models/contact';


@Component({
  selector: 'app-contact-list',
  standalone: false,
  templateUrl: './contact-list.html',
  styleUrls: ['./contact-list.css']
})
export class ContactList implements OnInit{
  contactList: any[] = [];
  
  constructor(private service:Contact) {
     
  }
  ngOnInit(): void {
    // this.contactList.push({contactId:101,contactName:"John",contactPhno:"1234567890",contactPhoto:"images/pic1.png"});
    // this.contactList.push({contactId:102,contactName:"Smith",contactPhno:"2345678901",contactPhoto:"images/pic2.png"});
    // this.contactList.push({contactId:103,contactName:"Kathy",contactPhno:"3456789012",contactPhoto:"images/pic3.png"});
    // this.contactList.push({contactId:104,contactName:"Peter",contactPhno:"4567890123",contactPhoto:"images/pic4.png"});
    // this.contactList.push({contactId:105,contactName:"David",contactPhno:"5678901234",contactPhoto:"images/pic5.png"});
    let Observable=this.service.getAllContacts();
    Observable.subscribe((data:contact[])=>{
      this.contactList=data;
    })
  }
  
  deleteContact(id: number): void {
    if (confirm('Are you sure to delete?')) {
      this.service.deleteContact(id).subscribe(() => {
        this.contactList = this.contactList.filter(contact => contact.id !== id);
        alert('Contact deleted successfully!');
        location.reload();
      });
    }
  }

}
