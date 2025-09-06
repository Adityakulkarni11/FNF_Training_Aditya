import { Component } from '@angular/core';

@Component({
  selector: 'app-emp',
  standalone: false,
  templateUrl: './emp.html',
  styleUrl: './emp.css'
})
export class Emp {
  empId: number = 1;
  empName: string = 'John Doe';
  empDesignation: string = 'Software Engineer';
  empSalary: number = 50000;

  onClick(){
    alert('Employee ID: ' + this.empId + '\nName: ' + this.empName + '\nDesignation: ' + this.empDesignation+ '\nSalary: ' + this.empSalary);
  }
}
