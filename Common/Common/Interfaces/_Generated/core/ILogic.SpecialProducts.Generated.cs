using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_SpecialProductsGetCountAsync(long[] productIds);
    Task<ICollection<ISpecialProductsViewModel>> Core_SpecialProductsGetsAsync(long[] productIds, params OrderSpecialProducts[] orderBy);
    Task<ICollection<ISpecialProductsViewModel>> Core_SpecialProductsGetsAsync(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
    #region Sync
    long Core_SpecialProductsGetCount(long[] productIds);
    ICollection<ISpecialProductsViewModel> Core_SpecialProductsGets(long[] productIds, params OrderSpecialProducts[] orderBy);
    ICollection<ISpecialProductsViewModel> Core_SpecialProductsGets(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
  }
}


