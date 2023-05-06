import { Role } from "./Role";

export interface UserResponseModel{
  id: string
  firstName: string;
  lastName: string;
  email: string;
  role: Role;
  isActive: Boolean;
}
