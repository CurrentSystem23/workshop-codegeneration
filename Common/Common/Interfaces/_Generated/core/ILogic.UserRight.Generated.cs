using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_UserRightGetCountAsync();
    Task<ICollection<IUserRightViewModel>> Core_UserRightGetsAsync(params OrderUserRight[] orderBy);
    Task<ICollection<IUserRightViewModel>> Core_UserRightGetsAsync(int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    Task<IUserRightViewModel> Core_UserRightGetAsync(long id);
    Task<ICollection<IUserRightHistViewModel>> Core_UserRightHistGetsAsync(long id);
    Task<IUserRightHistViewModel> Core_UserRightHistEntryGetAsync(long histId);
    Task Core_UserRightHistDeleteAsync(long histId);
    Task Core_UserRightSaveAsync(IUserRightViewModel dto);
    Task Core_UserRightMergeAsync(IUserRightViewModel dto);
    Task Core_UserRightDeleteAsync(long id);
    Task<bool> Core_UserRightHasChangedAsync(IUserRightViewModel dto);
    Task Core_UserRightBulkInsertAsync(ICollection<IUserRightViewModel> dtos);
    Task Core_UserRightBulkInsertAsync(ICollection<IUserRightViewModel> dtos, bool identityInsert);
    Task Core_UserRight_TempBulkInsertAsync(ICollection<IUserRightViewModel> dtos);
    Task Core_UserRight_TempBulkInsertAsync(ICollection<IUserRightViewModel> dtos, bool identityInsert);
    Task Core_UserRightBulkMergeAsync(ICollection<IUserRightViewModel> dtos);
    Task Core_UserRightBulkMergeAsync(ICollection<IUserRightViewModel> dtos, bool identityInsert);
    Task Core_UserRightBulkUpdateAsync(ICollection<IUserRightViewModel> dtos);
    Task Core_UserRightBulkDeleteAsync(ICollection<IUserRightViewModel> dtos);
    #endregion
    #region Sync
    long Core_UserRightGetCount();
    ICollection<IUserRightViewModel> Core_UserRightGets(params OrderUserRight[] orderBy);
    ICollection<IUserRightViewModel> Core_UserRightGets(int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    IUserRightViewModel Core_UserRightGet(long id);
    ICollection<IUserRightHistViewModel> Core_UserRightHistGets(long id);
    IUserRightHistViewModel Core_UserRightHistEntryGet(long histId);
    void Core_UserRightHistDelete(long histId);
    void Core_UserRightSave(IUserRightViewModel dto);
    void Core_UserRightMerge(IUserRightViewModel dto);
    void Core_UserRightDelete(long id);
    bool Core_UserRightHasChanged(IUserRightViewModel dto);
    void Core_UserRightBulkInsert(ICollection<IUserRightViewModel> dtos);
    void Core_UserRightBulkInsert(ICollection<IUserRightViewModel> dtos, bool identityInsert);
    void Core_UserRight_TempBulkInsert(ICollection<IUserRightViewModel> dtos);
    void Core_UserRight_TempBulkInsert(ICollection<IUserRightViewModel> dtos, bool identityInsert);
    void Core_UserRightBulkMerge(ICollection<IUserRightViewModel> dtos);
    void Core_UserRightBulkMerge(ICollection<IUserRightViewModel> dtos, bool identityInsert);
    void Core_UserRightBulkUpdate(ICollection<IUserRightViewModel> dtos);
    void Core_UserRightBulkDelete(ICollection<IUserRightViewModel> dtos);
    #endregion
  }
}


