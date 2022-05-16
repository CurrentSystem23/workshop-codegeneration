using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IUserRightsRoleDao
  {
    #region Async
    Task<long> UserRightsRoleGetCountAsync();
    Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(params OrderUserRightsRole[] orderBy);
    Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    Task<IUserRightsRoleDto> UserRightsRoleGetAsync(long id);
    Task<ICollection<IUserRightsRoleHistDto>> UserRightsRoleHistGetsAsync(long id);
    Task<IUserRightsRoleHistDto> UserRightsRoleHistEntryGetAsync(long histId);
    Task UserRightsRoleHistDeleteAsync(long histId);
    Task UserRightsRoleSaveAsync(IUserRightsRoleDto dto);
    Task UserRightsRoleMergeAsync(IUserRightsRoleDto dto);
    Task UserRightsRoleDeleteAsync(long id);
    Task<bool> UserRightsRoleHasChangedAsync(IUserRightsRoleDto dto);
    Task UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos);
    Task UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos, bool identityInsert);
    Task UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos);
    Task UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos, bool identityInsert);
    Task UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleDto> dtos);
    Task UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleDto> dtos, bool identityInsert);
    Task UserRightsRoleBulkUpdateAsync(ICollection<IUserRightsRoleDto> dtos);
    Task UserRightsRoleBulkDeleteAsync(ICollection<IUserRightsRoleDto> dtos);
    #endregion
    #region Sync
    long UserRightsRoleGetCount();
    ICollection<IUserRightsRoleDto> UserRightsRoleGets(params OrderUserRightsRole[] orderBy);
    ICollection<IUserRightsRoleDto> UserRightsRoleGets(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    IUserRightsRoleDto UserRightsRoleGet(long id);
    ICollection<IUserRightsRoleHistDto> UserRightsRoleHistGets(long id);
    IUserRightsRoleHistDto UserRightsRoleHistEntryGet(long histId);
    void UserRightsRoleHistDelete(long histId);
    void UserRightsRoleSave(IUserRightsRoleDto dto);
    void UserRightsRoleMerge(IUserRightsRoleDto dto);
    void UserRightsRoleDelete(long id);
    bool UserRightsRoleHasChanged(IUserRightsRoleDto dto);
    void UserRightsRoleBulkInsert(ICollection<IUserRightsRoleDto> dtos);
    void UserRightsRoleBulkInsert(ICollection<IUserRightsRoleDto> dtos, bool identityInsert);
    void UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleDto> dtos);
    void UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleDto> dtos, bool identityInsert);
    void UserRightsRoleBulkMerge(ICollection<IUserRightsRoleDto> dtos);
    void UserRightsRoleBulkMerge(ICollection<IUserRightsRoleDto> dtos, bool identityInsert);
    void UserRightsRoleBulkUpdate(ICollection<IUserRightsRoleDto> dtos);
    void UserRightsRoleBulkDelete(ICollection<IUserRightsRoleDto> dtos);
    #endregion
  }
  public partial interface IUserRightsRoleInternalDao : IUserRightsRoleDao
  {
    #region Async
    Task<long> UserRightsRoleGetCountAsync(WhereClause whereClause);
    Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(WhereClause whereClause, bool distinct, params OrderUserRightsRole[] orderBy);
    Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    Task<IUserRightsRoleDto> UserRightsRoleGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IUserRightsRoleHistDto>> UserRightsRoleHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IUserRightsRoleHistDto> UserRightsRoleHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserRightsRoleHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserRightsRoleHistDeleteAsync(WhereClause whereClause);
    Task UserRightsRoleHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task UserRightsRoleSaveAsync(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto);
    Task UserRightsRoleMergeAsync(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto);
    Task UserRightsRoleDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task UserRightsRoleDeleteAsync(WhereClause whereClause);
    Task UserRightsRoleDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> UserRightsRoleHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto);
    #endregion
    #region Sync
    long UserRightsRoleGetCount(WhereClause whereClause);
    ICollection<IUserRightsRoleDto> UserRightsRoleGets(SqlConnection con, SqlCommand cmd);
    ICollection<IUserRightsRoleDto> UserRightsRoleGets(WhereClause whereClause, bool distinct, params OrderUserRightsRole[] orderBy);
    ICollection<IUserRightsRoleDto> UserRightsRoleGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    ICollection<IUserRightsRoleDto> UserRightsRoleGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy);
    IUserRightsRoleDto UserRightsRoleGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IUserRightsRoleHistDto> UserRightsRoleHistGets(SqlConnection con, SqlCommand cmd, long id);
    IUserRightsRoleHistDto UserRightsRoleHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void UserRightsRoleHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void UserRightsRoleHistDelete(WhereClause whereClause);
    void UserRightsRoleHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void UserRightsRoleSave(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto);
    void UserRightsRoleMerge(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto);
    void UserRightsRoleDelete(SqlConnection con, SqlCommand cmd, long id);
    void UserRightsRoleDelete(WhereClause whereClause);
    void UserRightsRoleDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool UserRightsRoleHasChanged(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto);
    #endregion
  }
}


