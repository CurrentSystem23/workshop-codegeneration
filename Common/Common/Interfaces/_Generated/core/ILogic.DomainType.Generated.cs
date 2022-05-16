using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_DomainTypeGetCountAsync();
    Task<ICollection<IDomainTypeViewModel>> Core_DomainTypeGetsAsync(params OrderDomainType[] orderBy);
    Task<ICollection<IDomainTypeViewModel>> Core_DomainTypeGetsAsync(int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    Task<IDomainTypeViewModel> Core_DomainTypeGetAsync(long id);
    Task<ICollection<IDomainTypeHistViewModel>> Core_DomainTypeHistGetsAsync(long id);
    Task<IDomainTypeHistViewModel> Core_DomainTypeHistEntryGetAsync(long histId);
    Task Core_DomainTypeHistDeleteAsync(long histId);
    Task Core_DomainTypeSaveAsync(IDomainTypeViewModel dto);
    Task Core_DomainTypeMergeAsync(IDomainTypeViewModel dto);
    Task Core_DomainTypeDeleteAsync(long id);
    Task<bool> Core_DomainTypeHasChangedAsync(IDomainTypeViewModel dto);
    Task Core_DomainTypeBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos);
    Task Core_DomainTypeBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos, bool identityInsert);
    Task Core_DomainType_TempBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos);
    Task Core_DomainType_TempBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos, bool identityInsert);
    Task Core_DomainTypeBulkMergeAsync(ICollection<IDomainTypeViewModel> dtos);
    Task Core_DomainTypeBulkMergeAsync(ICollection<IDomainTypeViewModel> dtos, bool identityInsert);
    Task Core_DomainTypeBulkUpdateAsync(ICollection<IDomainTypeViewModel> dtos);
    Task Core_DomainTypeBulkDeleteAsync(ICollection<IDomainTypeViewModel> dtos);
    #endregion
    #region Sync
    long Core_DomainTypeGetCount();
    ICollection<IDomainTypeViewModel> Core_DomainTypeGets(params OrderDomainType[] orderBy);
    ICollection<IDomainTypeViewModel> Core_DomainTypeGets(int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    IDomainTypeViewModel Core_DomainTypeGet(long id);
    ICollection<IDomainTypeHistViewModel> Core_DomainTypeHistGets(long id);
    IDomainTypeHistViewModel Core_DomainTypeHistEntryGet(long histId);
    void Core_DomainTypeHistDelete(long histId);
    void Core_DomainTypeSave(IDomainTypeViewModel dto);
    void Core_DomainTypeMerge(IDomainTypeViewModel dto);
    void Core_DomainTypeDelete(long id);
    bool Core_DomainTypeHasChanged(IDomainTypeViewModel dto);
    void Core_DomainTypeBulkInsert(ICollection<IDomainTypeViewModel> dtos);
    void Core_DomainTypeBulkInsert(ICollection<IDomainTypeViewModel> dtos, bool identityInsert);
    void Core_DomainType_TempBulkInsert(ICollection<IDomainTypeViewModel> dtos);
    void Core_DomainType_TempBulkInsert(ICollection<IDomainTypeViewModel> dtos, bool identityInsert);
    void Core_DomainTypeBulkMerge(ICollection<IDomainTypeViewModel> dtos);
    void Core_DomainTypeBulkMerge(ICollection<IDomainTypeViewModel> dtos, bool identityInsert);
    void Core_DomainTypeBulkUpdate(ICollection<IDomainTypeViewModel> dtos);
    void Core_DomainTypeBulkDelete(ICollection<IDomainTypeViewModel> dtos);
    #endregion
  }
}


