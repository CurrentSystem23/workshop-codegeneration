interface IDomainValueViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  typeId: number;
  valueC?: string;
  valueN?: number;
  valueD?: Date;
  valueF?: number;
  divId?: string;
  description: string;
  unit?: string;
  tenantId: number;
}
export class DomainValueViewModel implements IDomainValueViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  typeId: number;
  valueC?: string;
  valueN?: number;
  valueD?: Date;
  valueF?: number;
  divId?: string;
  description: string;
  unit?: string;
  tenantId: number;
}


