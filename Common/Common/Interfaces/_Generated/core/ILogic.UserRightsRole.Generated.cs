using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_UserRightsRoleGetCountAsync();
    Task<ICollection<IUserRightsRoleViewModel>> Core_UserRightsRoleGetsAsync(params OrderUserRightsRole[] orderBy);
    Task<ICollection<IUserRightsRoleViewModel>> Core_UserRightsRoleGetsAsync(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    Task<IUserRightsRoleViewModel> Core_UserRightsRoleGetAsync(long id);
    Task<ICollection<IUserRightsRoleHistViewModel>> Core_UserRightsRoleHistGetsAsync(long id);
    Task<IUserRightsRoleHistViewModel> Core_UserRightsRoleHistEntryGetAsync(long histId);
    Task Core_UserRightsRoleHistDeleteAsync(long histId);
    Task Core_UserRightsRoleSaveAsync(IUserRightsRoleViewModel dto);
    Task Core_UserRightsRoleMergeAsync(IUserRightsRoleViewModel dto);
    Task Core_UserRightsRoleDeleteAsync(long id);
    Task<bool> Core_UserRightsRoleHasChangedAsync(IUserRightsRoleViewModel dto);
    Task Core_UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos);
    Task Core_UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert);
    Task Core_UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos);
    Task Core_UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert);
    Task Core_UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleViewModel> dtos);
    Task Core_UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert);
    Task Core_UserRightsRoleBulkUpdateAsync(ICollection<IUserRightsRoleViewModel> dtos);
    Task Core_UserRightsRoleBulkDeleteAsync(ICollection<IUserRightsRoleViewModel> dtos);
    #endregion
    #region Sync
    long Core_UserRightsRoleGetCount();
    ICollection<IUserRightsRoleViewModel> Core_UserRightsRoleGets(params OrderUserRightsRole[] orderBy);
    ICollection<IUserRightsRoleViewModel> Core_UserRightsRoleGets(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    IUserRightsRoleViewModel Core_UserRightsRoleGet(long id);
    ICollection<IUserRightsRoleHistViewModel> Core_UserRightsRoleHistGets(long id);
    IUserRightsRoleHistViewModel Core_UserRightsRoleHistEntryGet(long histId);
    void Core_UserRightsRoleHistDelete(long histId);
    void Core_UserRightsRoleSave(IUserRightsRoleViewModel dto);
    void Core_UserRightsRoleMerge(IUserRightsRoleViewModel dto);
    void Core_UserRightsRoleDelete(long id);
    bool Core_UserRightsRoleHasChanged(IUserRightsRoleViewModel dto);
    void Core_UserRightsRoleBulkInsert(ICollection<IUserRightsRoleViewModel> dtos);
    void Core_UserRightsRoleBulkInsert(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert);
    void Core_UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleViewModel> dtos);
    void Core_UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert);
    void Core_UserRightsRoleBulkMerge(ICollection<IUserRightsRoleViewModel> dtos);
    void Core_UserRightsRoleBulkMerge(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert);
    void Core_UserRightsRoleBulkUpdate(ICollection<IUserRightsRoleViewModel> dtos);
    void Core_UserRightsRoleBulkDelete(ICollection<IUserRightsRoleViewModel> dtos);
    #endregion
  }
}


