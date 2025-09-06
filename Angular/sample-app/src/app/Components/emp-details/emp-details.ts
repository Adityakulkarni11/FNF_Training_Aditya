import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Employee } from '../../Models/employee';

@Component({
  selector: 'app-emp-details',
  standalone: false,
  templateUrl: './emp-details.html',
  styleUrl: './emp-details.css'
})
export class EmpDetails {
  @Input() selectedEmp: Employee = {} as Employee;
  @Output() update = new EventEmitter<Employee>();
  //event handler for the button
  onUpdate() {
    this.update.emit(this.selectedEmp);
    alert("Employee Updated : " + this.selectedEmp.empName);
  }
}
