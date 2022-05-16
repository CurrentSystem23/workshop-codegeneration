using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using WorkshopTestProject.Common;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DTOs.core;

namespace WorkshopTestProject.DataAccess.SQL.core
{
  public partial class ProductInStockDaoV
  {
    #region Get
    #region sync
    public ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(long? productId, params OrderProductInStock[] orderBy)
    {
      return ProductInStockHardCodedGets(new WhereClause(), false, productId, null, null, orderBy);
    }
    public ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      return ProductInStockHardCodedGets(new WhereClause(), false, productId, pageNum, pageSize, orderBy);
    }
    public ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(WhereClause whereClause, bool distinct, long? productId, params OrderProductInStock[] orderBy)
    {
      return ProductInStockHardCodedGets(whereClause, distinct, productId, null, null, orderBy);
    }
    public ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = ProductInStockHardCodedGets(con, cmd, whereClause, distinct, productId, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(SqlConnection con, SqlCommand cmd, long? productId)
    {
      return ProductInStockHardCodedGets(con, cmd, new WhereClause(), false, productId, null, null);
    }
    public ICollection<IProductInStockDtoV> ProductInStockHardCodedGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      ICollection<IProductInStockDtoV> dtos = new List<IProductInStockDtoV>();
      try
      {
        GetHardCodedPrepareCommand(productId, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(ProductInStockDaoV)}.{nameof(ProductInStockGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetHardCodedPrepareCommand(long? productId, SqlCommand cmd, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductInStock[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      cmd.Parameters.Add("@productId", SqlDbType.BigInt).Value = productId != null ? productId : DBNull.Value;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetHardCodedSqlStatement(productId, where, distinct, pageNum, pageSize, orderBy);
    }
    private void GetHardCodedPrepareCommand(long? productId, SqlCommand cmd, WhereClause whereClause, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductInStock[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      foreach (IWhereParameter whereParameter in whereClause.Parameters)
      {
        cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
      }
      cmd.Parameters.Add("@productId", SqlDbType.BigInt).Value = productId != null ? productId : DBNull.Value;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetHardCodedSqlStatement(productId, whereClause.Where, distinct, pageNum, pageSize, orderBy);
    }
    private string GetHardCodedSqlStatement(long? productId, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductInStock[] orderBy)
    {
      string sql;
      sql = @$"
              SELECT {(distinct ? "DISTINCT " : "")}
                     pv.[Id]
                    ,pv.[ProductName]
                    ,pv.[Price]
                    ,pv.[Quantity]
                FROM [core].[ProductInStock]({productId}) pv
      ";
      sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    #endregion
  }
}


