import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewContact } from './Components/new-contact/new-contact';
import { ContactList } from './Components/contact-list/contact-list';
import { ErrorPage } from './Components/error-page/error-page';
import { EditContact } from './Components/edit-contact/edit-contact';
import { ContactView } from './Components/contact-view/contact-view';

const routes: Routes = [
  {path:'',redirectTo:'contacts/viewall',pathMatch:"full"},
  {path:'contacts/viewall',component:ContactList},
  {path:'contacts/new',component:NewContact},
  {path:'contacts/edit/:id',component:EditContact},
  { path: 'contacts/view/:id', component: ContactView },
  {path:'**',component:ErrorPage}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
