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
    return this.backendService.GETRequest('User');
  }

  getUser(id: string): Observable<UserResponseModel> {
    return this.backendService.GETRequest('User/' + id);
  }

  deleteUser(id: string): Observable<void> {
    return this.backendService.DELETERequest('User/' + id);
  }
}
