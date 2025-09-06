import { Component, signal } from '@angular/core';

@Component({
  selector: 'apple',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {
  title: string='My First Angular App'; 
}
