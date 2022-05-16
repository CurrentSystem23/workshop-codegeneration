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
    public async Task<long> Core_UserGroupGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserGroupGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IUserGroupViewModel>> Core_UserGroupGetsAsync(params OrderUserGroup[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IUserGroupViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IUserGroupViewModel>> Core_UserGroupGetsAsync(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserGroupViewModel>>(dto) ?? null;
    }
    public async Task<IUserGroupViewModel> Core_UserGroupGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupGetAsync({id})", dto);
      return (IUserGroupViewModel)dto ?? null;
    }
    public async Task<ICollection<IUserGroupHistViewModel>> Core_UserGroupHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IUserGroupHistViewModel>>(dto) ?? null;
    }
    public async Task<IUserGroupHistViewModel> Core_UserGroupHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHistEntryGetAsync({histId})", dto);
      return (IUserGroupHistViewModel)dto ?? null;
    }
    public async Task Core_UserGroupHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHistDeleteAsync({histId})");
    }
    public async Task Core_UserGroupSaveAsync(IUserGroupViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupSaveAsync((IUserGroupDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserGroupMergeAsync(IUserGroupViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupMergeAsync((IUserGroupDto) dto).ConfigureAwait(false);
    }
    public async Task Core_UserGroupDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_UserGroupHasChangedAsync(IUserGroupViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHasChangedAsync((IUserGroupDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserGroupBulkInsertAsync(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkInsertAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserGroupBulkInsertAsync(ICollection<IUserGroupViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkInsertAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserGroup_TempBulkInsertAsync(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroup_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroup_TempBulkInsertAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserGroup_TempBulkInsertAsync(ICollection<IUserGroupViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroup_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroup_TempBulkInsertAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserGroupBulkMergeAsync(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkMergeAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserGroupBulkMergeAsync(ICollection<IUserGroupViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkMergeAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserGroupBulkUpdateAsync(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkUpdateAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserGroupBulkDeleteAsync(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkDeleteAsync((ICollection<IUserGroupDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_UserGroupGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserGroupGetCount()", count);
      return count;
    }
    public ICollection<IUserGroupViewModel> Core_UserGroupGets(params OrderUserGroup[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupGets()", orderBy);
      return _mapper.Map<ICollection<IUserGroupViewModel>>(dto) ?? null;
    }
    public ICollection<IUserGroupViewModel> Core_UserGroupGets(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserGroupViewModel>>(dto) ?? null;
    }
    public IUserGroupViewModel Core_UserGroupGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupGet({id})", dto);
      return (IUserGroupViewModel)dto ?? null;
    }
    public ICollection<IUserGroupHistViewModel> Core_UserGroupHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHistGets({id})", dto);
      return _mapper.Map<ICollection<IUserGroupHistViewModel>>(dto) ?? null;
    }
    public IUserGroupHistViewModel Core_UserGroupHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHistEntryGet({histId})", dto);
      return (IUserGroupHistViewModel)dto ?? null;
    }
    public void Core_UserGroupHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHistDelete({histId})");
    }
    public void Core_UserGroupSave(IUserGroupViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupSave((IUserGroupDto)dto);
    }
    public void Core_UserGroupMerge(IUserGroupViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupMerge((IUserGroupDto) dto);
    }
    public void Core_UserGroupDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupDelete(id);
    }
    public bool Core_UserGroupHasChanged(IUserGroupViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupHasChanged((IUserGroupDto)dto);
    }
    public void Core_UserGroupBulkInsert(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkInsert((ICollection<IUserGroupDto>)dtos);
    }
    public void Core_UserGroupBulkInsert(ICollection<IUserGroupViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkInsert((ICollection<IUserGroupDto>)dtos);
    }
    public void Core_UserGroup_TempBulkInsert(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroup_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroup_TempBulkInsert((ICollection<IUserGroupDto>)dtos);
    }
    public void Core_UserGroup_TempBulkInsert(ICollection<IUserGroupViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroup_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroup_TempBulkInsert((ICollection<IUserGroupDto>)dtos);
    }
    public void Core_UserGroupBulkMerge(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkMerge((ICollection<IUserGroupDto>)dtos);
    }
    public void Core_UserGroupBulkMerge(ICollection<IUserGroupViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkMerge((ICollection<IUserGroupDto>)dtos);
    }
    public void Core_UserGroupBulkUpdate(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkUpdate((ICollection<IUserGroupDto>)dtos);
    }
    public void Core_UserGroupBulkDelete(ICollection<IUserGroupViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGroupBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserGroupDao)_dataAccess).UserGroupBulkDelete((ICollection<IUserGroupDto>)dtos);
    }
    #endregion
  }
}


