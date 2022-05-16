using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface ITenantDao
  {
    #region Async
    Task<long> TenantGetCountAsync();
    Task<ICollection<ITenantDto>> TenantGetsAsync(params OrderTenant[] orderBy);
    Task<ICollection<ITenantDto>> TenantGetsAsync(int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    Task<ITenantDto> TenantGetAsync(long id);
    Task<ICollection<ITenantHistDto>> TenantHistGetsAsync(long id);
    Task<ITenantHistDto> TenantHistEntryGetAsync(long histId);
    Task TenantHistDeleteAsync(long histId);
    Task TenantSaveAsync(ITenantDto dto);
    Task TenantMergeAsync(ITenantDto dto);
    Task TenantDeleteAsync(long id);
    Task<bool> TenantHasChangedAsync(ITenantDto dto);
    Task TenantBulkInsertAsync(ICollection<ITenantDto> dtos);
    Task TenantBulkInsertAsync(ICollection<ITenantDto> dtos, bool identityInsert);
    Task Tenant_TempBulkInsertAsync(ICollection<ITenantDto> dtos);
    Task Tenant_TempBulkInsertAsync(ICollection<ITenantDto> dtos, bool identityInsert);
    Task TenantBulkMergeAsync(ICollection<ITenantDto> dtos);
    Task TenantBulkMergeAsync(ICollection<ITenantDto> dtos, bool identityInsert);
    Task TenantBulkUpdateAsync(ICollection<ITenantDto> dtos);
    Task TenantBulkDeleteAsync(ICollection<ITenantDto> dtos);
    #endregion
    #region Sync
    long TenantGetCount();
    ICollection<ITenantDto> TenantGets(params OrderTenant[] orderBy);
    ICollection<ITenantDto> TenantGets(int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    ITenantDto TenantGet(long id);
    ICollection<ITenantHistDto> TenantHistGets(long id);
    ITenantHistDto TenantHistEntryGet(long histId);
    void TenantHistDelete(long histId);
    void TenantSave(ITenantDto dto);
    void TenantMerge(ITenantDto dto);
    void TenantDelete(long id);
    bool TenantHasChanged(ITenantDto dto);
    void TenantBulkInsert(ICollection<ITenantDto> dtos);
    void TenantBulkInsert(ICollection<ITenantDto> dtos, bool identityInsert);
    void Tenant_TempBulkInsert(ICollection<ITenantDto> dtos);
    void Tenant_TempBulkInsert(ICollection<ITenantDto> dtos, bool identityInsert);
    void TenantBulkMerge(ICollection<ITenantDto> dtos);
    void TenantBulkMerge(ICollection<ITenantDto> dtos, bool identityInsert);
    void TenantBulkUpdate(ICollection<ITenantDto> dtos);
    void TenantBulkDelete(ICollection<ITenantDto> dtos);
    #endregion
  }
  public partial interface ITenantInternalDao : ITenantDao
  {
    #region Async
    Task<long> TenantGetCountAsync(WhereClause whereClause);
    Task<ICollection<ITenantDto>> TenantGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<ITenantDto>> TenantGetsAsync(WhereClause whereClause, bool distinct, params OrderTenant[] orderBy);
    Task<ICollection<ITenantDto>> TenantGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    Task<ICollection<ITenantDto>> TenantGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    Task<ITenantDto> TenantGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<ITenantHistDto>> TenantHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ITenantHistDto> TenantHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task TenantHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task TenantHistDeleteAsync(WhereClause whereClause);
    Task TenantHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task TenantSaveAsync(SqlConnection con, SqlCommand cmd, ITenantDto dto);
    Task TenantMergeAsync(SqlConnection con, SqlCommand cmd, ITenantDto dto);
    Task TenantDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task TenantDeleteAsync(WhereClause whereClause);
    Task TenantDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> TenantHasChangedAsync(SqlConnection con, SqlCommand cmd, ITenantDto dto);
    #endregion
    #region Sync
    long TenantGetCount(WhereClause whereClause);
    ICollection<ITenantDto> TenantGets(SqlConnection con, SqlCommand cmd);
    ICollection<ITenantDto> TenantGets(WhereClause whereClause, bool distinct, params OrderTenant[] orderBy);
    ICollection<ITenantDto> TenantGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    ICollection<ITenantDto> TenantGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderTenant[] orderBy);
    ITenantDto TenantGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<ITenantHistDto> TenantHistGets(SqlConnection con, SqlCommand cmd, long id);
    ITenantHistDto TenantHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void TenantHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void TenantHistDelete(WhereClause whereClause);
    void TenantHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void TenantSave(SqlConnection con, SqlCommand cmd, ITenantDto dto);
    void TenantMerge(SqlConnection con, SqlCommand cmd, ITenantDto dto);
    void TenantDelete(SqlConnection con, SqlCommand cmd, long id);
    void TenantDelete(WhereClause whereClause);
    void TenantDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool TenantHasChanged(SqlConnection con, SqlCommand cmd, ITenantDto dto);
    #endregion
  }
}


