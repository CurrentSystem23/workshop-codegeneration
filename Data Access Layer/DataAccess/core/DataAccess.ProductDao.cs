using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;

namespace WorkshopTestProject.DataAccess
{
  public partial class DataAccess
  {
    #region core.ProductDao
    #region Async
    #endregion
    #region Sync
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductWithoutModInfoHardCodedGets(List<long> ids)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoHardCodedGets(ids);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductWithoutModInfoGets(List<long> ids)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoGets(ids);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductWithoutModInfoGets(params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoGets(new WhereClause(), false, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductDao.ProductWithoutModInfoGets(int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductWithoutModInfoGets(SqlConnection con, SqlCommand cmd)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoGets(con, cmd, new WhereClause(), false, null, null);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductWithoutModInfoGets(WhereClause whereClause, bool distinct, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoGets(whereClause, distinct, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductWithoutModInfoGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoGets(whereClause, distinct, pageNum, pageSize, orderBy);
    }
    ICollection<Common.DTOs.core.IProductDto> Common.DataAccess.Interfaces.Ado.core.IProductInternalDao.ProductWithoutModInfoGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params Common.DTOs.core.OrderProduct[] orderBy)
    {
      return _provider.GetRequiredService<Common.DataAccess.Interfaces.Ado.core.IProductInternalDao>().ProductWithoutModInfoGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
    }
    #endregion
    #endregion

  }
}
