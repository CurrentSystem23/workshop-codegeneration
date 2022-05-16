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
    public async Task<long> Core_CurrencyGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_CurrencyGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<ICurrencyViewModel>> Core_CurrencyGetsAsync(params OrderCurrency[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyGetsAsync()", orderBy);
      return _mapper.Map<ICollection<ICurrencyViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<ICurrencyViewModel>> Core_CurrencyGetsAsync(int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ICurrencyViewModel>>(dto) ?? null;
    }
    public async Task<ICurrencyViewModel> Core_CurrencyGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyGetAsync({id})", dto);
      return (ICurrencyViewModel)dto ?? null;
    }
    public async Task<ICollection<ICurrencyHistViewModel>> Core_CurrencyHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<ICurrencyHistViewModel>>(dto) ?? null;
    }
    public async Task<ICurrencyHistViewModel> Core_CurrencyHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHistEntryGetAsync({histId})", dto);
      return (ICurrencyHistViewModel)dto ?? null;
    }
    public async Task Core_CurrencyHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHistDeleteAsync({histId})");
    }
    public async Task Core_CurrencySaveAsync(ICurrencyViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencySaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencySaveAsync((ICurrencyDto)dto).ConfigureAwait(false);
    }
    public async Task Core_CurrencyMergeAsync(ICurrencyViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyMergeAsync((ICurrencyDto) dto).ConfigureAwait(false);
    }
    public async Task Core_CurrencyDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_CurrencyHasChangedAsync(ICurrencyViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHasChangedAsync((ICurrencyDto)dto).ConfigureAwait(false);
    }
    public async Task Core_CurrencyBulkInsertAsync(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkInsertAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CurrencyBulkInsertAsync(ICollection<ICurrencyViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkInsertAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Currency_TempBulkInsertAsync(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Currency_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).Currency_TempBulkInsertAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Currency_TempBulkInsertAsync(ICollection<ICurrencyViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Currency_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).Currency_TempBulkInsertAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CurrencyBulkMergeAsync(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkMergeAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CurrencyBulkMergeAsync(ICollection<ICurrencyViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkMergeAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CurrencyBulkUpdateAsync(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkUpdateAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_CurrencyBulkDeleteAsync(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkDeleteAsync((ICollection<ICurrencyDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_CurrencyGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_CurrencyGetCount()", count);
      return count;
    }
    public ICollection<ICurrencyViewModel> Core_CurrencyGets(params OrderCurrency[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyGets()", orderBy);
      return _mapper.Map<ICollection<ICurrencyViewModel>>(dto) ?? null;
    }
    public ICollection<ICurrencyViewModel> Core_CurrencyGets(int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ICurrencyViewModel>>(dto) ?? null;
    }
    public ICurrencyViewModel Core_CurrencyGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyGet({id})", dto);
      return (ICurrencyViewModel)dto ?? null;
    }
    public ICollection<ICurrencyHistViewModel> Core_CurrencyHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHistGets({id})", dto);
      return _mapper.Map<ICollection<ICurrencyHistViewModel>>(dto) ?? null;
    }
    public ICurrencyHistViewModel Core_CurrencyHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHistEntryGet({histId})", dto);
      return (ICurrencyHistViewModel)dto ?? null;
    }
    public void Core_CurrencyHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHistDelete({histId})");
    }
    public void Core_CurrencySave(ICurrencyViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencySave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencySave((ICurrencyDto)dto);
    }
    public void Core_CurrencyMerge(ICurrencyViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyMerge((ICurrencyDto) dto);
    }
    public void Core_CurrencyDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyDelete(id);
    }
    public bool Core_CurrencyHasChanged(ICurrencyViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyHasChanged((ICurrencyDto)dto);
    }
    public void Core_CurrencyBulkInsert(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkInsert((ICollection<ICurrencyDto>)dtos);
    }
    public void Core_CurrencyBulkInsert(ICollection<ICurrencyViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkInsert((ICollection<ICurrencyDto>)dtos);
    }
    public void Core_Currency_TempBulkInsert(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Currency_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).Currency_TempBulkInsert((ICollection<ICurrencyDto>)dtos);
    }
    public void Core_Currency_TempBulkInsert(ICollection<ICurrencyViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Currency_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).Currency_TempBulkInsert((ICollection<ICurrencyDto>)dtos);
    }
    public void Core_CurrencyBulkMerge(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkMerge((ICollection<ICurrencyDto>)dtos);
    }
    public void Core_CurrencyBulkMerge(ICollection<ICurrencyViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkMerge((ICollection<ICurrencyDto>)dtos);
    }
    public void Core_CurrencyBulkUpdate(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkUpdate((ICollection<ICurrencyDto>)dtos);
    }
    public void Core_CurrencyBulkDelete(ICollection<ICurrencyViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.CurrencyBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ICurrencyDao)_dataAccess).CurrencyBulkDelete((ICollection<ICurrencyDto>)dtos);
    }
    #endregion
  }
}


