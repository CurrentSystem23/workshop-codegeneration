using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IUserRightDao
  {
    #region Async
    Task<long> UserRightGetCountAsync();
    Task<ICollection<IUserRightDto>> UserRightGetsAsync(params OrderUserRight[] orderBy);
    Task<ICollection<IUserRightDto>> UserRightGetsAsync(int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    Task<IUserRightDto> UserRightGetAsync(long id);
    Task<ICollection<IUserRightHistDto>> UserRightHistGetsAsync(long id);
    Task<IUserRightHistDto> UserRightHistEntryGetAsync(long histId);
    Task UserRightHistDeleteAsync(long histId);
    Task UserRightSaveAsync(IUserRightDto dto);
    Task UserRightMergeAsync(IUserRightDto dto);
    Task UserRightDeleteAsync(long id);
    Task<bool> UserRightHasChangedAsync(IUserRightDto dto);
    Task UserRightBulkInsertAsync(ICollection<IUserRightDto> dtos);
    Task UserRightBulkInsertAsync(ICollection<IUserRightDto> dtos, bool identityInsert);
    Task UserRight_TempBulkInsertAsync(ICollection<IUserRightDto> dtos);
    Task UserRight_TempBulkInsertAsync(ICollection<IUserRightDto> dtos, bool identityInsert);
    Task UserRightBulkMergeAsync(ICollection<IUserRightDto> dtos);
    Task UserRightBulkMergeAsync(ICollection<IUserRightDto> dtos, bool identityInsert);
    Task UserRightBulkUpdateAsync(ICollection<IUserRightDto> dtos);
    Task UserRightBulkDeleteAsync(ICollection<IUserRightDto> dtos);
    #endregion
    #region Sync
    long UserRightGetCount();
    ICollection<IUserRightDto> UserRightGets(params OrderUserRight[] orderBy);
    ICollection<IUserRightDto> UserRightGets(int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    IUserRightDto UserRightGet(long id);
    ICollection<IUserRightHistDto> UserRightHistGets(long id);
    IUserRightHistDto UserRightHistEntryGet(long histId);
    void UserRightHistDelete(long histId);
    void UserRightSave(IUserRightDto dto);
    void UserRightMerge(IUserRightDto dto);
    void UserRightDelete(long id);
    bool UserRightHasChanged(IUserRightDto dto);
    void UserRightBulkInsert(ICollection<IUserRightDto> dtos);
    void UserRightBulkInsert(ICollection<IUserRightDto> dtos, bool identityInsert);
    void UserRight_TempBulkInsert(ICollection<IUserRightDto> dtos);
    void UserRight_TempBulkInsert(ICollection<IUserRightDto> dtos, bool identityInsert);
    void UserRightBulkMerge(ICollection<IUserRightDto> dtos);
    void UserRightBulkMerge(ICollection<IUserRightDto> dtos, bool identityInsert);
    void UserRightBulkUpdate(ICollection<IUserRightDto> dtos);
    void UserRightBulkDelete(ICollection<IUserRightDto> dtos);
    #endregion
  }
  public partial interface IUserRightInternalDao : IUserRightDao
  {
    #region Async
    Task<long> UserRightGetCountAsync(WhereClause whereClause);
    Task<ICollection<IUserRightDto>> UserRightGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IUserRightDto>> UserRightGetsAsync(WhereClause whereClause, bool distinct, params OrderUserRight[] orderBy);
    Task<ICollection<IUserRightDto>> UserRightGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    Task<ICollection<IUserRightDto>> UserRightGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    Task<IUserRightDto> UserRightGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IUserRightHistDto>> UserRightHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IUserRightHistDto> UserRightHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserRightHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task UserRightHistDeleteAsync(WhereClause whereClause);
    Task UserRightHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task UserRightSaveAsync(SqlConnection con, SqlCommand cmd, IUserRightDto dto);
    Task UserRightMergeAsync(SqlConnection con, SqlCommand cmd, IUserRightDto dto);
    Task UserRightDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task UserRightDeleteAsync(WhereClause whereClause);
    Task UserRightDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> UserRightHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserRightDto dto);
    #endregion
    #region Sync
    long UserRightGetCount(WhereClause whereClause);
    ICollection<IUserRightDto> UserRightGets(SqlConnection con, SqlCommand cmd);
    ICollection<IUserRightDto> UserRightGets(WhereClause whereClause, bool distinct, params OrderUserRight[] orderBy);
    ICollection<IUserRightDto> UserRightGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    ICollection<IUserRightDto> UserRightGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy);
    IUserRightDto UserRightGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IUserRightHistDto> UserRightHistGets(SqlConnection con, SqlCommand cmd, long id);
    IUserRightHistDto UserRightHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void UserRightHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void UserRightHistDelete(WhereClause whereClause);
    void UserRightHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void UserRightSave(SqlConnection con, SqlCommand cmd, IUserRightDto dto);
    void UserRightMerge(SqlConnection con, SqlCommand cmd, IUserRightDto dto);
    void UserRightDelete(SqlConnection con, SqlCommand cmd, long id);
    void UserRightDelete(WhereClause whereClause);
    void UserRightDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool UserRightHasChanged(SqlConnection con, SqlCommand cmd, IUserRightDto dto);
    #endregion
  }
}


