import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Contact } from '../../Services/contact';
import { contact } from '../../Models/contact';

@Component({
  selector: 'app-new-contact',
  templateUrl: './new-contact.html',
  styleUrls: ['./new-contact.css'],
  standalone: false
})
export class NewContact {
  contact: contact = {
    id: 0,
    name: '',
    phoneNo: '',
    photo: ''
  };

  constructor(private contactService: Contact, private router: Router) {}

  onSubmit() {
    this.contactService.addContact(this.contact).subscribe((newContact) => {
      alert('Contact added successfully!');
      this.router.navigate(['/']);
    }); 
  }
}
