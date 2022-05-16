using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using WorkshopTestProject.Common;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core;
using WorkshopTestProject.Common.DTOs.core;
using WorkshopTestProject.DataAccess.SQL.BaseClasses;

namespace WorkshopTestProject.DataAccess.SQL.core
{
  public partial class SpecialProductsDaoV
  {
    #region Get
    #region sync
    public ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      return SpecialProductsHardCodedGets(new WhereClause(), false, productIds, null, null, orderBy);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      return SpecialProductsHardCodedGets(new WhereClause(), false, productIds, pageNum, pageSize, orderBy);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(WhereClause whereClause, bool distinct, long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      return SpecialProductsHardCodedGets(whereClause, distinct, productIds, null, null, orderBy);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = SpecialProductsHardCodedGets(con, cmd, whereClause, distinct, productIds, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(SqlConnection con, SqlCommand cmd, long[] productIds)
    {
      return SpecialProductsHardCodedGets(con, cmd, new WhereClause(), false, productIds, null, null);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsHardCodedGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      ICollection<ISpecialProductsDtoV> dtos = new List<ISpecialProductsDtoV>();
      try
      {
        GetHardCodedPrepareCommand(productIds, cmd, whereClause,  distinct, pageNum, pageSize, orderBy);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            dtos.Add(GetRead(reader));
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(SpecialProductsDaoV)}.{nameof(SpecialProductsHardCodedGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetHardCodedPrepareCommand(long[] productIds, SqlCommand cmd, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderSpecialProducts[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetHardCodedSqlStatement(productIds, where, distinct, pageNum, pageSize, orderBy);
    }
    private void GetHardCodedPrepareCommand(long[] productIds, SqlCommand cmd, WhereClause whereClause, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderSpecialProducts[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      foreach (IWhereParameter whereParameter in whereClause.Parameters)
      {
        cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
      }
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetHardCodedSqlStatement(productIds, whereClause.Where, distinct, pageNum, pageSize, orderBy);
    }
    private string GetHardCodedSqlStatement(long[] productIds, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderSpecialProducts[] orderBy)
    {
      string sql = $@"
        DECLARE @parameters AS [core].[BigintArray]
";
      foreach (long id in productIds)
      {
        sql += @$"INSERT INTO @parameters (VAL) SELECT {id}";
      }
      sql += $@"SELECT pv.[Id]
              ,pv.[ProductName]
              ,pv.[Price]
          FROM [core].[SpecialProducts](@parameters) pv
      ";
      sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    #endregion
  }
}


