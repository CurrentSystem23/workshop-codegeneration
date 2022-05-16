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
  public partial class SpecialProductsDaoV : Dao, ISpecialProductsDaoV, ISpecialProductsInternalDaoV
  {
    private readonly ILogger<SpecialProductsDaoV> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  SpecialProductsDaoV(IServiceProvider provider, ILogger<SpecialProductsDaoV> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> SpecialProductsGetCountAsync(long[] productIds)
    {
      return await SpecialProductsGetCountAsync(new WhereClause(), productIds).ConfigureAwait(false);
    }
    public async Task<long> SpecialProductsGetCountAsync(WhereClause whereClause, long[] productIds)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.Parameters.Clear();
          foreach (IWhereParameter whereParameter in whereClause.Parameters)
          {
            cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
          }
          cmd.Parameters.Add(GetCustomTypeSqlParameter("@productIds", "core.BigintArray", productIds.Cast<object>().ToArray(), typeof(long)));
          cmd.CommandType = CommandType.Text;
          string sql = $@"
            SELECT COUNT_BIG(*)
            FROM [core].[SpecialProducts](@productIds) pv
          ";
          sql += whereClause.Where;
          cmd.CommandText = sql;
          
          await con.OpenAsync().ConfigureAwait(false);
          var ret = (long)(await cmd.ExecuteScalarAsync().ConfigureAwait(false));
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      return await SpecialProductsGetsAsync(new WhereClause(), false, productIds, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      return await SpecialProductsGetsAsync(new WhereClause(), false, productIds, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(WhereClause whereClause, bool distinct, long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      return await SpecialProductsGetsAsync(whereClause, distinct, productIds, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await SpecialProductsGetsAsync(con, cmd, whereClause, distinct, productIds, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(SqlConnection con, SqlCommand cmd, long[] productIds)
    {
      return await SpecialProductsGetsAsync(con, cmd, new WhereClause(), false, productIds, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<ISpecialProductsDtoV>> SpecialProductsGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      ICollection<ISpecialProductsDtoV> dtos = new List<ISpecialProductsDtoV>();
      try
      {
        GetPrepareCommand(productIds, cmd, whereClause,  distinct, pageNum, pageSize, orderBy);
        using (SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
        {
          while (await reader.ReadAsync().ConfigureAwait(false))
          {
            dtos.Add(GetRead(reader));
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(SpecialProductsDaoV)}.{nameof(SpecialProductsGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long SpecialProductsGetCount(long[] productIds)
    {
      return SpecialProductsGetCount(new WhereClause(), productIds);
    }
    public long SpecialProductsGetCount(WhereClause whereClause, long[] productIds)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.Parameters.Clear();
          foreach (IWhereParameter whereParameter in whereClause.Parameters)
          {
            cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
          }
          cmd.Parameters.Add(GetCustomTypeSqlParameter("@productIds", "core.BigintArray", productIds.Cast<object>().ToArray(), typeof(long)));
          cmd.CommandType = CommandType.Text;
          string sql = $@"
            SELECT COUNT_BIG(*)
            FROM [core].[SpecialProducts](@productIds) pv
          ";
          sql += whereClause.Where;
          cmd.CommandText = sql;
          
          con.Open();
          var ret = (long)(cmd.ExecuteScalar());
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsGets(long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      return SpecialProductsGets(new WhereClause(), false, productIds, null, null, orderBy);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsGets(long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      return SpecialProductsGets(new WhereClause(), false, productIds, pageNum, pageSize, orderBy);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsGets(WhereClause whereClause, bool distinct, long[] productIds, params OrderSpecialProducts[] orderBy)
    {
      return SpecialProductsGets(whereClause, distinct, productIds, null, null, orderBy);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsGets(WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = SpecialProductsGets(con, cmd, whereClause, distinct, productIds, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsGets(SqlConnection con, SqlCommand cmd, long[] productIds)
    {
      return SpecialProductsGets(con, cmd, new WhereClause(), false, productIds, null, null);
    }
    public ICollection<ISpecialProductsDtoV> SpecialProductsGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long[] productIds, int? pageNum, int? pageSize, params OrderSpecialProducts[] orderBy)
    {
      ICollection<ISpecialProductsDtoV> dtos = new List<ISpecialProductsDtoV>();
      try
      {
        GetPrepareCommand(productIds, cmd, whereClause,  distinct, pageNum, pageSize, orderBy);
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(SpecialProductsDaoV)}.{nameof(SpecialProductsGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(long[] productIds, SqlCommand cmd, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderSpecialProducts[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      cmd.Parameters.Add(GetCustomTypeSqlParameter("@productIds", "core.BigintArray", productIds.Cast<object>().ToArray(), typeof(long)));
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetSqlStatement(productIds, where, distinct, pageNum, pageSize, orderBy);
    }
    private void GetPrepareCommand(long[] productIds, SqlCommand cmd, WhereClause whereClause, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderSpecialProducts[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      foreach (IWhereParameter whereParameter in whereClause.Parameters)
      {
        cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
      }
      cmd.Parameters.Add(GetCustomTypeSqlParameter("@productIds", "core.BigintArray", productIds.Cast<object>().ToArray(), typeof(long)));
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetSqlStatement(productIds, whereClause.Where, distinct, pageNum, pageSize, orderBy);
    }
    private string GetSqlStatement(long[] productIds, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderSpecialProducts[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}
               pv.[Id]
              ,pv.[ProductName]
              ,pv.[Price]
          FROM [core].[SpecialProducts](@productIds) pv
      ";
      sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private SqlParameter GetCustomTypeSqlParameter(string parameterName, string typeName, object[] value, Type type)
    {
      SqlParameter param = new SqlParameter();
      param.ParameterName = parameterName;
      param.SqlDbType = SqlDbType.Structured;
      param.TypeName = typeName;
      
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("val", type);
      if (value != null && value.Length > 0)
      {
        foreach (var item in value)
        {
          dataTable.Rows.Add(item);
        }
      }
      param.Value = dataTable;
      return param;
    }
    private string GetOrderBy(params OrderSpecialProducts[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderSpecialProducts order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderSpecialProducts), order);
        string[] orderArray = orderName.Split('_');
        if (orderArray.Length == 2)
        {
          if (first)
          {
            result = $" ORDER BY {orderArray[0]} {orderArray[1]}";
            first = false;
          }
          else
          {
            result += $", {orderArray[0]} {orderArray[1]}";
          }
        }
      }
      return result;
    }
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderSpecialProducts[] orderBy)
    {
      string result = string.Empty;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        result = @"
          OFFSET (@pageNum - 1) * @pageSize ROWS
        FETCH NEXT @pageSize ROWS ONLY;";
      }
      return result;
    }
    private ISpecialProductsDtoV GetRead(SqlDataReader reader)
    {
      ISpecialProductsDtoV dto = new SpecialProductsDtoV();
      dto.Id = reader.GetInt64(0);
      dto.ProductName = reader.GetString(1);
      dto.Price = reader.GetDouble(2);
      return dto;
    }
    #endregion
  }
}


