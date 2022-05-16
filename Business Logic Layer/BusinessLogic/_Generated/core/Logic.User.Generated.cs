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
    public async Task<long> Core_UserGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IUserViewModel>> Core_UserGetsAsync(params OrderUser[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IUserViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IUserViewModel>> Core_UserGetsAsync(int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserViewModel>>(dto) ?? null;
    }
    public async Task<IUserViewModel> Core_UserGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGetAsync({id})", dto);
      return (IUserViewModel)dto ?? null;
    }
    public async Task<ICollection<IUserHistViewModel>> Core_UserHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IUserHistViewModel>>(dto) ?? null;
    }
    public async Task<IUserHistViewModel> Core_UserHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHistEntryGetAsync({histId})", dto);
      return (IUserHistViewModel)dto ?? null;
    }
    public async Task Core_UserHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHistDeleteAsync({histId})");
    }
    public async Task Core_UserSaveAsync(IUserViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserSaveAsync((IUserDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserMergeAsync(IUserViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserMergeAsync((IUserDto) dto).ConfigureAwait(false);
    }
    public async Task Core_UserDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_UserHasChangedAsync(IUserViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHasChangedAsync((IUserDto)dto).ConfigureAwait(false);
    }
    public async Task Core_UserBulkInsertAsync(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkInsertAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserBulkInsertAsync(ICollection<IUserViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkInsertAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_User_TempBulkInsertAsync(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.User_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).User_TempBulkInsertAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_User_TempBulkInsertAsync(ICollection<IUserViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.User_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).User_TempBulkInsertAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserBulkMergeAsync(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkMergeAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserBulkMergeAsync(ICollection<IUserViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkMergeAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserBulkUpdateAsync(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkUpdateAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_UserBulkDeleteAsync(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkDeleteAsync((ICollection<IUserDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_UserGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_UserGetCount()", count);
      return count;
    }
    public ICollection<IUserViewModel> Core_UserGets(params OrderUser[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGets()", orderBy);
      return _mapper.Map<ICollection<IUserViewModel>>(dto) ?? null;
    }
    public ICollection<IUserViewModel> Core_UserGets(int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IUserViewModel>>(dto) ?? null;
    }
    public IUserViewModel Core_UserGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserGet({id})", dto);
      return (IUserViewModel)dto ?? null;
    }
    public ICollection<IUserHistViewModel> Core_UserHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHistGets({id})", dto);
      return _mapper.Map<ICollection<IUserHistViewModel>>(dto) ?? null;
    }
    public IUserHistViewModel Core_UserHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHistEntryGet({histId})", dto);
      return (IUserHistViewModel)dto ?? null;
    }
    public void Core_UserHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHistDelete({histId})");
    }
    public void Core_UserSave(IUserViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserSave((IUserDto)dto);
    }
    public void Core_UserMerge(IUserViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserMerge((IUserDto) dto);
    }
    public void Core_UserDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserDelete(id);
    }
    public bool Core_UserHasChanged(IUserViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserHasChanged((IUserDto)dto);
    }
    public void Core_UserBulkInsert(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkInsert((ICollection<IUserDto>)dtos);
    }
    public void Core_UserBulkInsert(ICollection<IUserViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkInsert((ICollection<IUserDto>)dtos);
    }
    public void Core_User_TempBulkInsert(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.User_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).User_TempBulkInsert((ICollection<IUserDto>)dtos);
    }
    public void Core_User_TempBulkInsert(ICollection<IUserViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.User_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).User_TempBulkInsert((ICollection<IUserDto>)dtos);
    }
    public void Core_UserBulkMerge(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkMerge((ICollection<IUserDto>)dtos);
    }
    public void Core_UserBulkMerge(ICollection<IUserViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkMerge((ICollection<IUserDto>)dtos);
    }
    public void Core_UserBulkUpdate(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkUpdate((ICollection<IUserDto>)dtos);
    }
    public void Core_UserBulkDelete(ICollection<IUserViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.UserBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IUserDao)_dataAccess).UserBulkDelete((ICollection<IUserDto>)dtos);
    }
    #endregion
  }
}


