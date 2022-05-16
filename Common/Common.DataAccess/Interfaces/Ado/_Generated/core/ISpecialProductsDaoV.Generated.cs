using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface ISpecialProductsDaoV
  {
    #region Async
    Task<long> SpecialProductsGetCountAsync(long[] productIds);
    Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(long[] productIds, params OrderSpecialProducts[] orderBy);
    Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
    #region Sync
    long SpecialProductsGetCount(long[] productIds);
    ICollection<ISpecialProductsDtoV> SpecialProductsGets(long[] productIds, params OrderSpecialProducts[] orderBy);
    ICollection<ISpecialProductsDtoV> SpecialProductsGets(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
  }
  public partial interface ISpecialProductsInternalDaoV : ISpecialProductsDaoV
  {
    #region Async
    Task<long> SpecialProductsGetCountAsync(WhereClause whereClause, long[] productIds);
    Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(SqlConnection con, SqlCommand cmd, long[] productIds);
    Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(WhereClause whereClause, bool distinct, long[] productIds, params OrderSpecialProducts[] orderBy);
    Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
    #region Sync
    long SpecialProductsGetCount(WhereClause whereClause, long[] productIds);
    ICollection<ISpecialProductsDtoV> SpecialProductsGets(SqlConnection con, SqlCommand cmd, long[] productIds);
    ICollection<ISpecialProductsDtoV> SpecialProductsGets(WhereClause whereClause, bool distinct, long[] productIds, params OrderSpecialProducts[] orderBy);
    ICollection<ISpecialProductsDtoV> SpecialProductsGets(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    ICollection<ISpecialProductsDtoV> SpecialProductsGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
  }
}


