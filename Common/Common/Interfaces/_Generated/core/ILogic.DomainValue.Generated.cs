using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_DomainValueGetCountAsync();
    Task<ICollection<IDomainValueViewModel>> Core_DomainValueGetsAsync(params OrderDomainValue[] orderBy);
    Task<ICollection<IDomainValueViewModel>> Core_DomainValueGetsAsync(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    Task<IDomainValueViewModel> Core_DomainValueGetAsync(long id);
    Task<ICollection<IDomainValueHistViewModel>> Core_DomainValueHistGetsAsync(long id);
    Task<IDomainValueHistViewModel> Core_DomainValueHistEntryGetAsync(long histId);
    Task Core_DomainValueHistDeleteAsync(long histId);
    Task Core_DomainValueSaveAsync(IDomainValueViewModel dto);
    Task Core_DomainValueMergeAsync(IDomainValueViewModel dto);
    Task Core_DomainValueDeleteAsync(long id);
    Task<bool> Core_DomainValueHasChangedAsync(IDomainValueViewModel dto);
    Task Core_DomainValueBulkInsertAsync(ICollection<IDomainValueViewModel> dtos);
    Task Core_DomainValueBulkInsertAsync(ICollection<IDomainValueViewModel> dtos, bool identityInsert);
    Task Core_DomainValue_TempBulkInsertAsync(ICollection<IDomainValueViewModel> dtos);
    Task Core_DomainValue_TempBulkInsertAsync(ICollection<IDomainValueViewModel> dtos, bool identityInsert);
    Task Core_DomainValueBulkMergeAsync(ICollection<IDomainValueViewModel> dtos);
    Task Core_DomainValueBulkMergeAsync(ICollection<IDomainValueViewModel> dtos, bool identityInsert);
    Task Core_DomainValueBulkUpdateAsync(ICollection<IDomainValueViewModel> dtos);
    Task Core_DomainValueBulkDeleteAsync(ICollection<IDomainValueViewModel> dtos);
    #endregion
    #region Sync
    long Core_DomainValueGetCount();
    ICollection<IDomainValueViewModel> Core_DomainValueGets(params OrderDomainValue[] orderBy);
    ICollection<IDomainValueViewModel> Core_DomainValueGets(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    IDomainValueViewModel Core_DomainValueGet(long id);
    ICollection<IDomainValueHistViewModel> Core_DomainValueHistGets(long id);
    IDomainValueHistViewModel Core_DomainValueHistEntryGet(long histId);
    void Core_DomainValueHistDelete(long histId);
    void Core_DomainValueSave(IDomainValueViewModel dto);
    void Core_DomainValueMerge(IDomainValueViewModel dto);
    void Core_DomainValueDelete(long id);
    bool Core_DomainValueHasChanged(IDomainValueViewModel dto);
    void Core_DomainValueBulkInsert(ICollection<IDomainValueViewModel> dtos);
    void Core_DomainValueBulkInsert(ICollection<IDomainValueViewModel> dtos, bool identityInsert);
    void Core_DomainValue_TempBulkInsert(ICollection<IDomainValueViewModel> dtos);
    void Core_DomainValue_TempBulkInsert(ICollection<IDomainValueViewModel> dtos, bool identityInsert);
    void Core_DomainValueBulkMerge(ICollection<IDomainValueViewModel> dtos);
    void Core_DomainValueBulkMerge(ICollection<IDomainValueViewModel> dtos, bool identityInsert);
    void Core_DomainValueBulkUpdate(ICollection<IDomainValueViewModel> dtos);
    void Core_DomainValueBulkDelete(ICollection<IDomainValueViewModel> dtos);
    #endregion
  }
}


