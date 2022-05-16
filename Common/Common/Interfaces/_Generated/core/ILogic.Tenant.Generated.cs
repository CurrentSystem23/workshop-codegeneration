using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_TenantGetCountAsync();
    Task<ICollection<ITenantViewModel>> Core_TenantGetsAsync(params OrderTenant[] orderBy);
    Task<ICollection<ITenantViewModel>> Core_TenantGetsAsync(int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    Task<ITenantViewModel> Core_TenantGetAsync(long id);
    Task<ICollection<ITenantHistViewModel>> Core_TenantHistGetsAsync(long id);
    Task<ITenantHistViewModel> Core_TenantHistEntryGetAsync(long histId);
    Task Core_TenantHistDeleteAsync(long histId);
    Task Core_TenantSaveAsync(ITenantViewModel dto);
    Task Core_TenantMergeAsync(ITenantViewModel dto);
    Task Core_TenantDeleteAsync(long id);
    Task<bool> Core_TenantHasChangedAsync(ITenantViewModel dto);
    Task Core_TenantBulkInsertAsync(ICollection<ITenantViewModel> dtos);
    Task Core_TenantBulkInsertAsync(ICollection<ITenantViewModel> dtos, bool identityInsert);
    Task Core_Tenant_TempBulkInsertAsync(ICollection<ITenantViewModel> dtos);
    Task Core_Tenant_TempBulkInsertAsync(ICollection<ITenantViewModel> dtos, bool identityInsert);
    Task Core_TenantBulkMergeAsync(ICollection<ITenantViewModel> dtos);
    Task Core_TenantBulkMergeAsync(ICollection<ITenantViewModel> dtos, bool identityInsert);
    Task Core_TenantBulkUpdateAsync(ICollection<ITenantViewModel> dtos);
    Task Core_TenantBulkDeleteAsync(ICollection<ITenantViewModel> dtos);
    #endregion
    #region Sync
    long Core_TenantGetCount();
    ICollection<ITenantViewModel> Core_TenantGets(params OrderTenant[] orderBy);
    ICollection<ITenantViewModel> Core_TenantGets(int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    ITenantViewModel Core_TenantGet(long id);
    ICollection<ITenantHistViewModel> Core_TenantHistGets(long id);
    ITenantHistViewModel Core_TenantHistEntryGet(long histId);
    void Core_TenantHistDelete(long histId);
    void Core_TenantSave(ITenantViewModel dto);
    void Core_TenantMerge(ITenantViewModel dto);
    void Core_TenantDelete(long id);
    bool Core_TenantHasChanged(ITenantViewModel dto);
    void Core_TenantBulkInsert(ICollection<ITenantViewModel> dtos);
    void Core_TenantBulkInsert(ICollection<ITenantViewModel> dtos, bool identityInsert);
    void Core_Tenant_TempBulkInsert(ICollection<ITenantViewModel> dtos);
    void Core_Tenant_TempBulkInsert(ICollection<ITenantViewModel> dtos, bool identityInsert);
    void Core_TenantBulkMerge(ICollection<ITenantViewModel> dtos);
    void Core_TenantBulkMerge(ICollection<ITenantViewModel> dtos, bool identityInsert);
    void Core_TenantBulkUpdate(ICollection<ITenantViewModel> dtos);
    void Core_TenantBulkDelete(ICollection<ITenantViewModel> dtos);
    #endregion
  }
}


