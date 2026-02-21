import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AddressbookRoutingModule } from './addressbook-routing.module';
import { AddressbookComponent } from './addressbook.component';


@NgModule({
  declarations: [
    AddressbookComponent
  ],
  imports: [
    CommonModule,
    AddressbookRoutingModule,
    FormsModule  
  ]
})
export class AddressbookModule { }
