interface IUserGroupViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  group: string;
  description: string;
}
export class UserGroupViewModel implements IUserGroupViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  group: string;
  description: string;
}


