import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () =>
      import('./pages/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'addressbook',
    loadChildren: () =>
      import('./pages/addressbook/addressbook.module').then(m => m.AddressbookModule)
  },
  {
    path: 'jobs',
    loadChildren: () =>
      import('./pages/jobs/jobs.module').then(m => m.JobsModule)
  },
  {
    path: 'departments',
    loadChildren: () =>
      import('./pages/departments/departments.module').then(m => m.DepartmentsModule)
  },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
