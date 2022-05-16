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
    public async Task<long> Core_ProductGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_ProductGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IProductViewModel>> Core_ProductGetsAsync(params OrderProduct[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IProductViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IProductViewModel>> Core_ProductGetsAsync(int? pageNum, int? pageSize, params OrderProduct[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IProductViewModel>>(dto) ?? null;
    }
    public async Task<IProductViewModel> Core_ProductGetAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGetAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductGetAsync({id})", dto);
      return (IProductViewModel)dto ?? null;
    }
    public async Task<ICollection<IProductHistViewModel>> Core_ProductHistGetsAsync(long id)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHistGetsAsync(id).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHistGetsAsync({id})", dto);
      return _mapper.Map<ICollection<IProductHistViewModel>>(dto) ?? null;
    }
    public async Task<IProductHistViewModel> Core_ProductHistEntryGetAsync(long histId)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHistEntryGetAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHistEntryGetAsync({histId})", dto);
      return (IProductHistViewModel)dto ?? null;
    }
    public async Task Core_ProductHistDeleteAsync(long histId)
    {
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHistDeleteAsync(histId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHistDeleteAsync({histId})");
    }
    public async Task Core_ProductSaveAsync(IProductViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductSaveAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductSaveAsync((IProductDto)dto).ConfigureAwait(false);
    }
    public async Task Core_ProductMergeAsync(IProductViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductMergeAsync()", dto);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductMergeAsync((IProductDto) dto).ConfigureAwait(false);
    }
    public async Task Core_ProductDeleteAsync(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductDeleteAsync({id})");
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductDeleteAsync(id).ConfigureAwait(false);
    }
    public async Task<bool> Core_ProductHasChangedAsync(IProductViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHasChangedAsync()", dto);
      return await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHasChangedAsync((IProductDto)dto).ConfigureAwait(false);
    }
    public async Task Core_ProductBulkInsertAsync(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkInsertAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_ProductBulkInsertAsync(ICollection<IProductViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkInsertAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Product_TempBulkInsertAsync(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Product_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).Product_TempBulkInsertAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_Product_TempBulkInsertAsync(ICollection<IProductViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Product_TempBulkInsertAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).Product_TempBulkInsertAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_ProductBulkMergeAsync(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkMergeAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_ProductBulkMergeAsync(ICollection<IProductViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkMergeAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkMergeAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_ProductBulkUpdateAsync(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkUpdateAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkUpdateAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    public async Task Core_ProductBulkDeleteAsync(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkDeleteAsync()", dtos);
      await ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkDeleteAsync((ICollection<IProductDto>)dtos).ConfigureAwait(false);
    }
    #endregion
    #region Sync
    public long Core_ProductGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_ProductGetCount()", count);
      return count;
    }
    public ICollection<IProductViewModel> Core_ProductGets(params OrderProduct[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductGets()", orderBy);
      return _mapper.Map<ICollection<IProductViewModel>>(dto) ?? null;
    }
    public ICollection<IProductViewModel> Core_ProductGets(int? pageNum, int? pageSize, params OrderProduct[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IProductViewModel>>(dto) ?? null;
    }
    public IProductViewModel Core_ProductGet(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductGet(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductGet({id})", dto);
      return (IProductViewModel)dto ?? null;
    }
    public ICollection<IProductHistViewModel> Core_ProductHistGets(long id)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHistGets(id);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHistGets({id})", dto);
      return _mapper.Map<ICollection<IProductHistViewModel>>(dto) ?? null;
    }
    public IProductHistViewModel Core_ProductHistEntryGet(long histId)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHistEntryGet(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHistEntryGet({histId})", dto);
      return (IProductHistViewModel)dto ?? null;
    }
    public void Core_ProductHistDelete(long histId)
    {
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHistDelete(histId);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHistDelete({histId})");
    }
    public void Core_ProductSave(IProductViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductSave()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductSave((IProductDto)dto);
    }
    public void Core_ProductMerge(IProductViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductMerge()", dto);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductMerge((IProductDto) dto);
    }
    public void Core_ProductDelete(long id)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductDelete({id})");
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductDelete(id);
    }
    public bool Core_ProductHasChanged(IProductViewModel dto)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductHasChanged()", dto);
      return ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductHasChanged((IProductDto)dto);
    }
    public void Core_ProductBulkInsert(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkInsert((ICollection<IProductDto>)dtos);
    }
    public void Core_ProductBulkInsert(ICollection<IProductViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkInsert((ICollection<IProductDto>)dtos);
    }
    public void Core_Product_TempBulkInsert(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Product_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).Product_TempBulkInsert((ICollection<IProductDto>)dtos);
    }
    public void Core_Product_TempBulkInsert(ICollection<IProductViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.Product_TempBulkInsert()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).Product_TempBulkInsert((ICollection<IProductDto>)dtos);
    }
    public void Core_ProductBulkMerge(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkMerge((ICollection<IProductDto>)dtos);
    }
    public void Core_ProductBulkMerge(ICollection<IProductViewModel> dtos, bool identityInsert)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkMerge()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkMerge((ICollection<IProductDto>)dtos);
    }
    public void Core_ProductBulkUpdate(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkUpdate()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkUpdate((ICollection<IProductDto>)dtos);
    }
    public void Core_ProductBulkDelete(ICollection<IProductViewModel> dtos)
    {
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductBulkDelete()", dtos);
      ((Common.DataAccess.Interfaces.Ado.core.IProductDao)_dataAccess).ProductBulkDelete((ICollection<IProductDto>)dtos);
    }
    #endregion
  }
}


