import { Injectable } from '@angular/core';
import { BackendService } from '../../../shared/services/backend.service';
import { Observable, map } from 'rxjs';
import { UserResponseModel } from '../models/UserResponseModel'
import { UserRequestModel } from '../models/UserRequestModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private backendService: BackendService) {}

  getAllUsers(): Observable<UserResponseModel[]> {
    return this.backendService.GETRequest('user');
  }

  getUser(id: string): Observable<UserResponseModel> {
    return this.backendService.GETRequest('user/' + id);
  }

  deleteUser(id: string): Observable<void> {
    return this.backendService.DELETERequest('user/' + id);
  }

  createUser(userModel: UserRequestModel): Observable<void> {
    return this.backendService.POSTRequest('user', userModel);
  }
}
