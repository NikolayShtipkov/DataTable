import { RoleEnum } from "./Role";

export interface UserResponseModel{
  id: string
  firstName: string;
  lastName: string;
  email: string;
  role: RoleEnum;
  isActive: Boolean;
}
