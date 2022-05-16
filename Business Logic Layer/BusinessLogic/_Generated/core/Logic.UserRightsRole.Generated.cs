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
    public async Task<long> Core_UserRightsRoleGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserRightsRoleGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IUserRightsRoleViewModel>> Core_UserRightsRoleGetsAsync(params OrderUserRightsRole[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IUserRightsRoleViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IUserRightsRoleViewModel>> Core_UserRightsRoleGetsAsync(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserRightsRoleViewModel>>(dto) ?? null;
    }
    public async Task<IUserRightsRoleViewModel> Core_UserRightsRoleGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleGetAsync({id})", dto);
      return (IUserRightsRoleViewModel)dto ?? null;
    }
    public async Task<ICollection<IUserRightsRoleHistViewModel>> Core_UserRightsRoleHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IUserRightsRoleHistViewModel>>(dto) ?? null;
    }
    public async Task<IUserRightsRoleHistViewModel> Core_UserRightsRoleHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHistEntryGetAsync({histId})", dto);
      return (IUserRightsRoleHistViewModel)dto ?? null;
    }
    public async Task Core_UserRightsRoleHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHistDeleteAsync({histId})");
    }
    public async Task Core_UserRightsRoleSaveAsync(IUserRightsRoleViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleSaveAsync((IUserRightsRoleDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleMergeAsync(IUserRightsRoleViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleMergeAsync((IUserRightsRoleDto) dto).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_UserRightsRoleHasChangedAsync(IUserRightsRoleViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHasChangedAsync((IUserRightsRoleDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkInsertAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkInsertAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRole_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRole_TempBulkInsertAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRole_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRole_TempBulkInsertAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkMergeAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkMergeAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleBulkUpdateAsync(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkUpdateAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserRightsRoleBulkDeleteAsync(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkDeleteAsync((ICollection<IUserRightsRoleDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_UserRightsRoleGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserRightsRoleGetCount()", count);
      return count;
    }
    public ICollection<IUserRightsRoleViewModel> Core_UserRightsRoleGets(params OrderUserRightsRole[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleGets()", orderBy);
      return _mapper.Map<ICollection<IUserRightsRoleViewModel>>(dto) ?? null;
    }
    public ICollection<IUserRightsRoleViewModel> Core_UserRightsRoleGets(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserRightsRoleViewModel>>(dto) ?? null;
    }
    public IUserRightsRoleViewModel Core_UserRightsRoleGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleGet({id})", dto);
      return (IUserRightsRoleViewModel)dto ?? null;
    }
    public ICollection<IUserRightsRoleHistViewModel> Core_UserRightsRoleHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHistGets({id})", dto);
      return _mapper.Map<ICollection<IUserRightsRoleHistViewModel>>(dto) ?? null;
    }
    public IUserRightsRoleHistViewModel Core_UserRightsRoleHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHistEntryGet({histId})", dto);
      return (IUserRightsRoleHistViewModel)dto ?? null;
    }
    public void Core_UserRightsRoleHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHistDelete({histId})");
    }
    public void Core_UserRightsRoleSave(IUserRightsRoleViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleSave((IUserRightsRoleDto)dto);
    }
    public void Core_UserRightsRoleMerge(IUserRightsRoleViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleMerge((IUserRightsRoleDto) dto);
    }
    public void Core_UserRightsRoleDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleDelete(id);
    }
    public bool Core_UserRightsRoleHasChanged(IUserRightsRoleViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleHasChanged((IUserRightsRoleDto)dto);
    }
    public void Core_UserRightsRoleBulkInsert(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkInsert((ICollection<IUserRightsRoleDto>)dtos);
    }
    public void Core_UserRightsRoleBulkInsert(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkInsert((ICollection<IUserRightsRoleDto>)dtos);
    }
    public void Core_UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRole_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRole_TempBulkInsert((ICollection<IUserRightsRoleDto>)dtos);
    }
    public void Core_UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRole_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRole_TempBulkInsert((ICollection<IUserRightsRoleDto>)dtos);
    }
    public void Core_UserRightsRoleBulkMerge(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkMerge((ICollection<IUserRightsRoleDto>)dtos);
    }
    public void Core_UserRightsRoleBulkMerge(ICollection<IUserRightsRoleViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkMerge((ICollection<IUserRightsRoleDto>)dtos);
    }
    public void Core_UserRightsRoleBulkUpdate(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkUpdate((ICollection<IUserRightsRoleDto>)dtos);
    }
    public void Core_UserRightsRoleBulkDelete(ICollection<IUserRightsRoleViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserRightsRoleBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao)_dataAccess).UserRightsRoleBulkDelete((ICollection<IUserRightsRoleDto>)dtos);
    }
    #endregion
  }
}


