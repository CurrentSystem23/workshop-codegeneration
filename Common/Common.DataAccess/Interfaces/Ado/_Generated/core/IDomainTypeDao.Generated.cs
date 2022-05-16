using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IDomainTypeDao
  {
    #region Async
    Task<long> DomainTypeGetCountAsync();
    Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(params OrderDomainType[] orderBy);
    Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    Task<IDomainTypeDto> DomainTypeGetAsync(long id);
    Task<ICollection<IDomainTypeHistDto>> DomainTypeHistGetsAsync(long id);
    Task<IDomainTypeHistDto> DomainTypeHistEntryGetAsync(long histId);
    Task DomainTypeHistDeleteAsync(long histId);
    Task DomainTypeSaveAsync(IDomainTypeDto dto);
    Task DomainTypeMergeAsync(IDomainTypeDto dto);
    Task DomainTypeDeleteAsync(long id);
    Task<bool> DomainTypeHasChangedAsync(IDomainTypeDto dto);
    Task DomainTypeBulkInsertAsync(ICollection<IDomainTypeDto> dtos);
    Task DomainTypeBulkInsertAsync(ICollection<IDomainTypeDto> dtos, bool identityInsert);
    Task DomainType_TempBulkInsertAsync(ICollection<IDomainTypeDto> dtos);
    Task DomainType_TempBulkInsertAsync(ICollection<IDomainTypeDto> dtos, bool identityInsert);
    Task DomainTypeBulkMergeAsync(ICollection<IDomainTypeDto> dtos);
    Task DomainTypeBulkMergeAsync(ICollection<IDomainTypeDto> dtos, bool identityInsert);
    Task DomainTypeBulkUpdateAsync(ICollection<IDomainTypeDto> dtos);
    Task DomainTypeBulkDeleteAsync(ICollection<IDomainTypeDto> dtos);
    #endregion
    #region Sync
    long DomainTypeGetCount();
    ICollection<IDomainTypeDto> DomainTypeGets(params OrderDomainType[] orderBy);
    ICollection<IDomainTypeDto> DomainTypeGets(int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    IDomainTypeDto DomainTypeGet(long id);
    ICollection<IDomainTypeHistDto> DomainTypeHistGets(long id);
    IDomainTypeHistDto DomainTypeHistEntryGet(long histId);
    void DomainTypeHistDelete(long histId);
    void DomainTypeSave(IDomainTypeDto dto);
    void DomainTypeMerge(IDomainTypeDto dto);
    void DomainTypeDelete(long id);
    bool DomainTypeHasChanged(IDomainTypeDto dto);
    void DomainTypeBulkInsert(ICollection<IDomainTypeDto> dtos);
    void DomainTypeBulkInsert(ICollection<IDomainTypeDto> dtos, bool identityInsert);
    void DomainType_TempBulkInsert(ICollection<IDomainTypeDto> dtos);
    void DomainType_TempBulkInsert(ICollection<IDomainTypeDto> dtos, bool identityInsert);
    void DomainTypeBulkMerge(ICollection<IDomainTypeDto> dtos);
    void DomainTypeBulkMerge(ICollection<IDomainTypeDto> dtos, bool identityInsert);
    void DomainTypeBulkUpdate(ICollection<IDomainTypeDto> dtos);
    void DomainTypeBulkDelete(ICollection<IDomainTypeDto> dtos);
    #endregion
  }
  public partial interface IDomainTypeInternalDao : IDomainTypeDao
  {
    #region Async
    Task<long> DomainTypeGetCountAsync(WhereClause whereClause);
    Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(WhereClause whereClause, bool distinct, params OrderDomainType[] orderBy);
    Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    Task<IDomainTypeDto> DomainTypeGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IDomainTypeHistDto>> DomainTypeHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IDomainTypeHistDto> DomainTypeHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task DomainTypeHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task DomainTypeHistDeleteAsync(WhereClause whereClause);
    Task DomainTypeHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task DomainTypeSaveAsync(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto);
    Task DomainTypeMergeAsync(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto);
    Task DomainTypeDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task DomainTypeDeleteAsync(WhereClause whereClause);
    Task DomainTypeDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> DomainTypeHasChangedAsync(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto);
    #endregion
    #region Sync
    long DomainTypeGetCount(WhereClause whereClause);
    ICollection<IDomainTypeDto> DomainTypeGets(SqlConnection con, SqlCommand cmd);
    ICollection<IDomainTypeDto> DomainTypeGets(WhereClause whereClause, bool distinct, params OrderDomainType[] orderBy);
    ICollection<IDomainTypeDto> DomainTypeGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    ICollection<IDomainTypeDto> DomainTypeGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy);
    IDomainTypeDto DomainTypeGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IDomainTypeHistDto> DomainTypeHistGets(SqlConnection con, SqlCommand cmd, long id);
    IDomainTypeHistDto DomainTypeHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void DomainTypeHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void DomainTypeHistDelete(WhereClause whereClause);
    void DomainTypeHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void DomainTypeSave(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto);
    void DomainTypeMerge(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto);
    void DomainTypeDelete(SqlConnection con, SqlCommand cmd, long id);
    void DomainTypeDelete(WhereClause whereClause);
    void DomainTypeDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool DomainTypeHasChanged(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto);
    #endregion
  }
}


