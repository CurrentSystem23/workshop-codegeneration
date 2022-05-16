using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IProductInStockDaoV
  {
    #region Sync
    ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(long? productId, params OrderProductInStock[] orderBy);
    ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
  }
  public partial interface IProductInStockInternalDaoV : IProductInStockDaoV
  {
    #region Sync
    ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(SqlConnection con, SqlCommand cmd, long? productId);
    ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(WhereClause whereClause, bool distinct, long? productId, params OrderProductInStock[] orderBy);
    ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
  }
}


