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
    public async Task<long> Core_SpecialProductsGetCountAsync(long[] productIds)
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV)_dataAccess).SpecialProductsGetCountAsync(productIds).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_SpecialProductsGetCountAsync()", productIds, count);
      return count;
    }
    public async Task<ICollection<ISpecialProductsViewModel>> Core_SpecialProductsGetsAsync(long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV)_dataAccess).SpecialProductsGetsAsync(productIds, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.SpecialProductsGetsAsync()", productIds, orderBy);
      return _mapper.Map<ICollection<ISpecialProductsViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<ISpecialProductsViewModel>> Core_SpecialProductsGetsAsync(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV)_dataAccess).SpecialProductsGetsAsync(productIds, pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.SpecialProductsGetsAsync()", dto, productIds, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ISpecialProductsViewModel>>(dto) ?? null;
    }
    #endregion
    #region Sync
    public long Core_SpecialProductsGetCount(long[] productIds)
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV)_dataAccess).SpecialProductsGetCount(productIds);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_SpecialProductsGetCount()", productIds, count);
      return count;
    }
    public ICollection<ISpecialProductsViewModel> Core_SpecialProductsGets(long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV)_dataAccess).SpecialProductsGetsAsync(productIds, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.SpecialProductsGets()", productIds, orderBy);
      return _mapper.Map<ICollection<ISpecialProductsViewModel>>(dto) ?? null;
    }
    public ICollection<ISpecialProductsViewModel> Core_SpecialProductsGets(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV)_dataAccess).SpecialProductsGetsAsync(productIds, pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.SpecialProductsGets()", dto, productIds, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<ISpecialProductsViewModel>>(dto) ?? null;
    }
    #endregion
  }
}


