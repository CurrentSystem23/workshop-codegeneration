using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_StockGetCountAsync();
    Task<ICollection<IStockViewModel>> Core_StockGetsAsync(params OrderStock[] orderBy);
    Task<ICollection<IStockViewModel>> Core_StockGetsAsync(int? pageNum, int? pageSize, params OrderStock[] orderBy);
    Task<IStockViewModel> Core_StockGetAsync(long id);
    Task<ICollection<IStockHistViewModel>> Core_StockHistGetsAsync(long id);
    Task<IStockHistViewModel> Core_StockHistEntryGetAsync(long histId);
    Task Core_StockHistDeleteAsync(long histId);
    Task Core_StockSaveAsync(IStockViewModel dto);
    Task Core_StockMergeAsync(IStockViewModel dto);
    Task Core_StockDeleteAsync(long id);
    Task<bool> Core_StockHasChangedAsync(IStockViewModel dto);
    Task Core_StockBulkInsertAsync(ICollection<IStockViewModel> dtos);
    Task Core_StockBulkInsertAsync(ICollection<IStockViewModel> dtos, bool identityInsert);
    Task Core_Stock_TempBulkInsertAsync(ICollection<IStockViewModel> dtos);
    Task Core_Stock_TempBulkInsertAsync(ICollection<IStockViewModel> dtos, bool identityInsert);
    Task Core_StockBulkMergeAsync(ICollection<IStockViewModel> dtos);
    Task Core_StockBulkMergeAsync(ICollection<IStockViewModel> dtos, bool identityInsert);
    Task Core_StockBulkUpdateAsync(ICollection<IStockViewModel> dtos);
    Task Core_StockBulkDeleteAsync(ICollection<IStockViewModel> dtos);
    #endregion
    #region Sync
    long Core_StockGetCount();
    ICollection<IStockViewModel> Core_StockGets(params OrderStock[] orderBy);
    ICollection<IStockViewModel> Core_StockGets(int? pageNum, int? pageSize, params OrderStock[] orderBy);
    IStockViewModel Core_StockGet(long id);
    ICollection<IStockHistViewModel> Core_StockHistGets(long id);
    IStockHistViewModel Core_StockHistEntryGet(long histId);
    void Core_StockHistDelete(long histId);
    void Core_StockSave(IStockViewModel dto);
    void Core_StockMerge(IStockViewModel dto);
    void Core_StockDelete(long id);
    bool Core_StockHasChanged(IStockViewModel dto);
    void Core_StockBulkInsert(ICollection<IStockViewModel> dtos);
    void Core_StockBulkInsert(ICollection<IStockViewModel> dtos, bool identityInsert);
    void Core_Stock_TempBulkInsert(ICollection<IStockViewModel> dtos);
    void Core_Stock_TempBulkInsert(ICollection<IStockViewModel> dtos, bool identityInsert);
    void Core_StockBulkMerge(ICollection<IStockViewModel> dtos);
    void Core_StockBulkMerge(ICollection<IStockViewModel> dtos, bool identityInsert);
    void Core_StockBulkUpdate(ICollection<IStockViewModel> dtos);
    void Core_StockBulkDelete(ICollection<IStockViewModel> dtos);
    #endregion
  }
}


