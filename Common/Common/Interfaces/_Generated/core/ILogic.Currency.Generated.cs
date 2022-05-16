using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_CurrencyGetCountAsync();
    Task<ICollection<ICurrencyViewModel>> Core_CurrencyGetsAsync(params OrderCurrency[] orderBy);
    Task<ICollection<ICurrencyViewModel>> Core_CurrencyGetsAsync(int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    Task<ICurrencyViewModel> Core_CurrencyGetAsync(long id);
    Task<ICollection<ICurrencyHistViewModel>> Core_CurrencyHistGetsAsync(long id);
    Task<ICurrencyHistViewModel> Core_CurrencyHistEntryGetAsync(long histId);
    Task Core_CurrencyHistDeleteAsync(long histId);
    Task Core_CurrencySaveAsync(ICurrencyViewModel dto);
    Task Core_CurrencyMergeAsync(ICurrencyViewModel dto);
    Task Core_CurrencyDeleteAsync(long id);
    Task<bool> Core_CurrencyHasChangedAsync(ICurrencyViewModel dto);
    Task Core_CurrencyBulkInsertAsync(ICollection<ICurrencyViewModel> dtos);
    Task Core_CurrencyBulkInsertAsync(ICollection<ICurrencyViewModel> dtos, bool identityInsert);
    Task Core_Currency_TempBulkInsertAsync(ICollection<ICurrencyViewModel> dtos);
    Task Core_Currency_TempBulkInsertAsync(ICollection<ICurrencyViewModel> dtos, bool identityInsert);
    Task Core_CurrencyBulkMergeAsync(ICollection<ICurrencyViewModel> dtos);
    Task Core_CurrencyBulkMergeAsync(ICollection<ICurrencyViewModel> dtos, bool identityInsert);
    Task Core_CurrencyBulkUpdateAsync(ICollection<ICurrencyViewModel> dtos);
    Task Core_CurrencyBulkDeleteAsync(ICollection<ICurrencyViewModel> dtos);
    #endregion
    #region Sync
    long Core_CurrencyGetCount();
    ICollection<ICurrencyViewModel> Core_CurrencyGets(params OrderCurrency[] orderBy);
    ICollection<ICurrencyViewModel> Core_CurrencyGets(int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    ICurrencyViewModel Core_CurrencyGet(long id);
    ICollection<ICurrencyHistViewModel> Core_CurrencyHistGets(long id);
    ICurrencyHistViewModel Core_CurrencyHistEntryGet(long histId);
    void Core_CurrencyHistDelete(long histId);
    void Core_CurrencySave(ICurrencyViewModel dto);
    void Core_CurrencyMerge(ICurrencyViewModel dto);
    void Core_CurrencyDelete(long id);
    bool Core_CurrencyHasChanged(ICurrencyViewModel dto);
    void Core_CurrencyBulkInsert(ICollection<ICurrencyViewModel> dtos);
    void Core_CurrencyBulkInsert(ICollection<ICurrencyViewModel> dtos, bool identityInsert);
    void Core_Currency_TempBulkInsert(ICollection<ICurrencyViewModel> dtos);
    void Core_Currency_TempBulkInsert(ICollection<ICurrencyViewModel> dtos, bool identityInsert);
    void Core_CurrencyBulkMerge(ICollection<ICurrencyViewModel> dtos);
    void Core_CurrencyBulkMerge(ICollection<ICurrencyViewModel> dtos, bool identityInsert);
    void Core_CurrencyBulkUpdate(ICollection<ICurrencyViewModel> dtos);
    void Core_CurrencyBulkDelete(ICollection<ICurrencyViewModel> dtos);
    #endregion
  }
}


