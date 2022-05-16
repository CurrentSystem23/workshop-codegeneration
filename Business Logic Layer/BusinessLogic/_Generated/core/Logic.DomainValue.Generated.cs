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
    public async Task<long> Core_DomainValueGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_DomainValueGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IDomainValueViewModel>> Core_DomainValueGetsAsync(params OrderDomainValue[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IDomainValueViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IDomainValueViewModel>> Core_DomainValueGetsAsync(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IDomainValueViewModel>>(dto) ?? null;
    }
    public async Task<IDomainValueViewModel> Core_DomainValueGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueGetAsync({id})", dto);
      return (IDomainValueViewModel)dto ?? null;
    }
    public async Task<ICollection<IDomainValueHistViewModel>> Core_DomainValueHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IDomainValueHistViewModel>>(dto) ?? null;
    }
    public async Task<IDomainValueHistViewModel> Core_DomainValueHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHistEntryGetAsync({histId})", dto);
      return (IDomainValueHistViewModel)dto ?? null;
    }
    public async Task Core_DomainValueHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHistDeleteAsync({histId})");
    }
    public async Task Core_DomainValueSaveAsync(IDomainValueViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueSaveAsync((IDomainValueDto)dto).ConfigureAwait(false);
    }
    public async Task Core_DomainValueMergeAsync(IDomainValueViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueMergeAsync((IDomainValueDto) dto).ConfigureAwait(false);
    }
    public async Task Core_DomainValueDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_DomainValueHasChangedAsync(IDomainValueViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHasChangedAsync((IDomainValueDto)dto).ConfigureAwait(false);
    }
    public async Task Core_DomainValueBulkInsertAsync(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkInsertAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainValueBulkInsertAsync(ICollection<IDomainValueViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkInsertAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainValue_TempBulkInsertAsync(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValue_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValue_TempBulkInsertAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainValue_TempBulkInsertAsync(ICollection<IDomainValueViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValue_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValue_TempBulkInsertAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainValueBulkMergeAsync(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkMergeAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainValueBulkMergeAsync(ICollection<IDomainValueViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkMergeAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainValueBulkUpdateAsync(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkUpdateAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainValueBulkDeleteAsync(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkDeleteAsync((ICollection<IDomainValueDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_DomainValueGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_DomainValueGetCount()", count);
      return count;
    }
    public ICollection<IDomainValueViewModel> Core_DomainValueGets(params OrderDomainValue[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueGets()", orderBy);
      return _mapper.Map<ICollection<IDomainValueViewModel>>(dto) ?? null;
    }
    public ICollection<IDomainValueViewModel> Core_DomainValueGets(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IDomainValueViewModel>>(dto) ?? null;
    }
    public IDomainValueViewModel Core_DomainValueGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueGet({id})", dto);
      return (IDomainValueViewModel)dto ?? null;
    }
    public ICollection<IDomainValueHistViewModel> Core_DomainValueHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHistGets({id})", dto);
      return _mapper.Map<ICollection<IDomainValueHistViewModel>>(dto) ?? null;
    }
    public IDomainValueHistViewModel Core_DomainValueHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHistEntryGet({histId})", dto);
      return (IDomainValueHistViewModel)dto ?? null;
    }
    public void Core_DomainValueHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHistDelete({histId})");
    }
    public void Core_DomainValueSave(IDomainValueViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueSave((IDomainValueDto)dto);
    }
    public void Core_DomainValueMerge(IDomainValueViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueMerge((IDomainValueDto) dto);
    }
    public void Core_DomainValueDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueDelete(id);
    }
    public bool Core_DomainValueHasChanged(IDomainValueViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueHasChanged((IDomainValueDto)dto);
    }
    public void Core_DomainValueBulkInsert(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkInsert((ICollection<IDomainValueDto>)dtos);
    }
    public void Core_DomainValueBulkInsert(ICollection<IDomainValueViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkInsert((ICollection<IDomainValueDto>)dtos);
    }
    public void Core_DomainValue_TempBulkInsert(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValue_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValue_TempBulkInsert((ICollection<IDomainValueDto>)dtos);
    }
    public void Core_DomainValue_TempBulkInsert(ICollection<IDomainValueViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValue_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValue_TempBulkInsert((ICollection<IDomainValueDto>)dtos);
    }
    public void Core_DomainValueBulkMerge(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkMerge((ICollection<IDomainValueDto>)dtos);
    }
    public void Core_DomainValueBulkMerge(ICollection<IDomainValueViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkMerge((ICollection<IDomainValueDto>)dtos);
    }
    public void Core_DomainValueBulkUpdate(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkUpdate((ICollection<IDomainValueDto>)dtos);
    }
    public void Core_DomainValueBulkDelete(ICollection<IDomainValueViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainValueBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainValueDao)_dataAccess).DomainValueBulkDelete((ICollection<IDomainValueDto>)dtos);
    }
    #endregion
  }
}


