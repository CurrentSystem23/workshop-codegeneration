using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface ICurrencyDao
  {
    #region Async
    Task<long> CurrencyGetCountAsync();
    Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(params OrderCurrency[] orderBy);
    Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    Task<ICurrencyDto> CurrencyGetAsync(long id);
    Task<ICollection<ICurrencyHistDto>> CurrencyHistGetsAsync(long id);
    Task<ICurrencyHistDto> CurrencyHistEntryGetAsync(long histId);
    Task CurrencyHistDeleteAsync(long histId);
    Task CurrencySaveAsync(ICurrencyDto dto);
    Task CurrencyMergeAsync(ICurrencyDto dto);
    Task CurrencyDeleteAsync(long id);
    Task<bool> CurrencyHasChangedAsync(ICurrencyDto dto);
    Task CurrencyBulkInsertAsync(ICollection<ICurrencyDto> dtos);
    Task CurrencyBulkInsertAsync(ICollection<ICurrencyDto> dtos, bool identityInsert);
    Task Currency_TempBulkInsertAsync(ICollection<ICurrencyDto> dtos);
    Task Currency_TempBulkInsertAsync(ICollection<ICurrencyDto> dtos, bool identityInsert);
    Task CurrencyBulkMergeAsync(ICollection<ICurrencyDto> dtos);
    Task CurrencyBulkMergeAsync(ICollection<ICurrencyDto> dtos, bool identityInsert);
    Task CurrencyBulkUpdateAsync(ICollection<ICurrencyDto> dtos);
    Task CurrencyBulkDeleteAsync(ICollection<ICurrencyDto> dtos);
    #endregion
    #region Sync
    long CurrencyGetCount();
    ICollection<ICurrencyDto> CurrencyGets(params OrderCurrency[] orderBy);
    ICollection<ICurrencyDto> CurrencyGets(int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    ICurrencyDto CurrencyGet(long id);
    ICollection<ICurrencyHistDto> CurrencyHistGets(long id);
    ICurrencyHistDto CurrencyHistEntryGet(long histId);
    void CurrencyHistDelete(long histId);
    void CurrencySave(ICurrencyDto dto);
    void CurrencyMerge(ICurrencyDto dto);
    void CurrencyDelete(long id);
    bool CurrencyHasChanged(ICurrencyDto dto);
    void CurrencyBulkInsert(ICollection<ICurrencyDto> dtos);
    void CurrencyBulkInsert(ICollection<ICurrencyDto> dtos, bool identityInsert);
    void Currency_TempBulkInsert(ICollection<ICurrencyDto> dtos);
    void Currency_TempBulkInsert(ICollection<ICurrencyDto> dtos, bool identityInsert);
    void CurrencyBulkMerge(ICollection<ICurrencyDto> dtos);
    void CurrencyBulkMerge(ICollection<ICurrencyDto> dtos, bool identityInsert);
    void CurrencyBulkUpdate(ICollection<ICurrencyDto> dtos);
    void CurrencyBulkDelete(ICollection<ICurrencyDto> dtos);
    #endregion
  }
  public partial interface ICurrencyInternalDao : ICurrencyDao
  {
    #region Async
    Task<long> CurrencyGetCountAsync(WhereClause whereClause);
    Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(WhereClause whereClause, bool distinct, params OrderCurrency[] orderBy);
    Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    Task<ICurrencyDto> CurrencyGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<ICurrencyHistDto>> CurrencyHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICurrencyHistDto> CurrencyHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task CurrencyHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task CurrencyHistDeleteAsync(WhereClause whereClause);
    Task CurrencyHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task CurrencySaveAsync(SqlConnection con, SqlCommand cmd, ICurrencyDto dto);
    Task CurrencyMergeAsync(SqlConnection con, SqlCommand cmd, ICurrencyDto dto);
    Task CurrencyDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task CurrencyDeleteAsync(WhereClause whereClause);
    Task CurrencyDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> CurrencyHasChangedAsync(SqlConnection con, SqlCommand cmd, ICurrencyDto dto);
    #endregion
    #region Sync
    long CurrencyGetCount(WhereClause whereClause);
    ICollection<ICurrencyDto> CurrencyGets(SqlConnection con, SqlCommand cmd);
    ICollection<ICurrencyDto> CurrencyGets(WhereClause whereClause, bool distinct, params OrderCurrency[] orderBy);
    ICollection<ICurrencyDto> CurrencyGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    ICollection<ICurrencyDto> CurrencyGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy);
    ICurrencyDto CurrencyGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<ICurrencyHistDto> CurrencyHistGets(SqlConnection con, SqlCommand cmd, long id);
    ICurrencyHistDto CurrencyHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void CurrencyHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void CurrencyHistDelete(WhereClause whereClause);
    void CurrencyHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void CurrencySave(SqlConnection con, SqlCommand cmd, ICurrencyDto dto);
    void CurrencyMerge(SqlConnection con, SqlCommand cmd, ICurrencyDto dto);
    void CurrencyDelete(SqlConnection con, SqlCommand cmd, long id);
    void CurrencyDelete(WhereClause whereClause);
    void CurrencyDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool CurrencyHasChanged(SqlConnection con, SqlCommand cmd, ICurrencyDto dto);
    #endregion
  }
}


