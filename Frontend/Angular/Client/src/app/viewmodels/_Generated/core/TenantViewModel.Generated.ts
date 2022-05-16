interface ITenantViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  tenantName: string;
  description: string;
}
export class TenantViewModel implements ITenantViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  tenantName: string;
  description: string;
}


