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
    public async Task<long> Core_UserRightGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserRightGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IUserRightViewModel>> Core_UserRightGetsAsync(params OrderUserRight[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IUserRightViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IUserRightViewModel>> Core_UserRightGetsAsync(int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserRightViewModel>>(dto) ?? null;
    }
    public async Task<IUserRightViewModel> Core_UserRightGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightGetAsync({id})", dto);
      return (IUserRightViewModel)dto ?? null;
    }
    public async Task<ICollection<IUserRightHistViewModel>> Core_UserRightHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IUserRightHistViewModel>>(dto) ?? null;
    }
    public async Task<IUserRightHistViewModel> Core_UserRightHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHistEntryGetAsync({histId})", dto);
      return (IUserRightHistViewModel)dto ?? null;
    }
    public async Task Core_UserRightHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHistDeleteAsync({histId})");
    }
    public async Task Core_UserRightSaveAsync(IUserRightViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightSaveAsync((IUserRightDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserRightMergeAsync(IUserRightViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightMergeAsync((IUserRightDto) dto).ConfigureAwait(false);
    }
    public async Task Core_UserRightDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_UserRightHasChangedAsync(IUserRightViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHasChangedAsync((IUserRightDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserRightBulkInsertAsync(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkInsertAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightBulkInsertAsync(ICollection<IUserRightViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkInsertAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRight_TempBulkInsertAsync(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRight_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRight_TempBulkInsertAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRight_TempBulkInsertAsync(ICollection<IUserRightViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRight_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRight_TempBulkInsertAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightBulkMergeAsync(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkMergeAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightBulkMergeAsync(ICollection<IUserRightViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkMergeAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightBulkUpdateAsync(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkUpdateAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightBulkDeleteAsync(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkDeleteAsync((ICollection<IUserRightDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_UserRightGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserRightGetCount()", count);
      return count;
    }
    public ICollection<IUserRightViewModel> Core_UserRightGets(params OrderUserRight[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightGets()", orderBy);
      return _mapper.Map<ICollection<IUserRightViewModel>>(dto) ?? null;
    }
    public ICollection<IUserRightViewModel> Core_UserRightGets(int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserRightViewModel>>(dto) ?? null;
    }
    public IUserRightViewModel Core_UserRightGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightGet({id})", dto);
      return (IUserRightViewModel)dto ?? null;
    }
    public ICollection<IUserRightHistViewModel> Core_UserRightHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHistGets({id})", dto);
      return _mapper.Map<ICollection<IUserRightHistViewModel>>(dto) ?? null;
    }
    public IUserRightHistViewModel Core_UserRightHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHistEntryGet({histId})", dto);
      return (IUserRightHistViewModel)dto ?? null;
    }
    public void Core_UserRightHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHistDelete({histId})");
    }
    public void Core_UserRightSave(IUserRightViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightSave((IUserRightDto)dto);
    }
    public void Core_UserRightMerge(IUserRightViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightMerge((IUserRightDto) dto);
    }
    public void Core_UserRightDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightDelete(id);
    }
    public bool Core_UserRightHasChanged(IUserRightViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightHasChanged((IUserRightDto)dto);
    }
    public void Core_UserRightBulkInsert(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkInsert((ICollection<IUserRightDto>)dtos);
    }
    public void Core_UserRightBulkInsert(ICollection<IUserRightViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkInsert((ICollection<IUserRightDto>)dtos);
    }
    public void Core_UserRight_TempBulkInsert(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRight_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRight_TempBulkInsert((ICollection<IUserRightDto>)dtos);
    }
    public void Core_UserRight_TempBulkInsert(ICollection<IUserRightViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRight_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRight_TempBulkInsert((ICollection<IUserRightDto>)dtos);
    }
    public void Core_UserRightBulkMerge(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkMerge((ICollection<IUserRightDto>)dtos);
    }
    public void Core_UserRightBulkMerge(ICollection<IUserRightViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkMerge((ICollection<IUserRightDto>)dtos);
    }
    public void Core_UserRightBulkUpdate(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkUpdate((ICollection<IUserRightDto>)dtos);
    }
    public void Core_UserRightBulkDelete(ICollection<IUserRightViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightDao)_dataAccess).UserRightBulkDelete((ICollection<IUserRightDto>)dtos);
    }
    #endregion
  }
}


