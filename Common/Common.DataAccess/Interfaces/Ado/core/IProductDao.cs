using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core
{
  public partial interface IProductDao
  {
    #region Async
    #endregion
    #region Sync
    ICollection<IProductDto> ProductWithoutModInfoHardCodedGets(List<long> ids);
    ICollection<IProductDto> ProductWithoutModInfoGets(List<long> ids);
    ICollection<IProductDto> ProductWithoutModInfoGets(params OrderProduct[] orderBy);
    ICollection<IProductDto> ProductWithoutModInfoGets(int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    #endregion
  }
  public partial interface IProductInternalDao : IProductDao
  {
    #region Async
    #endregion
    #region Sync
    ICollection<IProductDto> ProductWithoutModInfoGets(SqlConnection con, SqlCommand cmd);
    ICollection<IProductDto> ProductWithoutModInfoGets(WhereClause whereClause, bool distinct, params OrderProduct[] orderBy);
    ICollection<IProductDto> ProductWithoutModInfoGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    ICollection<IProductDto> ProductWithoutModInfoGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy);
    #endregion
  }
}


