import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { UserRequestModel } from '../../models/UserRequestModel';
import { UserResponseModel } from '../../models/UserResponseModel';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {
  id!: string;
  user!: UserRequestModel;
  userModels: UserResponseModel[] = [];
  editForm: FormGroup;
  result!: string;

  constructor(
    public userService: UserService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      id: [''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      role: [''],
      isActive: ['']
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.userService.getAllUsers().subscribe((data: UserResponseModel[]) => {
      this.userModels = data;
    });

    this.userService
      .getUser(this.id)
      .subscribe((data: UserResponseModel) => {
        this.user = data;
        this.editForm.patchValue(data);
      });
  }

  onSubmit(formData: { value: UserResponseModel }) {
    this.userService
      .updateUser(this.id, this.editForm.value)
        .subscribe((res) => {
              this.router.navigateByUrl('/users');
        });
  }
}