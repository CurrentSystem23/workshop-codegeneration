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
    #region Async
    Task<long> ProductInStockGetCountAsync(long? productId);
    Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(long? productId, params OrderProductInStock[] orderBy);
    Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
    #region Sync
    long ProductInStockGetCount(long? productId);
    ICollection<IProductInStockDtoV> ProductInStockGets(long? productId, params OrderProductInStock[] orderBy);
    ICollection<IProductInStockDtoV> ProductInStockGets(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
  }
  public partial interface IProductInStockInternalDaoV : IProductInStockDaoV
  {
    #region Async
    Task<long> ProductInStockGetCountAsync(WhereClause whereClause, long? productId);
    Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(SqlConnection con, SqlCommand cmd, long? productId);
    Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(WhereClause whereClause, bool distinct, long? productId, params OrderProductInStock[] orderBy);
    Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
    #region Sync
    long ProductInStockGetCount(WhereClause whereClause, long? productId);
    ICollection<IProductInStockDtoV> ProductInStockGets(SqlConnection con, SqlCommand cmd, long? productId);
    ICollection<IProductInStockDtoV> ProductInStockGets(WhereClause whereClause, bool distinct, long? productId, params OrderProductInStock[] orderBy);
    ICollection<IProductInStockDtoV> ProductInStockGets(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    ICollection<IProductInStockDtoV> ProductInStockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy);
    #endregion
  }
}


