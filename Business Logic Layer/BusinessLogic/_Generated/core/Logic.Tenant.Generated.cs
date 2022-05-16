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
    public async Task<long> Core_TenantGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_TenantGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<ITenantViewModel>> Core_TenantGetsAsync(params OrderTenant[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantGetsAsync()", orderBy);
      return _mapper.Map<ICollection<ITenantViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<ITenantViewModel>> Core_TenantGetsAsync(int? pageNum, int? pageSize, params OrderTenant[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ITenantViewModel>>(dto) ?? null;
    }
    public async Task<ITenantViewModel> Core_TenantGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantGetAsync({id})", dto);
      return (ITenantViewModel)dto ?? null;
    }
    public async Task<ICollection<ITenantHistViewModel>> Core_TenantHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<ITenantHistViewModel>>(dto) ?? null;
    }
    public async Task<ITenantHistViewModel> Core_TenantHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHistEntryGetAsync({histId})", dto);
      return (ITenantHistViewModel)dto ?? null;
    }
    public async Task Core_TenantHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHistDeleteAsync({histId})");
    }
    public async Task Core_TenantSaveAsync(ITenantViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantSaveAsync((ITenantDto)dto).ConfigureAwait(false);
    }
    public async Task Core_TenantMergeAsync(ITenantViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantMergeAsync((ITenantDto) dto).ConfigureAwait(false);
    }
    public async Task Core_TenantDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_TenantHasChangedAsync(ITenantViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHasChangedAsync((ITenantDto)dto).ConfigureAwait(false);
    }
    public async Task Core_TenantBulkInsertAsync(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkInsertAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_TenantBulkInsertAsync(ICollection<ITenantViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkInsertAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Tenant_TempBulkInsertAsync(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Tenant_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).Tenant_TempBulkInsertAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Tenant_TempBulkInsertAsync(ICollection<ITenantViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Tenant_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).Tenant_TempBulkInsertAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_TenantBulkMergeAsync(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkMergeAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_TenantBulkMergeAsync(ICollection<ITenantViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkMergeAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_TenantBulkUpdateAsync(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkUpdateAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_TenantBulkDeleteAsync(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkDeleteAsync((ICollection<ITenantDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_TenantGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_TenantGetCount()", count);
      return count;
    }
    public ICollection<ITenantViewModel> Core_TenantGets(params OrderTenant[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantGets()", orderBy);
      return _mapper.Map<ICollection<ITenantViewModel>>(dto) ?? null;
    }
    public ICollection<ITenantViewModel> Core_TenantGets(int? pageNum, int? pageSize, params OrderTenant[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ITenantViewModel>>(dto) ?? null;
    }
    public ITenantViewModel Core_TenantGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantGet({id})", dto);
      return (ITenantViewModel)dto ?? null;
    }
    public ICollection<ITenantHistViewModel> Core_TenantHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHistGets({id})", dto);
      return _mapper.Map<ICollection<ITenantHistViewModel>>(dto) ?? null;
    }
    public ITenantHistViewModel Core_TenantHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHistEntryGet({histId})", dto);
      return (ITenantHistViewModel)dto ?? null;
    }
    public void Core_TenantHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHistDelete({histId})");
    }
    public void Core_TenantSave(ITenantViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantSave((ITenantDto)dto);
    }
    public void Core_TenantMerge(ITenantViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantMerge((ITenantDto) dto);
    }
    public void Core_TenantDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantDelete(id);
    }
    public bool Core_TenantHasChanged(ITenantViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantHasChanged((ITenantDto)dto);
    }
    public void Core_TenantBulkInsert(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkInsert((ICollection<ITenantDto>)dtos);
    }
    public void Core_TenantBulkInsert(ICollection<ITenantViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkInsert((ICollection<ITenantDto>)dtos);
    }
    public void Core_Tenant_TempBulkInsert(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Tenant_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).Tenant_TempBulkInsert((ICollection<ITenantDto>)dtos);
    }
    public void Core_Tenant_TempBulkInsert(ICollection<ITenantViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Tenant_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).Tenant_TempBulkInsert((ICollection<ITenantDto>)dtos);
    }
    public void Core_TenantBulkMerge(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkMerge((ICollection<ITenantDto>)dtos);
    }
    public void Core_TenantBulkMerge(ICollection<ITenantViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkMerge((ICollection<ITenantDto>)dtos);
    }
    public void Core_TenantBulkUpdate(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkUpdate((ICollection<ITenantDto>)dtos);
    }
    public void Core_TenantBulkDelete(ICollection<ITenantViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.TenantBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.ITenantDao)_dataAccess).TenantBulkDelete((ICollection<ITenantDto>)dtos);
    }
    #endregion
  }
}


