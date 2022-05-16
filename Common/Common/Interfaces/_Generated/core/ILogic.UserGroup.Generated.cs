using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_UserGroupGetCountAsync();
    Task<ICollection<IUserGroupViewModel>> Core_UserGroupGetsAsync(params OrderUserGroup[] orderBy);
    Task<ICollection<IUserGroupViewModel>> Core_UserGroupGetsAsync(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    Task<IUserGroupViewModel> Core_UserGroupGetAsync(long id);
    Task<ICollection<IUserGroupHistViewModel>> Core_UserGroupHistGetsAsync(long id);
    Task<IUserGroupHistViewModel> Core_UserGroupHistEntryGetAsync(long histId);
    Task Core_UserGroupHistDeleteAsync(long histId);
    Task Core_UserGroupSaveAsync(IUserGroupViewModel dto);
    Task Core_UserGroupMergeAsync(IUserGroupViewModel dto);
    Task Core_UserGroupDeleteAsync(long id);
    Task<bool> Core_UserGroupHasChangedAsync(IUserGroupViewModel dto);
    Task Core_UserGroupBulkInsertAsync(ICollection<IUserGroupViewModel> dtos);
    Task Core_UserGroupBulkInsertAsync(ICollection<IUserGroupViewModel> dtos, bool identityInsert);
    Task Core_UserGroup_TempBulkInsertAsync(ICollection<IUserGroupViewModel> dtos);
    Task Core_UserGroup_TempBulkInsertAsync(ICollection<IUserGroupViewModel> dtos, bool identityInsert);
    Task Core_UserGroupBulkMergeAsync(ICollection<IUserGroupViewModel> dtos);
    Task Core_UserGroupBulkMergeAsync(ICollection<IUserGroupViewModel> dtos, bool identityInsert);
    Task Core_UserGroupBulkUpdateAsync(ICollection<IUserGroupViewModel> dtos);
    Task Core_UserGroupBulkDeleteAsync(ICollection<IUserGroupViewModel> dtos);
    #endregion
    #region Sync
    long Core_UserGroupGetCount();
    ICollection<IUserGroupViewModel> Core_UserGroupGets(params OrderUserGroup[] orderBy);
    ICollection<IUserGroupViewModel> Core_UserGroupGets(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    IUserGroupViewModel Core_UserGroupGet(long id);
    ICollection<IUserGroupHistViewModel> Core_UserGroupHistGets(long id);
    IUserGroupHistViewModel Core_UserGroupHistEntryGet(long histId);
    void Core_UserGroupHistDelete(long histId);
    void Core_UserGroupSave(IUserGroupViewModel dto);
    void Core_UserGroupMerge(IUserGroupViewModel dto);
    void Core_UserGroupDelete(long id);
    bool Core_UserGroupHasChanged(IUserGroupViewModel dto);
    void Core_UserGroupBulkInsert(ICollection<IUserGroupViewModel> dtos);
    void Core_UserGroupBulkInsert(ICollection<IUserGroupViewModel> dtos, bool identityInsert);
    void Core_UserGroup_TempBulkInsert(ICollection<IUserGroupViewModel> dtos);
    void Core_UserGroup_TempBulkInsert(ICollection<IUserGroupViewModel> dtos, bool identityInsert);
    void Core_UserGroupBulkMerge(ICollection<IUserGroupViewModel> dtos);
    void Core_UserGroupBulkMerge(ICollection<IUserGroupViewModel> dtos, bool identityInsert);
    void Core_UserGroupBulkUpdate(ICollection<IUserGroupViewModel> dtos);
    void Core_UserGroupBulkDelete(ICollection<IUserGroupViewModel> dtos);
    #endregion
  }
}


