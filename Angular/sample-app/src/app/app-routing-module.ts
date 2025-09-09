import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Calc } from './Components/calc/calc';
import { App } from './app';
import { Master } from './Components/master/master';
import { Emp } from './Components/emp/emp';
import { Second } from './Components/second/second';
import { ValidationForm } from './validation-form/validation-form';
import { ReactiveForm } from './Components/reactive-form/reactive-form';

const routes: Routes = [
  {path: '', redirectTo: '/Calculator', pathMatch: 'full'},
  {path: 'Calculator', component: Calc},
  {path: 'Master-Details', component: Master},
  {path:"Employee",component:Emp},
  {path:"Validation",component:ValidationForm},
  {path:"Reactive",component:ReactiveForm},
  { path: 'admin', loadChildren: () => import('./Modules/admin/admin-module').then(m => m.AdminModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
