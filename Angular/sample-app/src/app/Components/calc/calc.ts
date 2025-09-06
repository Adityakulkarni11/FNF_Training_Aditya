import { Component } from '@angular/core';


@Component({
  selector: 'app-calc',
  standalone: false,
  templateUrl: './calc.html',
  styleUrl: './calc.css'
})
export class Calc {
  firstValue: number = 0;
  secondValue: number = 0;
  operation: string = 'add';
  result: number = 0;

  onCalculate() {
    switch (this.operation) {
      case 'add':
        this.result = this.firstValue + this.secondValue;
        break;
      case 'sub':
        this.result = this.firstValue - this.secondValue;
        break;
      case 'mul':
        this.result = this.firstValue * this.secondValue;
        break;
      case 'div':
        this.result = this.firstValue / this.secondValue;
        break;
    }
  }
}
