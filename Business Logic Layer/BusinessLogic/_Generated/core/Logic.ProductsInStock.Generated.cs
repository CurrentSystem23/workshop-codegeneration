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
    public async Task<long> Core_ProductsInStockGetCountAsync()
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV)_dataAccess).ProductsInStockGetCountAsync().ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_ProductsInStockGetCountAsync()", count);
      return count;
    }
    public async Task<ICollection<IProductsInStockViewModel>> Core_ProductsInStockGetsAsync(params OrderProductsInStock[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV)_dataAccess).ProductsInStockGetsAsync(orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductsInStockGetsAsync()", orderBy);
      return _mapper.Map<ICollection<IProductsInStockViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IProductsInStockViewModel>> Core_ProductsInStockGetsAsync(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV)_dataAccess).ProductsInStockGetsAsync(pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductsInStockGetsAsync()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IProductsInStockViewModel>>(dto) ?? null;
    }
    #endregion
    #region Sync
    public long Core_ProductsInStockGetCount()
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV)_dataAccess).ProductsInStockGetCount();
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_ProductsInStockGetCount()", count);
      return count;
    }
    public ICollection<IProductsInStockViewModel> Core_ProductsInStockGets(params OrderProductsInStock[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV)_dataAccess).ProductsInStockGetsAsync(orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductsInStockGets()", orderBy);
      return _mapper.Map<ICollection<IProductsInStockViewModel>>(dto) ?? null;
    }
    public ICollection<IProductsInStockViewModel> Core_ProductsInStockGets(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV)_dataAccess).ProductsInStockGetsAsync(pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductsInStockGets()", dto, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IProductsInStockViewModel>>(dto) ?? null;
    }
    #endregion
  }
}


