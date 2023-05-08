import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { UserRequestModel } from '../../models/UserRequestModel';
import { UserResponseModel } from '../../models/UserResponseModel';
import { Role, Status } from '../../models/Interfaces';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent {
  eventModels: UserResponseModel[] = [];

  roles: Role[] = [];

  statuses: Status[] = [];

  defaultUser: UserRequestModel = {
    firstName: 'Your First Name',
    lastName: 'Your Last Name',
    email: 'example@email.com',
    role: 0,
    isActive: true
  };

  userToCreate: UserRequestModel = { ...this.defaultUser };

  constructor(
    public userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.roles = [
      { label: 'Guest', value: 0 },
      { label: 'Regular', value: 1 },
      { label: 'Admin', value: 2 },
    ];

    this.statuses = [
      { label: 'Inactive', value: false },
      { label: 'Active', value: true },
    ];
  }

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
