using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IUserGroupDao
  {
    #region Async
    Task<long> UserGroupGetCountAsync();
    Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(params OrderUserGroup[] orderBy);
    Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    Task<IUserGroupDto> UserGroupGetAsync(long id);
    Task<ICollection<IUserGroupHistDto>> UserGroupHistGetsAsync(long id);
    Task<IUserGroupHistDto> UserGroupHistEntryGetAsync(long histId);
    Task UserGroupHistDeleteAsync(long histId);
    Task UserGroupSaveAsync(IUserGroupDto dto);
    Task UserGroupMergeAsync(IUserGroupDto dto);
    Task UserGroupDeleteAsync(long id);
    Task<bool> UserGroupHasChangedAsync(IUserGroupDto dto);
    Task UserGroupBulkInsertAsync(ICollection<IUserGroupDto> dtos);
    Task UserGroupBulkInsertAsync(ICollection<IUserGroupDto> dtos, bool identityInsert);
    Task UserGroup_TempBulkInsertAsync(ICollection<IUserGroupDto> dtos);
    Task UserGroup_TempBulkInsertAsync(ICollection<IUserGroupDto> dtos, bool identityInsert);
    Task UserGroupBulkMergeAsync(ICollection<IUserGroupDto> dtos);
    Task UserGroupBulkMergeAsync(ICollection<IUserGroupDto> dtos, bool identityInsert);
    Task UserGroupBulkUpdateAsync(ICollection<IUserGroupDto> dtos);
    Task UserGroupBulkDeleteAsync(ICollection<IUserGroupDto> dtos);
    #endregion
    #region Sync
    long UserGroupGetCount();
    ICollection<IUserGroupDto> UserGroupGets(params OrderUserGroup[] orderBy);
    ICollection<IUserGroupDto> UserGroupGets(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    IUserGroupDto UserGroupGet(long id);
    ICollection<IUserGroupHistDto> UserGroupHistGets(long id);
    IUserGroupHistDto UserGroupHistEntryGet(long histId);
    void UserGroupHistDelete(long histId);
    void UserGroupSave(IUserGroupDto dto);
    void UserGroupMerge(IUserGroupDto dto);
    void UserGroupDelete(long id);
    bool UserGroupHasChanged(IUserGroupDto dto);
    void UserGroupBulkInsert(ICollection<IUserGroupDto> dtos);
    void UserGroupBulkInsert(ICollection<IUserGroupDto> dtos, bool identityInsert);
    void UserGroup_TempBulkInsert(ICollection<IUserGroupDto> dtos);
    void UserGroup_TempBulkInsert(ICollection<IUserGroupDto> dtos, bool identityInsert);
    void UserGroupBulkMerge(ICollection<IUserGroupDto> dtos);
    void UserGroupBulkMerge(ICollection<IUserGroupDto> dtos, bool identityInsert);
    void UserGroupBulkUpdate(ICollection<IUserGroupDto> dtos);
    void UserGroupBulkDelete(ICollection<IUserGroupDto> dtos);
    #endregion
  }
  public partial interface IUserGroupInternalDao : IUserGroupDao
  {
    #region Async
    Task<long> UserGroupGetCountAsync(WhereClause whereClause);
    Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(WhereClause whereClause, bool distinct, params OrderUserGroup[] orderBy);
    Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    Task<IUserGroupDto> UserGroupGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IUserGroupHistDto>> UserGroupHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IUserGroupHistDto> UserGroupHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserGroupHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserGroupHistDeleteAsync(WhereClause whereClause);
    Task UserGroupHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task UserGroupSaveAsync(SqlConnection con, SqlCommand cmd, IUserGroupDto dto);
    Task UserGroupMergeAsync(SqlConnection con, SqlCommand cmd, IUserGroupDto dto);
    Task UserGroupDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task UserGroupDeleteAsync(WhereClause whereClause);
    Task UserGroupDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> UserGroupHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserGroupDto dto);
    #endregion
    #region Sync
    long UserGroupGetCount(WhereClause whereClause);
    ICollection<IUserGroupDto> UserGroupGets(SqlConnection con, SqlCommand cmd);
    ICollection<IUserGroupDto> UserGroupGets(WhereClause whereClause, bool distinct, params OrderUserGroup[] orderBy);
    ICollection<IUserGroupDto> UserGroupGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    ICollection<IUserGroupDto> UserGroupGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy);
    IUserGroupDto UserGroupGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IUserGroupHistDto> UserGroupHistGets(SqlConnection con, SqlCommand cmd, long id);
    IUserGroupHistDto UserGroupHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void UserGroupHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void UserGroupHistDelete(WhereClause whereClause);
    void UserGroupHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void UserGroupSave(SqlConnection con, SqlCommand cmd, IUserGroupDto dto);
    void UserGroupMerge(SqlConnection con, SqlCommand cmd, IUserGroupDto dto);
    void UserGroupDelete(SqlConnection con, SqlCommand cmd, long id);
    void UserGroupDelete(WhereClause whereClause);
    void UserGroupDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool UserGroupHasChanged(SqlConnection con, SqlCommand cmd, IUserGroupDto dto);
    #endregion
  }
}


