using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_ProductInStockGetCountAsync(long? productId);
    Task<ICollection<IProductInStockViewModel>> Core_ProductInStockGetsAsync(long? productId, params OrderProductInStock[] orderBy);
    Task<ICollection<IProductInStockViewModel>> Core_ProductInStockGetsAsync(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
    #region Sync
    long Core_ProductInStockGetCount(long? productId);
    ICollection<IProductInStockViewModel> Core_ProductInStockGets(long? productId, params OrderProductInStock[] orderBy);
    ICollection<IProductInStockViewModel> Core_ProductInStockGets(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
  }
}


