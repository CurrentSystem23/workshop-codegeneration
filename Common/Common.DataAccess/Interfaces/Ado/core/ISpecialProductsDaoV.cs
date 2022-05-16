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
    #region Sync
    ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(long[] productIds, params OrderSpecialProducts[] orderBy);
    ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
  }
  public partial interface ISpecialProductsInternalDaoV
  {
    #region Sync
    ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(SqlConnection con, SqlCommand cmd, long[] productIds);
    ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(WhereClause whereClause, bool distinct, long[] productIds, params OrderSpecialProducts[] orderBy);
    ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy);
    #endregion
  }
}


