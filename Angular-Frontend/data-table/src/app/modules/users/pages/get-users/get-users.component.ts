import { Component, OnInit } from '@angular/core';
import { UserResponseModel } from '../../models/UserResponseModel';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css']
})
export class GetUsersComponent implements OnInit {
  displayUsers: UserResponseModel[] = [];

  constructor(public userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe((data: UserResponseModel[]) => {
      this.displayUsers = data;
      console.log(typeof this.displayUsers[0].role);
    });
  }

  openDialog(id: string) {
    this.userService.deleteUser(id).subscribe((res) => {
      this.displayUsers = this.displayUsers.filter((item) => item.id !== id);
    });
  }
}
