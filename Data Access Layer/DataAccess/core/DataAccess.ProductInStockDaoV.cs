using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;

namespace WorkshopTestProject.DataAccess
{
  public partial class DataAccess
  {
    #region core.ProductInStockDaoV
    #region Async
    #endregion
    #region Sync
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockHardCodedGets(long? productId, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockHardCodedGets(new WhereClause(), false, productId, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV.ProductInStockHardCodedGets(long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockHardCodedGets(new WhereClause(), false, productId, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockHardCodedGets(SqlConnection con, SqlCommand cmd, long? productId)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockHardCodedGets(con, cmd, new WhereClause(), false, productId, null, null);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockHardCodedGets(WhereClause whereClause, bool distinct, long? productId, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockHardCodedGets(whereClause, distinct, productId, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockHardCodedGets(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockHardCodedGets(whereClause, distinct, productId, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductInStockDtoV> Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV.ProductInStockHardCodedGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProductInStock[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV>().ProductInStockHardCodedGets(con, cmd, whereClause, distinct, productId, pageNum, pageSize, orderBy);
    }
    #endregion
    #endregion


  }
}
