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
    public async Task<long> Core_DomainTypeGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_DomainTypeGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IDomainTypeViewModel>> Core_DomainTypeGetsAsync(params OrderDomainType[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IDomainTypeViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IDomainTypeViewModel>> Core_DomainTypeGetsAsync(int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IDomainTypeViewModel>>(dto) ?? null;
    }
    public async Task<IDomainTypeViewModel> Core_DomainTypeGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeGetAsync({id})", dto);
      return (IDomainTypeViewModel)dto ?? null;
    }
    public async Task<ICollection<IDomainTypeHistViewModel>> Core_DomainTypeHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IDomainTypeHistViewModel>>(dto) ?? null;
    }
    public async Task<IDomainTypeHistViewModel> Core_DomainTypeHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHistEntryGetAsync({histId})", dto);
      return (IDomainTypeHistViewModel)dto ?? null;
    }
    public async Task Core_DomainTypeHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHistDeleteAsync({histId})");
    }
    public async Task Core_DomainTypeSaveAsync(IDomainTypeViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeSaveAsync((IDomainTypeDto)dto).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeMergeAsync(IDomainTypeViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeMergeAsync((IDomainTypeDto) dto).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_DomainTypeHasChangedAsync(IDomainTypeViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHasChangedAsync((IDomainTypeDto)dto).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkInsertAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkInsertAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainType_TempBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainType_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainType_TempBulkInsertAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainType_TempBulkInsertAsync(ICollection<IDomainTypeViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainType_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainType_TempBulkInsertAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeBulkMergeAsync(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkMergeAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeBulkMergeAsync(ICollection<IDomainTypeViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkMergeAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeBulkUpdateAsync(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkUpdateAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_DomainTypeBulkDeleteAsync(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkDeleteAsync((ICollection<IDomainTypeDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_DomainTypeGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_DomainTypeGetCount()", count);
      return count;
    }
    public ICollection<IDomainTypeViewModel> Core_DomainTypeGets(params OrderDomainType[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeGets()", orderBy);
      return _mapper.Map<ICollection<IDomainTypeViewModel>>(dto) ?? null;
    }
    public ICollection<IDomainTypeViewModel> Core_DomainTypeGets(int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IDomainTypeViewModel>>(dto) ?? null;
    }
    public IDomainTypeViewModel Core_DomainTypeGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeGet({id})", dto);
      return (IDomainTypeViewModel)dto ?? null;
    }
    public ICollection<IDomainTypeHistViewModel> Core_DomainTypeHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHistGets({id})", dto);
      return _mapper.Map<ICollection<IDomainTypeHistViewModel>>(dto) ?? null;
    }
    public IDomainTypeHistViewModel Core_DomainTypeHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHistEntryGet({histId})", dto);
      return (IDomainTypeHistViewModel)dto ?? null;
    }
    public void Core_DomainTypeHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHistDelete({histId})");
    }
    public void Core_DomainTypeSave(IDomainTypeViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeSave((IDomainTypeDto)dto);
    }
    public void Core_DomainTypeMerge(IDomainTypeViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeMerge((IDomainTypeDto) dto);
    }
    public void Core_DomainTypeDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeDelete(id);
    }
    public bool Core_DomainTypeHasChanged(IDomainTypeViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeHasChanged((IDomainTypeDto)dto);
    }
    public void Core_DomainTypeBulkInsert(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkInsert((ICollection<IDomainTypeDto>)dtos);
    }
    public void Core_DomainTypeBulkInsert(ICollection<IDomainTypeViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkInsert((ICollection<IDomainTypeDto>)dtos);
    }
    public void Core_DomainType_TempBulkInsert(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainType_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainType_TempBulkInsert((ICollection<IDomainTypeDto>)dtos);
    }
    public void Core_DomainType_TempBulkInsert(ICollection<IDomainTypeViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainType_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainType_TempBulkInsert((ICollection<IDomainTypeDto>)dtos);
    }
    public void Core_DomainTypeBulkMerge(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkMerge((ICollection<IDomainTypeDto>)dtos);
    }
    public void Core_DomainTypeBulkMerge(ICollection<IDomainTypeViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkMerge((ICollection<IDomainTypeDto>)dtos);
    }
    public void Core_DomainTypeBulkUpdate(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkUpdate((ICollection<IDomainTypeDto>)dtos);
    }
    public void Core_DomainTypeBulkDelete(ICollection<IDomainTypeViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.DomainTypeBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao)_dataAccess).DomainTypeBulkDelete((ICollection<IDomainTypeDto>)dtos);
    }
    #endregion
  }
}


