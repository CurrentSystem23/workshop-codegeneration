using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IStockDao
  {
    #region Async
    Task<long> StockGetCountAsync();
    Task<ICollection<IStockDto>> StockGetsAsync(params OrderStock[] orderBy);
    Task<ICollection<IStockDto>> StockGetsAsync(int? pageNum, int? pageSize, params OrderStock[] orderBy);
    Task<IStockDto> StockGetAsync(long id);
    Task<ICollection<IStockHistDto>> StockHistGetsAsync(long id);
    Task<IStockHistDto> StockHistEntryGetAsync(long histId);
    Task StockHistDeleteAsync(long histId);
    Task StockSaveAsync(IStockDto dto);
    Task StockMergeAsync(IStockDto dto);
    Task StockDeleteAsync(long id);
    Task<bool> StockHasChangedAsync(IStockDto dto);
    Task StockBulkInsertAsync(ICollection<IStockDto> dtos);
    Task StockBulkInsertAsync(ICollection<IStockDto> dtos, bool identityInsert);
    Task Stock_TempBulkInsertAsync(ICollection<IStockDto> dtos);
    Task Stock_TempBulkInsertAsync(ICollection<IStockDto> dtos, bool identityInsert);
    Task StockBulkMergeAsync(ICollection<IStockDto> dtos);
    Task StockBulkMergeAsync(ICollection<IStockDto> dtos, bool identityInsert);
    Task StockBulkUpdateAsync(ICollection<IStockDto> dtos);
    Task StockBulkDeleteAsync(ICollection<IStockDto> dtos);
    #endregion
    #region Sync
    long StockGetCount();
    ICollection<IStockDto> StockGets(params OrderStock[] orderBy);
    ICollection<IStockDto> StockGets(int? pageNum, int? pageSize, params OrderStock[] orderBy);
    IStockDto StockGet(long id);
    ICollection<IStockHistDto> StockHistGets(long id);
    IStockHistDto StockHistEntryGet(long histId);
    void StockHistDelete(long histId);
    void StockSave(IStockDto dto);
    void StockMerge(IStockDto dto);
    void StockDelete(long id);
    bool StockHasChanged(IStockDto dto);
    void StockBulkInsert(ICollection<IStockDto> dtos);
    void StockBulkInsert(ICollection<IStockDto> dtos, bool identityInsert);
    void Stock_TempBulkInsert(ICollection<IStockDto> dtos);
    void Stock_TempBulkInsert(ICollection<IStockDto> dtos, bool identityInsert);
    void StockBulkMerge(ICollection<IStockDto> dtos);
    void StockBulkMerge(ICollection<IStockDto> dtos, bool identityInsert);
    void StockBulkUpdate(ICollection<IStockDto> dtos);
    void StockBulkDelete(ICollection<IStockDto> dtos);
    #endregion
  }
  public partial interface IStockInternalDao : IStockDao
  {
    #region Async
    Task<long> StockGetCountAsync(WhereClause whereClause);
    Task<ICollection<IStockDto>> StockGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IStockDto>> StockGetsAsync(WhereClause whereClause, bool distinct, params OrderStock[] orderBy);
    Task<ICollection<IStockDto>> StockGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy);
    Task<ICollection<IStockDto>> StockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy);
    Task<IStockDto> StockGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IStockHistDto>> StockHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IStockHistDto> StockHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task StockHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task StockHistDeleteAsync(WhereClause whereClause);
    Task StockHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task StockSaveAsync(SqlConnection con, SqlCommand cmd, IStockDto dto);
    Task StockMergeAsync(SqlConnection con, SqlCommand cmd, IStockDto dto);
    Task StockDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task StockDeleteAsync(WhereClause whereClause);
    Task StockDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> StockHasChangedAsync(SqlConnection con, SqlCommand cmd, IStockDto dto);
    #endregion
    #region Sync
    long StockGetCount(WhereClause whereClause);
    ICollection<IStockDto> StockGets(SqlConnection con, SqlCommand cmd);
    ICollection<IStockDto> StockGets(WhereClause whereClause, bool distinct, params OrderStock[] orderBy);
    ICollection<IStockDto> StockGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy);
    ICollection<IStockDto> StockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy);
    IStockDto StockGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IStockHistDto> StockHistGets(SqlConnection con, SqlCommand cmd, long id);
    IStockHistDto StockHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void StockHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void StockHistDelete(WhereClause whereClause);
    void StockHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void StockSave(SqlConnection con, SqlCommand cmd, IStockDto dto);
    void StockMerge(SqlConnection con, SqlCommand cmd, IStockDto dto);
    void StockDelete(SqlConnection con, SqlCommand cmd, long id);
    void StockDelete(WhereClause whereClause);
    void StockDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool StockHasChanged(SqlConnection con, SqlCommand cmd, IStockDto dto);
    #endregion
  }
}


