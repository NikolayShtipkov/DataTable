import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';

import { AppComponent } from './app.component';
import { GetUsersComponent } from './modules/users/pages/get-users/get-users.component';
import { NavigationBarComponent } from './shared/pages/navigation-bar/navigation-bar.component';
import { FooterComponent } from './shared/pages/footer/footer.component';
import { CreateUserComponent } from './modules/users/pages/create-user/create-user.component';
import { EditUserComponent } from './modules/users/pages/edit-user/edit-user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    FooterComponent,
    GetUsersComponent,
    CreateUserComponent,
    EditUserComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
