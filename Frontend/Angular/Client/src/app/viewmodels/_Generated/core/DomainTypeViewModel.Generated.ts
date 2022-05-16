interface IDomainTypeViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  type: string;
  description: string;
  mode: string;
  standardId?: number;
  editable: number;
}
export class DomainTypeViewModel implements IDomainTypeViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  type: string;
  description: string;
  mode: string;
  standardId?: number;
  editable: number;
}


