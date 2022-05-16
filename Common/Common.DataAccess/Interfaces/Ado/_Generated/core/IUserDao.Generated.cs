using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IUserDao
  {
    #region Async
    Task<long> UserGetCountAsync();
    Task<ICollection<IUserDto>> UserGetsAsync(params OrderUser[] orderBy);
    Task<ICollection<IUserDto>> UserGetsAsync(int? pageNum, int? pageSize, params OrderUser[] orderBy);
    Task<IUserDto> UserGetAsync(long id);
    Task<ICollection<IUserHistDto>> UserHistGetsAsync(long id);
    Task<IUserHistDto> UserHistEntryGetAsync(long histId);
    Task UserHistDeleteAsync(long histId);
    Task UserSaveAsync(IUserDto dto);
    Task UserMergeAsync(IUserDto dto);
    Task UserDeleteAsync(long id);
    Task<bool> UserHasChangedAsync(IUserDto dto);
    Task UserBulkInsertAsync(ICollection<IUserDto> dtos);
    Task UserBulkInsertAsync(ICollection<IUserDto> dtos, bool identityInsert);
    Task User_TempBulkInsertAsync(ICollection<IUserDto> dtos);
    Task User_TempBulkInsertAsync(ICollection<IUserDto> dtos, bool identityInsert);
    Task UserBulkMergeAsync(ICollection<IUserDto> dtos);
    Task UserBulkMergeAsync(ICollection<IUserDto> dtos, bool identityInsert);
    Task UserBulkUpdateAsync(ICollection<IUserDto> dtos);
    Task UserBulkDeleteAsync(ICollection<IUserDto> dtos);
    #endregion
    #region Sync
    long UserGetCount();
    ICollection<IUserDto> UserGets(params OrderUser[] orderBy);
    ICollection<IUserDto> UserGets(int? pageNum, int? pageSize, params OrderUser[] orderBy);
    IUserDto UserGet(long id);
    ICollection<IUserHistDto> UserHistGets(long id);
    IUserHistDto UserHistEntryGet(long histId);
    void UserHistDelete(long histId);
    void UserSave(IUserDto dto);
    void UserMerge(IUserDto dto);
    void UserDelete(long id);
    bool UserHasChanged(IUserDto dto);
    void UserBulkInsert(ICollection<IUserDto> dtos);
    void UserBulkInsert(ICollection<IUserDto> dtos, bool identityInsert);
    void User_TempBulkInsert(ICollection<IUserDto> dtos);
    void User_TempBulkInsert(ICollection<IUserDto> dtos, bool identityInsert);
    void UserBulkMerge(ICollection<IUserDto> dtos);
    void UserBulkMerge(ICollection<IUserDto> dtos, bool identityInsert);
    void UserBulkUpdate(ICollection<IUserDto> dtos);
    void UserBulkDelete(ICollection<IUserDto> dtos);
    #endregion
  }
  public partial interface IUserInternalDao : IUserDao
  {
    #region Async
    Task<long> UserGetCountAsync(WhereClause whereClause);
    Task<ICollection<IUserDto>> UserGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IUserDto>> UserGetsAsync(WhereClause whereClause, bool distinct, params OrderUser[] orderBy);
    Task<ICollection<IUserDto>> UserGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy);
    Task<ICollection<IUserDto>> UserGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy);
    Task<IUserDto> UserGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IUserHistDto>> UserHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IUserHistDto> UserHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserHistDeleteAsync(WhereClause whereClause);
    Task UserHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task UserSaveAsync(SqlConnection con, SqlCommand cmd, IUserDto dto);
    Task UserMergeAsync(SqlConnection con, SqlCommand cmd, IUserDto dto);
    Task UserDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task UserDeleteAsync(WhereClause whereClause);
    Task UserDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> UserHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserDto dto);
    #endregion
    #region Sync
    long UserGetCount(WhereClause whereClause);
    ICollection<IUserDto> UserGets(SqlConnection con, SqlCommand cmd);
    ICollection<IUserDto> UserGets(WhereClause whereClause, bool distinct, params OrderUser[] orderBy);
    ICollection<IUserDto> UserGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy);
    ICollection<IUserDto> UserGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy);
    IUserDto UserGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IUserHistDto> UserHistGets(SqlConnection con, SqlCommand cmd, long id);
    IUserHistDto UserHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void UserHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void UserHistDelete(WhereClause whereClause);
    void UserHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void UserSave(SqlConnection con, SqlCommand cmd, IUserDto dto);
    void UserMerge(SqlConnection con, SqlCommand cmd, IUserDto dto);
    void UserDelete(SqlConnection con, SqlCommand cmd, long id);
    void UserDelete(WhereClause whereClause);
    void UserDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool UserHasChanged(SqlConnection con, SqlCommand cmd, IUserDto dto);
    #endregion
  }
}


