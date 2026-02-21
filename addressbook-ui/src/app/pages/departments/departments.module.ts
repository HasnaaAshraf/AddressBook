import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { DepartmentsRoutingModule } from './departments-routing.module';
import { DepartmentComponent } from './departments.component';

@NgModule({
  declarations: [
    DepartmentComponent
  ],
  imports: [
    CommonModule,
    FormsModule,       
    DepartmentsRoutingModule
  ]
})
export class DepartmentsModule { }
