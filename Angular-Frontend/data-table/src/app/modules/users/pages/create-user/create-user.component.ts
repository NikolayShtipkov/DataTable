import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { UserRequestModel } from '../../models/UserRequestModel';
import { UserResponseModel } from '../../models/UserResponseModel';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent {
  eventModels: UserResponseModel[] = [];

  defaultUser: UserRequestModel = {
    firstName: 'First Name',
    lastName: 'Last Name',
    email: 'Your Email',
    role: 0,
    isActive: true
  };

  userToCreate: UserRequestModel = { ...this.defaultUser };

  constructor(
    public userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {}

  onSubmit(form: NgForm): void{
    if (form.valid) {
      this.userService.createUser(this.userToCreate).subscribe(res => {
        this.router.navigateByUrl('/users');
      });
    } else {
      console.log("Form not valid.");
    }
  }
}
