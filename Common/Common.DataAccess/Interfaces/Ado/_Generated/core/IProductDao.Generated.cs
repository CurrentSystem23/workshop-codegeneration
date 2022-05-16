using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IProductDao
  {
    #region Async
    Task<long> ProductGetCountAsync();
    Task<ICollection<IProductDto>> ProductGetsAsync(params OrderProduct[] orderBy);
    Task<ICollection<IProductDto>> ProductGetsAsync(int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    Task<IProductDto> ProductGetAsync(long id);
    Task<ICollection<IProductHistDto>> ProductHistGetsAsync(long id);
    Task<IProductHistDto> ProductHistEntryGetAsync(long histId);
    Task ProductHistDeleteAsync(long histId);
    Task ProductSaveAsync(IProductDto dto);
    Task ProductMergeAsync(IProductDto dto);
    Task ProductDeleteAsync(long id);
    Task<bool> ProductHasChangedAsync(IProductDto dto);
    Task ProductBulkInsertAsync(ICollection<IProductDto> dtos);
    Task ProductBulkInsertAsync(ICollection<IProductDto> dtos, bool identityInsert);
    Task Product_TempBulkInsertAsync(ICollection<IProductDto> dtos);
    Task Product_TempBulkInsertAsync(ICollection<IProductDto> dtos, bool identityInsert);
    Task ProductBulkMergeAsync(ICollection<IProductDto> dtos);
    Task ProductBulkMergeAsync(ICollection<IProductDto> dtos, bool identityInsert);
    Task ProductBulkUpdateAsync(ICollection<IProductDto> dtos);
    Task ProductBulkDeleteAsync(ICollection<IProductDto> dtos);
    #endregion
    #region Sync
    long ProductGetCount();
    ICollection<IProductDto> ProductGets(params OrderProduct[] orderBy);
    ICollection<IProductDto> ProductGets(int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    IProductDto ProductGet(long id);
    ICollection<IProductHistDto> ProductHistGets(long id);
    IProductHistDto ProductHistEntryGet(long histId);
    void ProductHistDelete(long histId);
    void ProductSave(IProductDto dto);
    void ProductMerge(IProductDto dto);
    void ProductDelete(long id);
    bool ProductHasChanged(IProductDto dto);
    void ProductBulkInsert(ICollection<IProductDto> dtos);
    void ProductBulkInsert(ICollection<IProductDto> dtos, bool identityInsert);
    void Product_TempBulkInsert(ICollection<IProductDto> dtos);
    void Product_TempBulkInsert(ICollection<IProductDto> dtos, bool identityInsert);
    void ProductBulkMerge(ICollection<IProductDto> dtos);
    void ProductBulkMerge(ICollection<IProductDto> dtos, bool identityInsert);
    void ProductBulkUpdate(ICollection<IProductDto> dtos);
    void ProductBulkDelete(ICollection<IProductDto> dtos);
    #endregion
  }
  public partial interface IProductInternalDao : IProductDao
  {
    #region Async
    Task<long> ProductGetCountAsync(WhereClause whereClause);
    Task<ICollection<IProductDto>> ProductGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IProductDto>> ProductGetsAsync(WhereClause whereClause, bool distinct, params OrderProduct[] orderBy);
    Task<ICollection<IProductDto>> ProductGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    Task<ICollection<IProductDto>> ProductGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    Task<IProductDto> ProductGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IProductHistDto>> ProductHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IProductHistDto> ProductHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task ProductHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task ProductHistDeleteAsync(WhereClause whereClause);
    Task ProductHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task ProductSaveAsync(SqlConnection con, SqlCommand cmd, IProductDto dto);
    Task ProductMergeAsync(SqlConnection con, SqlCommand cmd, IProductDto dto);
    Task ProductDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task ProductDeleteAsync(WhereClause whereClause);
    Task ProductDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> ProductHasChangedAsync(SqlConnection con, SqlCommand cmd, IProductDto dto);
    #endregion
    #region Sync
    long ProductGetCount(WhereClause whereClause);
    ICollection<IProductDto> ProductGets(SqlConnection con, SqlCommand cmd);
    ICollection<IProductDto> ProductGets(WhereClause whereClause, bool distinct, params OrderProduct[] orderBy);
    ICollection<IProductDto> ProductGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    ICollection<IProductDto> ProductGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    IProductDto ProductGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IProductHistDto> ProductHistGets(SqlConnection con, SqlCommand cmd, long id);
    IProductHistDto ProductHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void ProductHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void ProductHistDelete(WhereClause whereClause);
    void ProductHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void ProductSave(SqlConnection con, SqlCommand cmd, IProductDto dto);
    void ProductMerge(SqlConnection con, SqlCommand cmd, IProductDto dto);
    void ProductDelete(SqlConnection con, SqlCommand cmd, long id);
    void ProductDelete(WhereClause whereClause);
    void ProductDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool ProductHasChanged(SqlConnection con, SqlCommand cmd, IProductDto dto);
    #endregion
  }
}


