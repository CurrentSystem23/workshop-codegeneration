using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_UserGetCountAsync();
    Task<ICollection<IUserViewModel>> Core_UserGetsAsync(params OrderUser[] orderBy);
    Task<ICollection<IUserViewModel>> Core_UserGetsAsync(int? pageNum, int? pageSize, params OrderUser[] orderBy);
    Task<IUserViewModel> Core_UserGetAsync(long id);
    Task<ICollection<IUserHistViewModel>> Core_UserHistGetsAsync(long id);
    Task<IUserHistViewModel> Core_UserHistEntryGetAsync(long histId);
    Task Core_UserHistDeleteAsync(long histId);
    Task Core_UserSaveAsync(IUserViewModel dto);
    Task Core_UserMergeAsync(IUserViewModel dto);
    Task Core_UserDeleteAsync(long id);
    Task<bool> Core_UserHasChangedAsync(IUserViewModel dto);
    Task Core_UserBulkInsertAsync(ICollection<IUserViewModel> dtos);
    Task Core_UserBulkInsertAsync(ICollection<IUserViewModel> dtos, bool identityInsert);
    Task Core_User_TempBulkInsertAsync(ICollection<IUserViewModel> dtos);
    Task Core_User_TempBulkInsertAsync(ICollection<IUserViewModel> dtos, bool identityInsert);
    Task Core_UserBulkMergeAsync(ICollection<IUserViewModel> dtos);
    Task Core_UserBulkMergeAsync(ICollection<IUserViewModel> dtos, bool identityInsert);
    Task Core_UserBulkUpdateAsync(ICollection<IUserViewModel> dtos);
    Task Core_UserBulkDeleteAsync(ICollection<IUserViewModel> dtos);
    #endregion
    #region Sync
    long Core_UserGetCount();
    ICollection<IUserViewModel> Core_UserGets(params OrderUser[] orderBy);
    ICollection<IUserViewModel> Core_UserGets(int? pageNum, int? pageSize, params OrderUser[] orderBy);
    IUserViewModel Core_UserGet(long id);
    ICollection<IUserHistViewModel> Core_UserHistGets(long id);
    IUserHistViewModel Core_UserHistEntryGet(long histId);
    void Core_UserHistDelete(long histId);
    void Core_UserSave(IUserViewModel dto);
    void Core_UserMerge(IUserViewModel dto);
    void Core_UserDelete(long id);
    bool Core_UserHasChanged(IUserViewModel dto);
    void Core_UserBulkInsert(ICollection<IUserViewModel> dtos);
    void Core_UserBulkInsert(ICollection<IUserViewModel> dtos, bool identityInsert);
    void Core_User_TempBulkInsert(ICollection<IUserViewModel> dtos);
    void Core_User_TempBulkInsert(ICollection<IUserViewModel> dtos, bool identityInsert);
    void Core_UserBulkMerge(ICollection<IUserViewModel> dtos);
    void Core_UserBulkMerge(ICollection<IUserViewModel> dtos, bool identityInsert);
    void Core_UserBulkUpdate(ICollection<IUserViewModel> dtos);
    void Core_UserBulkDelete(ICollection<IUserViewModel> dtos);
    #endregion
  }
}


