interface ICountryViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  country: string;
  countryKey?: string;
  currencyId?: number;
}
export class CountryViewModel implements ICountryViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  country: string;
  countryKey?: string;
  currencyId?: number;
}


