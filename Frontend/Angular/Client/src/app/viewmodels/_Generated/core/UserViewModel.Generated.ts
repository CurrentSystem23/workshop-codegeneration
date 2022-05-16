interface IUserViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  tenantId: number;
  login: string;
  password: string;
  passwordSalt: string;
  email: string;
  state: number;
  failedLoginCount: number;
  lastLogin?: Date;
  lastPasswordChange?: Date;
  domainLogin: string;
  businessPartnerId: number;
  conditionsId: number;
  conditionsFixed: number;
  privacyPolicyId: number;
  privacyPolicyFixed: number;
  passwordLinkExtension?: string;
  passwordDateOfExpiry?: Date;
  newEmail?: string;
  emailLinkExtension?: string;
  emailDateOfExpiry?: Date;
}
export class UserViewModel implements IUserViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  tenantId: number;
  login: string;
  password: string;
  passwordSalt: string;
  email: string;
  state: number;
  failedLoginCount: number;
  lastLogin?: Date;
  lastPasswordChange?: Date;
  domainLogin: string;
  businessPartnerId: number;
  conditionsId: number;
  conditionsFixed: number;
  privacyPolicyId: number;
  privacyPolicyFixed: number;
  passwordLinkExtension?: string;
  passwordDateOfExpiry?: Date;
  newEmail?: string;
  emailLinkExtension?: string;
  emailDateOfExpiry?: Date;
}


