import { Component, OnInit } from '@angular/core';
import { Employee } from '../../Models/employee';

@Component({
  selector: 'app-master',
  standalone: false,
  templateUrl: './master.html',
  styleUrl: './master.css'
})
export class Master implements OnInit{
  ngOnInit(): void {
    this.empList.push({empId:101,empName:"John",empAddress:"New York",empSalary:55000,empImg:"images/pic1.png"});
    this.empList.push({empId:102,empName:"Smith",empAddress:"London",empSalary:45000,empImg:"images/pic2.png"});
    this.empList.push({empId:103,empName:"Kathy",empAddress:"Sydney",empSalary:65000,empImg:"images/pic3.png"});
    this.empList.push({empId:104,empName:"Peter",empAddress:"Mumbai",empSalary:35000,empImg:"images/pic4.png"});
    this.empList.push({empId:105,empName:"David",empAddress:"Tokyo",empSalary:75000,empImg:"images/pic5.png"});
  }
  empList:Employee[]=[];
  selectedEmp:Employee={} as Employee;
  //event handler for the child event
  onEdit(rec:Employee){
    this.selectedEmp=rec;
    alert("Employee Selected for Edit : "+rec.empName);
  }
  onSaved(rec:Employee){
    let index=this.empList.indexOf(this.selectedEmp);
    if(index<0){
      alert("Please select an Employee to be updated");
      return;
    }
    this.empList[index]=rec;
    alert("Employee Saved : "+rec.empName);
  }
  onDelete(rec:Employee){
    //find the index of the record to be deleted
    let index=this.empList.indexOf(rec);
    //remove the record from the array
    this.empList.splice(index,1);
    alert("Employee Deleted : "+rec.empName);
  }
}
