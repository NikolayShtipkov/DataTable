import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { GetUsersComponent } from './modules/users/pages/get-users/get-users.component';
import { HttpClientModule } from '@angular/common/http';
import { NavigationBarComponent } from './shared/pages/navigation-bar/navigation-bar.component';
import { FooterComponent } from './shared/pages/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    FooterComponent,
    GetUsersComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
