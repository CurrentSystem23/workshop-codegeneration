using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IDomainValueDao
  {
    #region Async
    Task<long> DomainValueGetCountAsync();
    Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(params OrderDomainValue[] orderBy);
    Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    Task<IDomainValueDto> DomainValueGetAsync(long id);
    Task<ICollection<IDomainValueHistDto>> DomainValueHistGetsAsync(long id);
    Task<IDomainValueHistDto> DomainValueHistEntryGetAsync(long histId);
    Task DomainValueHistDeleteAsync(long histId);
    Task DomainValueSaveAsync(IDomainValueDto dto);
    Task DomainValueMergeAsync(IDomainValueDto dto);
    Task DomainValueDeleteAsync(long id);
    Task<bool> DomainValueHasChangedAsync(IDomainValueDto dto);
    Task DomainValueBulkInsertAsync(ICollection<IDomainValueDto> dtos);
    Task DomainValueBulkInsertAsync(ICollection<IDomainValueDto> dtos, bool identityInsert);
    Task DomainValue_TempBulkInsertAsync(ICollection<IDomainValueDto> dtos);
    Task DomainValue_TempBulkInsertAsync(ICollection<IDomainValueDto> dtos, bool identityInsert);
    Task DomainValueBulkMergeAsync(ICollection<IDomainValueDto> dtos);
    Task DomainValueBulkMergeAsync(ICollection<IDomainValueDto> dtos, bool identityInsert);
    Task DomainValueBulkUpdateAsync(ICollection<IDomainValueDto> dtos);
    Task DomainValueBulkDeleteAsync(ICollection<IDomainValueDto> dtos);
    #endregion
    #region Sync
    long DomainValueGetCount();
    ICollection<IDomainValueDto> DomainValueGets(params OrderDomainValue[] orderBy);
    ICollection<IDomainValueDto> DomainValueGets(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    IDomainValueDto DomainValueGet(long id);
    ICollection<IDomainValueHistDto> DomainValueHistGets(long id);
    IDomainValueHistDto DomainValueHistEntryGet(long histId);
    void DomainValueHistDelete(long histId);
    void DomainValueSave(IDomainValueDto dto);
    void DomainValueMerge(IDomainValueDto dto);
    void DomainValueDelete(long id);
    bool DomainValueHasChanged(IDomainValueDto dto);
    void DomainValueBulkInsert(ICollection<IDomainValueDto> dtos);
    void DomainValueBulkInsert(ICollection<IDomainValueDto> dtos, bool identityInsert);
    void DomainValue_TempBulkInsert(ICollection<IDomainValueDto> dtos);
    void DomainValue_TempBulkInsert(ICollection<IDomainValueDto> dtos, bool identityInsert);
    void DomainValueBulkMerge(ICollection<IDomainValueDto> dtos);
    void DomainValueBulkMerge(ICollection<IDomainValueDto> dtos, bool identityInsert);
    void DomainValueBulkUpdate(ICollection<IDomainValueDto> dtos);
    void DomainValueBulkDelete(ICollection<IDomainValueDto> dtos);
    #endregion
  }
  public partial interface IDomainValueInternalDao : IDomainValueDao
  {
    #region Async
    Task<long> DomainValueGetCountAsync(WhereClause whereClause);
    Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(WhereClause whereClause, bool distinct, params OrderDomainValue[] orderBy);
    Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    Task<IDomainValueDto> DomainValueGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<IDomainValueHistDto>> DomainValueHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<IDomainValueHistDto> DomainValueHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task DomainValueHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task DomainValueHistDeleteAsync(WhereClause whereClause);
    Task DomainValueHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task DomainValueSaveAsync(SqlConnection con, SqlCommand cmd, IDomainValueDto dto);
    Task DomainValueMergeAsync(SqlConnection con, SqlCommand cmd, IDomainValueDto dto);
    Task DomainValueDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task DomainValueDeleteAsync(WhereClause whereClause);
    Task DomainValueDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> DomainValueHasChangedAsync(SqlConnection con, SqlCommand cmd, IDomainValueDto dto);
    #endregion
    #region Sync
    long DomainValueGetCount(WhereClause whereClause);
    ICollection<IDomainValueDto> DomainValueGets(SqlConnection con, SqlCommand cmd);
    ICollection<IDomainValueDto> DomainValueGets(WhereClause whereClause, bool distinct, params OrderDomainValue[] orderBy);
    ICollection<IDomainValueDto> DomainValueGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    ICollection<IDomainValueDto> DomainValueGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy);
    IDomainValueDto DomainValueGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<IDomainValueHistDto> DomainValueHistGets(SqlConnection con, SqlCommand cmd, long id);
    IDomainValueHistDto DomainValueHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void DomainValueHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void DomainValueHistDelete(WhereClause whereClause);
    void DomainValueHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void DomainValueSave(SqlConnection con, SqlCommand cmd, IDomainValueDto dto);
    void DomainValueMerge(SqlConnection con, SqlCommand cmd, IDomainValueDto dto);
    void DomainValueDelete(SqlConnection con, SqlCommand cmd, long id);
    void DomainValueDelete(WhereClause whereClause);
    void DomainValueDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool DomainValueHasChanged(SqlConnection con, SqlCommand cmd, IDomainValueDto dto);
    #endregion
  }
}


