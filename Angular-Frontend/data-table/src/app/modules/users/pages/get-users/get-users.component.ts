import { Component, OnInit } from '@angular/core';
import { UserResponseModel } from '../../models/UserResponseModel';
import { UserService } from '../../services/user.service';
import { Role } from '../../models/Role';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css']
})
export class GetUsersComponent implements OnInit {

  displayUsers: UserResponseModel[] = [];
  roles: string[] = ['Guest', 'Regular', 'Admin'];
  selectedRole: Number = 0;
  selectedStatus: Number = 0;
  parameter: String = '';

  constructor(public userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe((data: UserResponseModel[]) => {
      this.displayUsers = data;
    });
  }

  openDialog(id: string) {
    this.userService.deleteUser(id).subscribe((res) => {
      this.displayUsers = this.displayUsers.filter((item) => item.id !== id);
    });
  }

  sortByName() {
    this.userService.getUsersSortedByName().subscribe((data: UserResponseModel[]) => {
      this.displayUsers = data;
    });
  }

  sortByEmail() {
    this.userService.getUsersSortedByEmail().subscribe((data: UserResponseModel[]) => {
      this.displayUsers = data;
    });
  }

  filterByRole(number: Number) {
    this.userService.getUsersFilteredByRole(number).subscribe((data: UserResponseModel[]) => {
      this.displayUsers = data;
    });
  }

  filterByStatus(number: Number) {
    this.userService.getUsersFilteredByStatus(number).subscribe((data: UserResponseModel[]) => {
      this.displayUsers = data;
    });
  }

  filterByParameter(param: String) {
    this.userService.getUsersFilteredByParameter(param).subscribe((data: UserResponseModel[]) => {
      this.displayUsers = data;
    });
  }
}
