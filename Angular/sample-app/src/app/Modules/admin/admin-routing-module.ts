import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Dashboard } from '../../Components/dashboard/dashboard';
import { User } from '../../Components/user/user';
import { Rights } from '../../Components/rights/rights';

const routes: Routes = [{ path: 'admin',
  children:[
    {path:"dashboard",component:Dashboard},
    {path:"user",component:User},
    {path:"rights",component:Rights}

  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
