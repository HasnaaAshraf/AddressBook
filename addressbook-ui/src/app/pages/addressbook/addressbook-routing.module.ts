import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressbookComponent } from './addressbook.component';

const routes: Routes = [
  { path: '', component: AddressbookComponent } 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddressbookRoutingModule { }
