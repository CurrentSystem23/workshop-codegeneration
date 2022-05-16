interface IStockViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  productId: number;
  quantity: number;
}
export class StockViewModel implements IStockViewModel {
  id: number;
  modifiedDate: Date;
  modifiedUser: number;
  productId: number;
  quantity: number;
}


