import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GetUsersComponent } from './modules/users/pages/get-users/get-users.component';
import { CreateUserComponent } from './modules/users/pages/create-user/create-user.component';

const routes: Routes = [
  { path: 'users', component: GetUsersComponent, pathMatch: 'full' },
  { path: 'users/create', component: CreateUserComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
