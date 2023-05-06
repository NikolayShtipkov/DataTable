import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GetUsersComponent } from './modules/users/pages/get-users/get-users.component';
import { CreateUserComponent } from './modules/users/pages/create-user/create-user.component';
import { EditUserComponent } from './modules/users/pages/edit-user/edit-user.component';

const routes: Routes = [
  { path: 'users', component: GetUsersComponent, pathMatch: 'full' },
  { path: 'users/create', component: CreateUserComponent, pathMatch: 'full' },
  { path: 'users/:id/edit', component: EditUserComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
