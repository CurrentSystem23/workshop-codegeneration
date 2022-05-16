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
    public async Task<long> Core_ProductInStockGetCountAsync(long? productId)
    {
      var count = await ((Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV)_dataAccess).ProductInStockGetCountAsync(productId).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_ProductInStockGetCountAsync()", productId, count);
      return count;
    }
    public async Task<ICollection<IProductInStockViewModel>> Core_ProductInStockGetsAsync(long? productId, params OrderProductInStock[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV)_dataAccess).ProductInStockGetsAsync(productId, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductInStockGetsAsync()", productId, orderBy);
      return _mapper.Map<ICollection<IProductInStockViewModel>>(dto) ?? null;
    }
    public async Task<ICollection<IProductInStockViewModel>> Core_ProductInStockGetsAsync(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      var dto = await ((Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV)_dataAccess).ProductInStockGetsAsync(productId, pageNum, pageSize, orderBy).ConfigureAwait(false);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductInStockGetsAsync()", dto, productId, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IProductInStockViewModel>>(dto) ?? null;
    }
    #endregion
    #region Sync
    public long Core_ProductInStockGetCount(long? productId)
    {
      var count = ((Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV)_dataAccess).ProductInStockGetCount(productId);
      if (_logger != null) _logger?.LogTrace($@"Logic.Core_ProductInStockGetCount()", productId, count);
      return count;
    }
    public ICollection<IProductInStockViewModel> Core_ProductInStockGets(long? productId, params OrderProductInStock[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV)_dataAccess).ProductInStockGetsAsync(productId, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductInStockGets()", productId, orderBy);
      return _mapper.Map<ICollection<IProductInStockViewModel>>(dto) ?? null;
    }
    public ICollection<IProductInStockViewModel> Core_ProductInStockGets(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      var dto = ((Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV)_dataAccess).ProductInStockGetsAsync(productId, pageNum, pageSize, orderBy);
      if (_logger != null) _logger?.LogTrace($@"Logic.ProductInStockGets()", dto, productId, pageNum, pageSize, orderBy);
      return _mapper.Map<ICollection<IProductInStockViewModel>>(dto) ?? null;
    }
    #endregion
  }
}


