using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;

namespace WorkshopTestProject.DataAccess
{
  public partial class DataAccess : IDataAccessInternal
  {
    private readonly ILogger<DataAccess> _logger;
    private readonly IServiceProvider _provider;
    
    #region core.CountryDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryDto>> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGetsAsync(params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryDto>> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryDto>> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryDto>> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryDto>> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryDto>> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryHistDto>> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICountryHistDto>> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICountryHistDto> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICountryHistDto> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountrySaveAsync(Common.DTOs.core.ICountryDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountrySaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountrySaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICountryDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountrySaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryMergeAsync(Common.DTOs.core.ICountryDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICountryDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHasChangedAsync(Common.DTOs.core.ICountryDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICountryDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkInsertAsync(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkInsertAsync(ICollection<Common.DTOs.core.ICountryDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.Country_TempBulkInsertAsync(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().Country_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.Country_TempBulkInsertAsync(ICollection<Common.DTOs.core.ICountryDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().Country_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkMergeAsync(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkMergeAsync(ICollection<Common.DTOs.core.ICountryDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkUpdateAsync(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkDeleteAsync(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGets(params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ICountryDto> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCountry[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.ICountryDto Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGet(id);
    }
    Common.DTOs.core.ICountryDto Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.ICountryHistDto> Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistGets(id);
    }
    ICollection<Common.DTOs.core.ICountryHistDto> Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistGets(con, cmd, id);
    }
    Common.DTOs.core.ICountryHistDto Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistEntryGet(histId);
    }
    Common.DTOs.core.ICountryHistDto Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountrySave(Common.DTOs.core.ICountryDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountrySave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountrySave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICountryDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountrySave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryMerge(Common.DTOs.core.ICountryDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICountryDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryHasChanged(Common.DTOs.core.ICountryDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao.CountryHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICountryDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkInsert(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkInsert(ICollection<Common.DTOs.core.ICountryDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.Country_TempBulkInsert(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().Country_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.Country_TempBulkInsert(ICollection<Common.DTOs.core.ICountryDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().Country_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkMerge(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkMerge(ICollection<Common.DTOs.core.ICountryDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkUpdate(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICountryDao.CountryBulkDelete(ICollection<Common.DTOs.core.ICountryDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao>().CountryBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.CurrencyDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGetsAsync(params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyHistDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ICurrencyHistDto>> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICurrencyHistDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ICurrencyHistDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencySaveAsync(Common.DTOs.core.ICurrencyDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencySaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencySaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICurrencyDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencySaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyMergeAsync(Common.DTOs.core.ICurrencyDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICurrencyDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHasChangedAsync(Common.DTOs.core.ICurrencyDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICurrencyDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkInsertAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkInsertAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.Currency_TempBulkInsertAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().Currency_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.Currency_TempBulkInsertAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().Currency_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkMergeAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkMergeAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkUpdateAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkDeleteAsync(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGets(params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ICurrencyDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderCurrency[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.ICurrencyDto Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGet(id);
    }
    Common.DTOs.core.ICurrencyDto Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.ICurrencyHistDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistGets(id);
    }
    ICollection<Common.DTOs.core.ICurrencyHistDto> Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistGets(con, cmd, id);
    }
    Common.DTOs.core.ICurrencyHistDto Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistEntryGet(histId);
    }
    Common.DTOs.core.ICurrencyHistDto Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencySave(Common.DTOs.core.ICurrencyDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencySave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencySave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICurrencyDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencySave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyMerge(Common.DTOs.core.ICurrencyDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICurrencyDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyHasChanged(Common.DTOs.core.ICurrencyDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao.CurrencyHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ICurrencyDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkInsert(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkInsert(ICollection<Common.DTOs.core.ICurrencyDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.Currency_TempBulkInsert(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().Currency_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.Currency_TempBulkInsert(ICollection<Common.DTOs.core.ICurrencyDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().Currency_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkMerge(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkMerge(ICollection<Common.DTOs.core.ICurrencyDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkUpdate(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ICurrencyDao.CurrencyBulkDelete(ICollection<Common.DTOs.core.ICurrencyDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao>().CurrencyBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.DomainTypeDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGetsAsync(params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeHistDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainTypeHistDto>> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainTypeHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainTypeHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeSaveAsync(Common.DTOs.core.IDomainTypeDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainTypeDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeMergeAsync(Common.DTOs.core.IDomainTypeDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainTypeDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHasChangedAsync(Common.DTOs.core.IDomainTypeDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainTypeDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkInsertAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkInsertAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainType_TempBulkInsertAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainType_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainType_TempBulkInsertAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainType_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkMergeAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkMergeAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkUpdateAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkDeleteAsync(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGets(params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainTypeDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainType[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IDomainTypeDto Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGet(id);
    }
    Common.DTOs.core.IDomainTypeDto Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IDomainTypeHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistGets(id);
    }
    ICollection<Common.DTOs.core.IDomainTypeHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistGets(con, cmd, id);
    }
    Common.DTOs.core.IDomainTypeHistDto Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistEntryGet(histId);
    }
    Common.DTOs.core.IDomainTypeHistDto Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeSave(Common.DTOs.core.IDomainTypeDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainTypeDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeMerge(Common.DTOs.core.IDomainTypeDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainTypeDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeHasChanged(Common.DTOs.core.IDomainTypeDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao.DomainTypeHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainTypeDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkInsert(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkInsert(ICollection<Common.DTOs.core.IDomainTypeDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainType_TempBulkInsert(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainType_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainType_TempBulkInsert(ICollection<Common.DTOs.core.IDomainTypeDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainType_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkMerge(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkMerge(ICollection<Common.DTOs.core.IDomainTypeDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkUpdate(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao.DomainTypeBulkDelete(ICollection<Common.DTOs.core.IDomainTypeDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao>().DomainTypeBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.DomainValueDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGetsAsync(params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueHistDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IDomainValueHistDto>> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainValueHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IDomainValueHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueSaveAsync(Common.DTOs.core.IDomainValueDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainValueDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueMergeAsync(Common.DTOs.core.IDomainValueDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainValueDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHasChangedAsync(Common.DTOs.core.IDomainValueDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainValueDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkInsertAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkInsertAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValue_TempBulkInsertAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValue_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValue_TempBulkInsertAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValue_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkMergeAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkMergeAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkUpdateAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkDeleteAsync(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGets(params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IDomainValueDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderDomainValue[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IDomainValueDto Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGet(id);
    }
    Common.DTOs.core.IDomainValueDto Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IDomainValueHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistGets(id);
    }
    ICollection<Common.DTOs.core.IDomainValueHistDto> Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistGets(con, cmd, id);
    }
    Common.DTOs.core.IDomainValueHistDto Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistEntryGet(histId);
    }
    Common.DTOs.core.IDomainValueHistDto Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueSave(Common.DTOs.core.IDomainValueDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainValueDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueMerge(Common.DTOs.core.IDomainValueDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainValueDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueHasChanged(Common.DTOs.core.IDomainValueDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao.DomainValueHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IDomainValueDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkInsert(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkInsert(ICollection<Common.DTOs.core.IDomainValueDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValue_TempBulkInsert(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValue_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValue_TempBulkInsert(ICollection<Common.DTOs.core.IDomainValueDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValue_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkMerge(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkMerge(ICollection<Common.DTOs.core.IDomainValueDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkUpdate(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IDomainValueDao.DomainValueBulkDelete(ICollection<Common.DTOs.core.IDomainValueDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao>().DomainValueBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.ProductDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductDto>> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGetsAsync(params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductDto>> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductDto>> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductDto>> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductDto>> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductDto>> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductHistDto>> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductHistDto>> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IProductHistDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IProductHistDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductSaveAsync(Common.DTOs.core.IProductDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IProductDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductMergeAsync(Common.DTOs.core.IProductDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IProductDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHasChangedAsync(Common.DTOs.core.IProductDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IProductDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkInsertAsync(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkInsertAsync(ICollection<Common.DTOs.core.IProductDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.Product_TempBulkInsertAsync(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().Product_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.Product_TempBulkInsertAsync(ICollection<Common.DTOs.core.IProductDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().Product_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkMergeAsync(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkMergeAsync(ICollection<Common.DTOs.core.IProductDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkUpdateAsync(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkDeleteAsync(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGets(params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IProductDto Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGet(id);
    }
    Common.DTOs.core.IProductDto Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IProductHistDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistGets(id);
    }
    ICollection<Common.DTOs.core.IProductHistDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistGets(con, cmd, id);
    }
    Common.DTOs.core.IProductHistDto Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistEntryGet(histId);
    }
    Common.DTOs.core.IProductHistDto Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductSave(Common.DTOs.core.IProductDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IProductDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductMerge(Common.DTOs.core.IProductDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IProductDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductHasChanged(Common.DTOs.core.IProductDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IProductDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkInsert(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkInsert(ICollection<Common.DTOs.core.IProductDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.Product_TempBulkInsert(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().Product_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.Product_TempBulkInsert(ICollection<Common.DTOs.core.IProductDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().Product_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkMerge(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkMerge(ICollection<Common.DTOs.core.IProductDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkUpdate(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductBulkDelete(ICollection<Common.DTOs.core.IProductDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.ProductInStockDaoV
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockGetCountAsync(long? productId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetCountAsync(new WhereClause(), productId).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGetCountAsync(WhereClause whereClause, long? productId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetCountAsync(whereClause, productId).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockGetsAsync(long? productId, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetsAsync(new WhereClause(), false, productId, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockGetsAsync(long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetsAsync(new WhereClause(), false, productId, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGetsAsync(SqlConnection con, SqlCommand cmd, long? productId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetsAsync(con, cmd, new WhereClause(), false, productId, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGetsAsync(WhereClause whereClause, bool distinct, long? productId, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetsAsync(whereClause, distinct, productId, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGetsAsync(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetsAsync(whereClause, distinct, productId, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetsAsync(con, cmd, whereClause, distinct, productId, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockGetCount(long? productId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetCount(new WhereClause(), productId);
    }
    long Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGetCount(WhereClause whereClause, long? productId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGetCount(whereClause, productId);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockGets(long? productId, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGets(new WhereClause(), false, productId, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockGets(long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGets(new WhereClause(), false, productId, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGets(SqlConnection con, SqlCommand cmd, long? productId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGets(con, cmd, new WhereClause(), false, productId, null, null);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGets(WhereClause whereClause, bool distinct, long? productId, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGets(whereClause, distinct, productId, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGets(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGets(whereClause, distinct, productId, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockGets(con, cmd, whereClause, distinct, productId, pageNum, pageSize, orderBy);
    }
    #endregion
    #endregion
    
    #region core.ProductsInStockDaoV
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV.ProductsInStockGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductsInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV.ProductsInStockGetsAsync(params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductsInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV.ProductsInStockGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductsInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductsInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductsInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IProductsInStockDtoV>> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV.ProductsInStockGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IProductsInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV.ProductsInStockGets(params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IProductsInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV.ProductsInStockGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductsInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IProductsInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IProductsInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductsInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV.ProductsInStockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductsInStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV>().ProductsInStockGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    #endregion
    #endregion
    
    #region core.SpecialProductsDaoV
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsGetCountAsync(long[] productIds)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetCountAsync(new WhereClause(), productIds).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGetCountAsync(WhereClause whereClause, long[] productIds)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetCountAsync(whereClause, productIds).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ISpecialProductsDtoV>> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsGetsAsync(long[] productIds, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetsAsync(new WhereClause(), false, productIds, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ISpecialProductsDtoV>> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsGetsAsync(long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetsAsync(new WhereClause(), false, productIds, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ISpecialProductsDtoV>> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGetsAsync(SqlConnection con, SqlCommand cmd, long[] productIds)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetsAsync(con, cmd, new WhereClause(), false, productIds, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ISpecialProductsDtoV>> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGetsAsync(WhereClause whereClause, bool distinct, long[] productIds, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetsAsync(whereClause, distinct, productIds, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ISpecialProductsDtoV>> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGetsAsync(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetsAsync(whereClause, distinct, productIds, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ISpecialProductsDtoV>> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetsAsync(con, cmd, whereClause, distinct, productIds, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsGetCount(long[] productIds)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetCount(new WhereClause(), productIds);
    }
    long Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGetCount(WhereClause whereClause, long[] productIds)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGetCount(whereClause, productIds);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsGets(long[] productIds, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGets(new WhereClause(), false, productIds, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsGets(long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGets(new WhereClause(), false, productIds, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGets(SqlConnection con, SqlCommand cmd, long[] productIds)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGets(con, cmd, new WhereClause(), false, productIds, null, null);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGets(WhereClause whereClause, bool distinct, long[] productIds, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGets(whereClause, distinct, productIds, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGets(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGets(whereClause, distinct, productIds, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsGets(con, cmd, whereClause, distinct, productIds, pageNum, pageSize, orderBy);
    }
    #endregion
    #endregion
    
    #region core.StockDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockDto>> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGetsAsync(params Common.DTOs.core.OrderStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockDto>> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockDto>> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockDto>> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockDto>> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockDto>> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockHistDto>> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IStockHistDto>> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IStockHistDto> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IStockHistDto> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockSaveAsync(Common.DTOs.core.IStockDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IStockDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockMergeAsync(Common.DTOs.core.IStockDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IStockDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHasChangedAsync(Common.DTOs.core.IStockDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IStockDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkInsertAsync(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkInsertAsync(ICollection<Common.DTOs.core.IStockDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.Stock_TempBulkInsertAsync(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().Stock_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.Stock_TempBulkInsertAsync(ICollection<Common.DTOs.core.IStockDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().Stock_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkMergeAsync(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkMergeAsync(ICollection<Common.DTOs.core.IStockDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkUpdateAsync(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkDeleteAsync(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGets(params Common.DTOs.core.OrderStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IStockDto> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderStock[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IStockDto Common.DataAccess.Interfaces.Ado.core.IStockDao.StockGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGet(id);
    }
    Common.DTOs.core.IStockDto Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IStockHistDto> Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistGets(id);
    }
    ICollection<Common.DTOs.core.IStockHistDto> Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistGets(con, cmd, id);
    }
    Common.DTOs.core.IStockHistDto Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistEntryGet(histId);
    }
    Common.DTOs.core.IStockHistDto Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockSave(Common.DTOs.core.IStockDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IStockDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockMerge(Common.DTOs.core.IStockDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IStockDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IStockDao.StockHasChanged(Common.DTOs.core.IStockDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IStockInternalDao.StockHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IStockDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkInsert(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkInsert(ICollection<Common.DTOs.core.IStockDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.Stock_TempBulkInsert(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().Stock_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.Stock_TempBulkInsert(ICollection<Common.DTOs.core.IStockDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().Stock_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkMerge(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkMerge(ICollection<Common.DTOs.core.IStockDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkUpdate(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IStockDao.StockBulkDelete(ICollection<Common.DTOs.core.IStockDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IStockInternalDao>().StockBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.TenantDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantDto>> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGetsAsync(params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantDto>> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantDto>> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantDto>> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantDto>> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantDto>> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantHistDto>> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.ITenantHistDto>> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ITenantHistDto> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.ITenantHistDto> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantSaveAsync(Common.DTOs.core.ITenantDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ITenantDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantMergeAsync(Common.DTOs.core.ITenantDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ITenantDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHasChangedAsync(Common.DTOs.core.ITenantDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ITenantDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkInsertAsync(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkInsertAsync(ICollection<Common.DTOs.core.ITenantDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.Tenant_TempBulkInsertAsync(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().Tenant_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.Tenant_TempBulkInsertAsync(ICollection<Common.DTOs.core.ITenantDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().Tenant_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkMergeAsync(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkMergeAsync(ICollection<Common.DTOs.core.ITenantDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkUpdateAsync(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkDeleteAsync(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGets(params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ITenantDto> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderTenant[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.ITenantDto Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGet(id);
    }
    Common.DTOs.core.ITenantDto Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.ITenantHistDto> Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistGets(id);
    }
    ICollection<Common.DTOs.core.ITenantHistDto> Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistGets(con, cmd, id);
    }
    Common.DTOs.core.ITenantHistDto Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistEntryGet(histId);
    }
    Common.DTOs.core.ITenantHistDto Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantSave(Common.DTOs.core.ITenantDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ITenantDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantMerge(Common.DTOs.core.ITenantDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ITenantDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantHasChanged(Common.DTOs.core.ITenantDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao.TenantHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.ITenantDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkInsert(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkInsert(ICollection<Common.DTOs.core.ITenantDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.Tenant_TempBulkInsert(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().Tenant_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.Tenant_TempBulkInsert(ICollection<Common.DTOs.core.ITenantDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().Tenant_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkMerge(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkMerge(ICollection<Common.DTOs.core.ITenantDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkUpdate(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.ITenantDao.TenantBulkDelete(ICollection<Common.DTOs.core.ITenantDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao>().TenantBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.UserDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserDto>> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGetsAsync(params Common.DTOs.core.OrderUser[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserDto>> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserDto>> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserDto>> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserDto>> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserDto>> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserHistDto> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserHistDto> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserSaveAsync(Common.DTOs.core.IUserDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserMergeAsync(Common.DTOs.core.IUserDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHasChangedAsync(Common.DTOs.core.IUserDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkInsertAsync(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkInsertAsync(ICollection<Common.DTOs.core.IUserDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.User_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().User_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.User_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().User_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkMergeAsync(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkMergeAsync(ICollection<Common.DTOs.core.IUserDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkUpdateAsync(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkDeleteAsync(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGets(params Common.DTOs.core.OrderUser[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserDto> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUser[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IUserDto Common.DataAccess.Interfaces.Ado.core.IUserDao.UserGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGet(id);
    }
    Common.DTOs.core.IUserDto Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IUserHistDto> Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistGets(id);
    }
    ICollection<Common.DTOs.core.IUserHistDto> Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistGets(con, cmd, id);
    }
    Common.DTOs.core.IUserHistDto Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistEntryGet(histId);
    }
    Common.DTOs.core.IUserHistDto Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserSave(Common.DTOs.core.IUserDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserMerge(Common.DTOs.core.IUserDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserDao.UserHasChanged(Common.DTOs.core.IUserDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserInternalDao.UserHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkInsert(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkInsert(ICollection<Common.DTOs.core.IUserDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.User_TempBulkInsert(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().User_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.User_TempBulkInsert(ICollection<Common.DTOs.core.IUserDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().User_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkMerge(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkMerge(ICollection<Common.DTOs.core.IUserDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkUpdate(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserDao.UserBulkDelete(ICollection<Common.DTOs.core.IUserDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserInternalDao>().UserBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.UserGroupDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGetsAsync(params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserGroupHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserGroupHistDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserGroupHistDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupSaveAsync(Common.DTOs.core.IUserGroupDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserGroupDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupMergeAsync(Common.DTOs.core.IUserGroupDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserGroupDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHasChangedAsync(Common.DTOs.core.IUserGroupDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserGroupDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkInsertAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkInsertAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroup_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroup_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroup_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroup_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkMergeAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkMergeAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkUpdateAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkDeleteAsync(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGets(params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserGroupDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserGroup[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IUserGroupDto Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGet(id);
    }
    Common.DTOs.core.IUserGroupDto Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IUserGroupHistDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistGets(id);
    }
    ICollection<Common.DTOs.core.IUserGroupHistDto> Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistGets(con, cmd, id);
    }
    Common.DTOs.core.IUserGroupHistDto Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistEntryGet(histId);
    }
    Common.DTOs.core.IUserGroupHistDto Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupSave(Common.DTOs.core.IUserGroupDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserGroupDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupMerge(Common.DTOs.core.IUserGroupDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserGroupDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupHasChanged(Common.DTOs.core.IUserGroupDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao.UserGroupHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserGroupDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkInsert(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkInsert(ICollection<Common.DTOs.core.IUserGroupDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroup_TempBulkInsert(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroup_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroup_TempBulkInsert(ICollection<Common.DTOs.core.IUserGroupDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroup_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkMerge(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkMerge(ICollection<Common.DTOs.core.IUserGroupDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkUpdate(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserGroupDao.UserGroupBulkDelete(ICollection<Common.DTOs.core.IUserGroupDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao>().UserGroupBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.UserRightDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGetsAsync(params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightSaveAsync(Common.DTOs.core.IUserRightDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightMergeAsync(Common.DTOs.core.IUserRightDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHasChangedAsync(Common.DTOs.core.IUserRightDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRight_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRight_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRight_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRight_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkMergeAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkMergeAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkUpdateAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkDeleteAsync(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGets(params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightDto> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRight[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IUserRightDto Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGet(id);
    }
    Common.DTOs.core.IUserRightDto Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IUserRightHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistGets(id);
    }
    ICollection<Common.DTOs.core.IUserRightHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistGets(con, cmd, id);
    }
    Common.DTOs.core.IUserRightHistDto Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistEntryGet(histId);
    }
    Common.DTOs.core.IUserRightHistDto Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightSave(Common.DTOs.core.IUserRightDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightMerge(Common.DTOs.core.IUserRightDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightHasChanged(Common.DTOs.core.IUserRightDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao.UserRightHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkInsert(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkInsert(ICollection<Common.DTOs.core.IUserRightDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRight_TempBulkInsert(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRight_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRight_TempBulkInsert(ICollection<Common.DTOs.core.IUserRightDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRight_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkMerge(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkMerge(ICollection<Common.DTOs.core.IUserRightDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkUpdate(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightDao.UserRightBulkDelete(ICollection<Common.DTOs.core.IUserRightDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao>().UserRightBulkDelete(dtos);
    }
    #endregion
    #endregion
    
    #region core.UserRightsRoleDao
    #region Async
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGetCountAsync()
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    async Task<long> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGetCountAsync(WhereClause whereClause)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetCountAsync(whereClause).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGetsAsync(params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetsAsync(new WhereClause(), false, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGetsAsync(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGetsAsync(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetsAsync(whereClause, distinct, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetsAsync(whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGetAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetAsync(id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHistGetsAsync(long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistGetsAsync(id).ConfigureAwait(false);
    }
    async Task<ICollection<Common.DTOs.core.IUserRightsRoleHistDto>> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistGetsAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightsRoleHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHistEntryGetAsync(long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistEntryGetAsync(histId).ConfigureAwait(false);
    }
    async Task<Common.DTOs.core.IUserRightsRoleHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHistDeleteAsync(long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDeleteAsync(histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleSaveAsync(Common.DTOs.core.IUserRightsRoleDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleSaveAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleSaveAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightsRoleDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleSaveAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleMergeAsync(Common.DTOs.core.IUserRightsRoleDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleMergeAsync(dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleMergeAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightsRoleDto dto)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleMergeAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleDeleteAsync(long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDeleteAsync(id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDeleteAsync(con, cmd, id).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleDeleteAsync(WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDeleteAsync(whereClause).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHasChangedAsync(Common.DTOs.core.IUserRightsRoleDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHasChangedAsync(dto).ConfigureAwait(false);
    }
    async Task<bool> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHasChangedAsync(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightsRoleDto dto)
    {
      return await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRole_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRole_TempBulkInsertAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRole_TempBulkInsertAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRole_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkMergeAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkMergeAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkMergeAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos, bool identityInsert)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkMergeAsync(dtos, identityInsert).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkUpdateAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkUpdateAsync(dtos).ConfigureAwait(false);
    }
    async Task Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkDeleteAsync(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      await _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkDeleteAsync(dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    long Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGetCount()
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetCount(new WhereClause());
    }
    long Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGetCount(WhereClause whereClause)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGetCount(whereClause);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGets(params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGets(SqlConnection con, SqlCommand cmd)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderUserRightsRole[] orderBy)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    Common.DTOs.core.IUserRightsRoleDto Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleGet(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGet(id);
    }
    Common.DTOs.core.IUserRightsRoleDto Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleGet(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleGet(con, cmd, id);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHistGets(long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistGets(id);
    }
    ICollection<Common.DTOs.core.IUserRightsRoleHistDto> Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistGets(con, cmd, id);
    }
    Common.DTOs.core.IUserRightsRoleHistDto Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHistEntryGet(long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistEntryGet(histId);
    }
    Common.DTOs.core.IUserRightsRoleHistDto Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistEntryGet(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHistDelete(long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDelete(histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDelete(con, cmd, histId);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHistDelete(con, cmd, whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleSave(Common.DTOs.core.IUserRightsRoleDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleSave(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleSave(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightsRoleDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleSave(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleMerge(Common.DTOs.core.IUserRightsRoleDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleMerge(dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleMerge(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightsRoleDto dto)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleMerge(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleDelete(long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDelete(id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDelete(con, cmd, id);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleDelete(WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDelete(whereClause);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleDelete(con, cmd, whereClause);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleHasChanged(Common.DTOs.core.IUserRightsRoleDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHasChanged(dto);
    }
    bool Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao.UserRightsRoleHasChanged(SqlConnection con, SqlCommand cmd, Common.DTOs.core.IUserRightsRoleDto dto)
    {
      return  _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleHasChanged(con, cmd, dto);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkInsert(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkInsert(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRole_TempBulkInsert(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRole_TempBulkInsert(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRole_TempBulkInsert(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRole_TempBulkInsert(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkMerge(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkMerge(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkMerge(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos, bool identityInsert)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkMerge(dtos, identityInsert);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkUpdate(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkUpdate(dtos);
    }
    void Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao.UserRightsRoleBulkDelete(ICollection<Common.DTOs.core.IUserRightsRoleDto> dtos)
    {
      _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao>().UserRightsRoleBulkDelete(dtos);
    }
    #endregion
    #endregion
  }
}


