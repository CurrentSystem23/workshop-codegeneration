using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface ICountryDao
  {
    #region Async
    Task<long> CountryGetCountAsync();
    Task<ICollection<ICountryDto>> CountryGetsAsync(params OrderCountry[] orderBy);
    Task<ICollection<ICountryDto>> CountryGetsAsync(int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    Task<ICountryDto> CountryGetAsync(long id);
    Task<ICollection<ICountryHistDto>> CountryHistGetsAsync(long id);
    Task<ICountryHistDto> CountryHistEntryGetAsync(long histId);
    Task CountryHistDeleteAsync(long histId);
    Task CountrySaveAsync(ICountryDto dto);
    Task CountryMergeAsync(ICountryDto dto);
    Task CountryDeleteAsync(long id);
    Task<bool> CountryHasChangedAsync(ICountryDto dto);
    Task CountryBulkInsertAsync(ICollection<ICountryDto> dtos);
    Task CountryBulkInsertAsync(ICollection<ICountryDto> dtos, bool identityInsert);
    Task Country_TempBulkInsertAsync(ICollection<ICountryDto> dtos);
    Task Country_TempBulkInsertAsync(ICollection<ICountryDto> dtos, bool identityInsert);
    Task CountryBulkMergeAsync(ICollection<ICountryDto> dtos);
    Task CountryBulkMergeAsync(ICollection<ICountryDto> dtos, bool identityInsert);
    Task CountryBulkUpdateAsync(ICollection<ICountryDto> dtos);
    Task CountryBulkDeleteAsync(ICollection<ICountryDto> dtos);
    #endregion
    #region Sync
    long CountryGetCount();
    ICollection<ICountryDto> CountryGets(params OrderCountry[] orderBy);
    ICollection<ICountryDto> CountryGets(int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    ICountryDto CountryGet(long id);
    ICollection<ICountryHistDto> CountryHistGets(long id);
    ICountryHistDto CountryHistEntryGet(long histId);
    void CountryHistDelete(long histId);
    void CountrySave(ICountryDto dto);
    void CountryMerge(ICountryDto dto);
    void CountryDelete(long id);
    bool CountryHasChanged(ICountryDto dto);
    void CountryBulkInsert(ICollection<ICountryDto> dtos);
    void CountryBulkInsert(ICollection<ICountryDto> dtos, bool identityInsert);
    void Country_TempBulkInsert(ICollection<ICountryDto> dtos);
    void Country_TempBulkInsert(ICollection<ICountryDto> dtos, bool identityInsert);
    void CountryBulkMerge(ICollection<ICountryDto> dtos);
    void CountryBulkMerge(ICollection<ICountryDto> dtos, bool identityInsert);
    void CountryBulkUpdate(ICollection<ICountryDto> dtos);
    void CountryBulkDelete(ICollection<ICountryDto> dtos);
    #endregion
  }
  public partial interface ICountryInternalDao : ICountryDao
  {
    #region Async
    Task<long> CountryGetCountAsync(WhereClause whereClause);
    Task<ICollection<ICountryDto>> CountryGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<ICountryDto>> CountryGetsAsync(WhereClause whereClause, bool distinct, params OrderCountry[] orderBy);
    Task<ICollection<ICountryDto>> CountryGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    Task<ICollection<ICountryDto>> CountryGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    Task<ICountryDto> CountryGetAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICollection<ICountryHistDto>> CountryHistGetsAsync(SqlConnection con, SqlCommand cmd, long id);
    Task<ICountryHistDto> CountryHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task CountryHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId);
    Task CountryHistDeleteAsync(WhereClause whereClause);
    Task CountryHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task CountrySaveAsync(SqlConnection con, SqlCommand cmd, ICountryDto dto);
    Task CountryMergeAsync(SqlConnection con, SqlCommand cmd, ICountryDto dto);
    Task CountryDeleteAsync(SqlConnection con, SqlCommand cmd, long id);
    Task CountryDeleteAsync(WhereClause whereClause);
    Task CountryDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    Task<bool> CountryHasChangedAsync(SqlConnection con, SqlCommand cmd, ICountryDto dto);
    #endregion
    #region Sync
    long CountryGetCount(WhereClause whereClause);
    ICollection<ICountryDto> CountryGets(SqlConnection con, SqlCommand cmd);
    ICollection<ICountryDto> CountryGets(WhereClause whereClause, bool distinct, params OrderCountry[] orderBy);
    ICollection<ICountryDto> CountryGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    ICollection<ICountryDto> CountryGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    ICountryDto CountryGet(SqlConnection con, SqlCommand cmd, long id);
    ICollection<ICountryHistDto> CountryHistGets(SqlConnection con, SqlCommand cmd, long id);
    ICountryHistDto CountryHistEntryGet(SqlConnection con, SqlCommand cmd, long histId);
    void CountryHistDelete(SqlConnection con, SqlCommand cmd, long histId);
    void CountryHistDelete(WhereClause whereClause);
    void CountryHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    void CountrySave(SqlConnection con, SqlCommand cmd, ICountryDto dto);
    void CountryMerge(SqlConnection con, SqlCommand cmd, ICountryDto dto);
    void CountryDelete(SqlConnection con, SqlCommand cmd, long id);
    void CountryDelete(WhereClause whereClause);
    void CountryDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause);
    bool CountryHasChanged(SqlConnection con, SqlCommand cmd, ICountryDto dto);
    #endregion
  }
}


