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
    public async Task<long> Core_StockGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_StockGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IStockViewModel>> Core_StockGetsAsync(params OrderStock[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IStockViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IStockViewModel>> Core_StockGetsAsync(int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IStockViewModel>>(dto) ?? null;
    }
    public async Task<IStockViewModel> Core_StockGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockGetAsync({id})", dto);
      return (IStockViewModel)dto ?? null;
    }
    public async Task<ICollection<IStockHistViewModel>> Core_StockHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IStockHistViewModel>>(dto) ?? null;
    }
    public async Task<IStockHistViewModel> Core_StockHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHistEntryGetAsync({histId})", dto);
      return (IStockHistViewModel)dto ?? null;
    }
    public async Task Core_StockHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHistDeleteAsync({histId})");
    }
    public async Task Core_StockSaveAsync(IStockViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockSaveAsync((IStockDto)dto).ConfigureAwait(false);
    }
    public async Task Core_StockMergeAsync(IStockViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockMergeAsync((IStockDto) dto).ConfigureAwait(false);
    }
    public async Task Core_StockDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_StockHasChangedAsync(IStockViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHasChangedAsync((IStockDto)dto).ConfigureAwait(false);
    }
    public async Task Core_StockBulkInsertAsync(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkInsertAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_StockBulkInsertAsync(ICollection<IStockViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkInsertAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Stock_TempBulkInsertAsync(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Stock_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).Stock_TempBulkInsertAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Stock_TempBulkInsertAsync(ICollection<IStockViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Stock_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).Stock_TempBulkInsertAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_StockBulkMergeAsync(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkMergeAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_StockBulkMergeAsync(ICollection<IStockViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkMergeAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_StockBulkUpdateAsync(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkUpdateAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_StockBulkDeleteAsync(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkDeleteAsync((ICollection<IStockDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_StockGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_StockGetCount()", count);
      return count;
    }
    public ICollection<IStockViewModel> Core_StockGets(params OrderStock[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockGets()", orderBy);
      return _mapper.Map<ICollection<IStockViewModel>>(dto) ?? null;
    }
    public ICollection<IStockViewModel> Core_StockGets(int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IStockViewModel>>(dto) ?? null;
    }
    public IStockViewModel Core_StockGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockGet({id})", dto);
      return (IStockViewModel)dto ?? null;
    }
    public ICollection<IStockHistViewModel> Core_StockHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHistGets({id})", dto);
      return _mapper.Map<ICollection<IStockHistViewModel>>(dto) ?? null;
    }
    public IStockHistViewModel Core_StockHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHistEntryGet({histId})", dto);
      return (IStockHistViewModel)dto ?? null;
    }
    public void Core_StockHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHistDelete({histId})");
    }
    public void Core_StockSave(IStockViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockSave((IStockDto)dto);
    }
    public void Core_StockMerge(IStockViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockMerge((IStockDto) dto);
    }
    public void Core_StockDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockDelete(id);
    }
    public bool Core_StockHasChanged(IStockViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockHasChanged((IStockDto)dto);
    }
    public void Core_StockBulkInsert(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkInsert((ICollection<IStockDto>)dtos);
    }
    public void Core_StockBulkInsert(ICollection<IStockViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkInsert((ICollection<IStockDto>)dtos);
    }
    public void Core_Stock_TempBulkInsert(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Stock_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).Stock_TempBulkInsert((ICollection<IStockDto>)dtos);
    }
    public void Core_Stock_TempBulkInsert(ICollection<IStockViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Stock_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).Stock_TempBulkInsert((ICollection<IStockDto>)dtos);
    }
    public void Core_StockBulkMerge(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkMerge((ICollection<IStockDto>)dtos);
    }
    public void Core_StockBulkMerge(ICollection<IStockViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkMerge((ICollection<IStockDto>)dtos);
    }
    public void Core_StockBulkUpdate(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkUpdate((ICollection<IStockDto>)dtos);
    }
    public void Core_StockBulkDelete(ICollection<IStockViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.StockBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IStockDao)_dataAccess).StockBulkDelete((ICollection<IStockDto>)dtos);
    }
    #endregion
  }
}


