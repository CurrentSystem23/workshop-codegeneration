interface ICurrencyViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  iso: string;
  currency: string;
  currencyParts: string;
  region: string;
}
export class CurrencyViewModel implements ICurrencyViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  iso: string;
  currency: string;
  currencyParts: string;
  region: string;
}


