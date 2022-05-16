using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_ProductsInStockGetCountAsync();
    Task<ICollection<IProductsInStockViewModel>> Core_ProductsInStockGetsAsync(params OrderProductsInStock[] orderBy);
    Task<ICollection<IProductsInStockViewModel>> Core_ProductsInStockGetsAsync(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    #endregion
    #region Sync
    long Core_ProductsInStockGetCount();
    ICollection<IProductsInStockViewModel> Core_ProductsInStockGets(params OrderProductsInStock[] orderBy);
    ICollection<IProductsInStockViewModel> Core_ProductsInStockGets(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    #endregion
  }
}


