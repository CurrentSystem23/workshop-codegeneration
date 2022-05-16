using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_ProductGetCountAsync();
    Task<ICollection<IProductViewModel>> Core_ProductGetsAsync(params OrderProduct[] orderBy);
    Task<ICollection<IProductViewModel>> Core_ProductGetsAsync(int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    Task<IProductViewModel> Core_ProductGetAsync(long id);
    Task<ICollection<IProductHistViewModel>> Core_ProductHistGetsAsync(long id);
    Task<IProductHistViewModel> Core_ProductHistEntryGetAsync(long histId);
    Task Core_ProductHistDeleteAsync(long histId);
    Task Core_ProductSaveAsync(IProductViewModel dto);
    Task Core_ProductMergeAsync(IProductViewModel dto);
    Task Core_ProductDeleteAsync(long id);
    Task<bool> Core_ProductHasChangedAsync(IProductViewModel dto);
    Task Core_ProductBulkInsertAsync(ICollection<IProductViewModel> dtos);
    Task Core_ProductBulkInsertAsync(ICollection<IProductViewModel> dtos, bool identityInsert);
    Task Core_Product_TempBulkInsertAsync(ICollection<IProductViewModel> dtos);
    Task Core_Product_TempBulkInsertAsync(ICollection<IProductViewModel> dtos, bool identityInsert);
    Task Core_ProductBulkMergeAsync(ICollection<IProductViewModel> dtos);
    Task Core_ProductBulkMergeAsync(ICollection<IProductViewModel> dtos, bool identityInsert);
    Task Core_ProductBulkUpdateAsync(ICollection<IProductViewModel> dtos);
    Task Core_ProductBulkDeleteAsync(ICollection<IProductViewModel> dtos);
    #endregion
    #region Sync
    long Core_ProductGetCount();
    ICollection<IProductViewModel> Core_ProductGets(params OrderProduct[] orderBy);
    ICollection<IProductViewModel> Core_ProductGets(int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    IProductViewModel Core_ProductGet(long id);
    ICollection<IProductHistViewModel> Core_ProductHistGets(long id);
    IProductHistViewModel Core_ProductHistEntryGet(long histId);
    void Core_ProductHistDelete(long histId);
    void Core_ProductSave(IProductViewModel dto);
    void Core_ProductMerge(IProductViewModel dto);
    void Core_ProductDelete(long id);
    bool Core_ProductHasChanged(IProductViewModel dto);
    void Core_ProductBulkInsert(ICollection<IProductViewModel> dtos);
    void Core_ProductBulkInsert(ICollection<IProductViewModel> dtos, bool identityInsert);
    void Core_Product_TempBulkInsert(ICollection<IProductViewModel> dtos);
    void Core_Product_TempBulkInsert(ICollection<IProductViewModel> dtos, bool identityInsert);
    void Core_ProductBulkMerge(ICollection<IProductViewModel> dtos);
    void Core_ProductBulkMerge(ICollection<IProductViewModel> dtos, bool identityInsert);
    void Core_ProductBulkUpdate(ICollection<IProductViewModel> dtos);
    void Core_ProductBulkDelete(ICollection<IProductViewModel> dtos);
    #endregion
  }
}


