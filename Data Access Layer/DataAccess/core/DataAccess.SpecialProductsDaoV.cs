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
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsHardCodedGets(long[] productIds, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsHardCodedGets(new WhereClause(), false, productIds, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV.SpecialProductsHardCodedGets(long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsHardCodedGets(new WhereClause(), false, productIds, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsHardCodedGets(SqlConnection con, SqlCommand cmd, long[] productIds)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsHardCodedGets(con, cmd, new WhereClause(), false, productIds, null, null);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsHardCodedGets(WhereClause whereClause, bool distinct, long[] productIds, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsHardCodedGets(whereClause, distinct, productIds, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsHardCodedGets(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsHardCodedGets(whereClause, distinct, productIds, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.ISpecialProductsDtoV> Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV.SpecialProductsHardCodedGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params Common.DTOs.core.OrderSpecialProducts[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV>().SpecialProductsHardCodedGets(con, cmd, whereClause, distinct, productIds, pageNum, pageSize, orderBy);
    }
    #endregion
    #endregion


  }
}
