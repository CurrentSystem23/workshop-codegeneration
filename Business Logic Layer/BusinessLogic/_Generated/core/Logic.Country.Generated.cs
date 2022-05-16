using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using WorkshopTestProject.Common.Interfaces;

namespace WorkshopTestProject.BusinessLogic
{
  internal partial class Logic
  {
    #region Async
    public async Task<long> Core_CountryGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_CountryGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<ICountryViewModel>> Core_CountryGetsAsync(params OrderCountry[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryGetsAsync()", orderBy);
      return _mapper.Map<ICollection<ICountryViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<ICountryViewModel>> Core_CountryGetsAsync(int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ICountryViewModel>>(dto) ?? null;
    }
    public async Task<ICountryViewModel> Core_CountryGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryGetAsync({id})", dto);
      return (ICountryViewModel)dto ?? null;
    }
    public async Task<ICollection<ICountryHistViewModel>> Core_CountryHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<ICountryHistViewModel>>(dto) ?? null;
    }
    public async Task<ICountryHistViewModel> Core_CountryHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHistEntryGetAsync({histId})", dto);
      return (ICountryHistViewModel)dto ?? null;
    }
    public async Task Core_CountryHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHistDeleteAsync({histId})");
    }
    public async Task Core_CountrySaveAsync(ICountryViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountrySaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountrySaveAsync((ICountryDto)dto).ConfigureAwait(false);
    }
    public async Task Core_CountryMergeAsync(ICountryViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryMergeAsync((ICountryDto) dto).ConfigureAwait(false);
    }
    public async Task Core_CountryDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_CountryHasChangedAsync(ICountryViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHasChangedAsync((ICountryDto)dto).ConfigureAwait(false);
    }
    public async Task Core_CountryBulkInsertAsync(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkInsertAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CountryBulkInsertAsync(ICollection<ICountryViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkInsertAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Country_TempBulkInsertAsync(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Country_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).Country_TempBulkInsertAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Country_TempBulkInsertAsync(ICollection<ICountryViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Country_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).Country_TempBulkInsertAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CountryBulkMergeAsync(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkMergeAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CountryBulkMergeAsync(ICollection<ICountryViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkMergeAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CountryBulkUpdateAsync(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkUpdateAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CountryBulkDeleteAsync(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkDeleteAsync((ICollection<ICountryDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_CountryGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_CountryGetCount()", count);
      return count;
    }
    public ICollection<ICountryViewModel> Core_CountryGets(params OrderCountry[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryGets()", orderBy);
      return _mapper.Map<ICollection<ICountryViewModel>>(dto) ?? null;
    }
    public ICollection<ICountryViewModel> Core_CountryGets(int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ICountryViewModel>>(dto) ?? null;
    }
    public ICountryViewModel Core_CountryGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryGet({id})", dto);
      return (ICountryViewModel)dto ?? null;
    }
    public ICollection<ICountryHistViewModel> Core_CountryHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHistGets({id})", dto);
      return _mapper.Map<ICollection<ICountryHistViewModel>>(dto) ?? null;
    }
    public ICountryHistViewModel Core_CountryHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHistEntryGet({histId})", dto);
      return (ICountryHistViewModel)dto ?? null;
    }
    public void Core_CountryHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHistDelete({histId})");
    }
    public void Core_CountrySave(ICountryViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountrySave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountrySave((ICountryDto)dto);
    }
    public void Core_CountryMerge(ICountryViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryMerge((ICountryDto) dto);
    }
    public void Core_CountryDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryDelete(id);
    }
    public bool Core_CountryHasChanged(ICountryViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryHasChanged((ICountryDto)dto);
    }
    public void Core_CountryBulkInsert(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkInsert((ICollection<ICountryDto>)dtos);
    }
    public void Core_CountryBulkInsert(ICollection<ICountryViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkInsert((ICollection<ICountryDto>)dtos);
    }
    public void Core_Country_TempBulkInsert(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Country_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).Country_TempBulkInsert((ICollection<ICountryDto>)dtos);
    }
    public void Core_Country_TempBulkInsert(ICollection<ICountryViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Country_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).Country_TempBulkInsert((ICollection<ICountryDto>)dtos);
    }
    public void Core_CountryBulkMerge(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkMerge((ICollection<ICountryDto>)dtos);
    }
    public void Core_CountryBulkMerge(ICollection<ICountryViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkMerge((ICollection<ICountryDto>)dtos);
    }
    public void Core_CountryBulkUpdate(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkUpdate((ICollection<ICountryDto>)dtos);
    }
    public void Core_CountryBulkDelete(ICollection<ICountryViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CountryBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICountryDao)_dataAccess).CountryBulkDelete((ICollection<ICountryDto>)dtos);
    }
    #endregion
  }
}


