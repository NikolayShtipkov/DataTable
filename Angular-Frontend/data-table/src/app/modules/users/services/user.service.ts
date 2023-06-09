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

  getUsersSortedByName(): Observable<UserResponseModel[]> {
    return this.backendService.GETRequest('user/name');
  }

  getUsersSortedByEmail(): Observable<UserResponseModel[]> {
    return this.backendService.GETRequest('user/email');
  }

  getUsersFilteredByRole(number: Number): Observable<UserResponseModel[]> {
    return this.backendService.GETRequest('user/filter/role/' + number);
  }

  getUsersFilteredByStatus(number: Number): Observable<UserResponseModel[]> {
    return this.backendService.GETRequest('user/filter/status/' + number);
  }

  getUsersFilteredByParameter(param: String): Observable<UserResponseModel[]> {
    return this.backendService.GETRequest('user/filter/' + param);
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

  updateUser(
    id: string,
    userModel: UserRequestModel
  ): Observable<UserRequestModel> {
    return this.backendService.PUTRequest('user/' + id, userModel);
  }
}
