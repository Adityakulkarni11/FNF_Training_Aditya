import { Component, OnInit,ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from '../../Services/contact';
import { contact } from '../../Models/contact';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.html',
  styleUrls: ['./edit-contact.css'],
  standalone: false
})
export class EditContact implements OnInit {
  // contact: contact = {
  //   id: 0,
  //   name: '',
  //   phoneNo: '',
  //   photo: ''
  // };
  // Remove default initialization; contact will be set after fetching
  contact!: contact;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: Contact,
    private cdRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
  const id = this.route.snapshot.paramMap.get('id');
  console.log('Route ID:', id);
  if (id) {
    this.service.getContact(id).subscribe((data: contact) => {
      console.log('Fetched contact:', data);
      this.contact = data;
      this.cdRef.detectChanges();
    });
  }
}
  updateContact(): void {
    this.service.updateContact(this.contact).subscribe(() => {
      alert('Contact updated successfully!');
      this.router.navigate(['/']);
    });
  }
}
