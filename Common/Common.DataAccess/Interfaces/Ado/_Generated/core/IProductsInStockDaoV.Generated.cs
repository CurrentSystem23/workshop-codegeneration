using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IProductsInStockDaoV
  {
    #region Async
    Task<long> ProductsInStockGetCountAsync();
    Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(params OrderProductsInStock[] orderBy);
    Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    #endregion
    #region Sync
    long ProductsInStockGetCount();
    ICollection<IProductsInStockDtoV> ProductsInStockGets(params OrderProductsInStock[] orderBy);
    ICollection<IProductsInStockDtoV> ProductsInStockGets(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    #endregion
  }
  public partial interface IProductsInStockInternalDaoV : IProductsInStockDaoV
  {
    #region Async
    Task<long> ProductsInStockGetCountAsync(WhereClause whereClause);
    Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(SqlConnection con, SqlCommand cmd);
    Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(WhereClause whereClause, bool distinct, params OrderProductsInStock[] orderBy);
    Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    #endregion
    #region Sync
    long ProductsInStockGetCount(WhereClause whereClause);
    ICollection<IProductsInStockDtoV> ProductsInStockGets(SqlConnection con, SqlCommand cmd);
    ICollection<IProductsInStockDtoV> ProductsInStockGets(WhereClause whereClause, bool distinct, params OrderProductsInStock[] orderBy);
    ICollection<IProductsInStockDtoV> ProductsInStockGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    ICollection<IProductsInStockDtoV> ProductsInStockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy);
    #endregion
  }
}


