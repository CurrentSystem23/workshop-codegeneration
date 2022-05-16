interface IProductViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  productName: string;
  price: number;
}
export class ProductViewModel implements IProductViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  productName: string;
  price: number;
}


