using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
  public partial class ProductInStockDaoV : Dao, IProductInStockDaoV, IProductInStockInternalDaoV
  {
    private readonly ILogger<ProductInStockDaoV> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  ProductInStockDaoV(IServiceProvider provider, ILogger<ProductInStockDaoV> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> ProductInStockGetCountAsync(long? productId)
    {
      return await ProductInStockGetCountAsync(new WhereClause(), productId).ConfigureAwait(false);
    }
    public async Task<long> ProductInStockGetCountAsync(WhereClause whereClause, long? productId)
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
          cmd.Parameters.Add("@productId", SqlDbType.BigInt).Value = productId != null ? productId : DBNull.Value;
          cmd.CommandType = CommandType.Text;
          string sql = $@"
            SELECT COUNT_BIG(*)
            FROM [core].[ProductInStock](@productId) pv
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
    public async Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(long? productId, params OrderProductInStock[] orderBy)
    {
      return await ProductInStockGetsAsync(new WhereClause(), false, productId, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      return await ProductInStockGetsAsync(new WhereClause(), false, productId, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(WhereClause whereClause, bool distinct, long? productId, params OrderProductInStock[] orderBy)
    {
      return await ProductInStockGetsAsync(whereClause, distinct, productId, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await ProductInStockGetsAsync(con, cmd, whereClause, distinct, productId, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(SqlConnection con, SqlCommand cmd, long? productId)
    {
      return await ProductInStockGetsAsync(con, cmd, new WhereClause(), false, productId, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductInStockDtoV>> ProductInStockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      ICollection<IProductInStockDtoV> dtos = new List<IProductInStockDtoV>();
      try
      {
        GetPrepareCommand(productId, cmd, whereClause,  distinct, pageNum, pageSize, orderBy);
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(ProductInStockDaoV)}.{nameof(ProductInStockGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long ProductInStockGetCount(long? productId)
    {
      return ProductInStockGetCount(new WhereClause(), productId);
    }
    public long ProductInStockGetCount(WhereClause whereClause, long? productId)
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
          cmd.Parameters.Add("@productId", SqlDbType.BigInt).Value = productId != null ? productId : DBNull.Value;
          cmd.CommandType = CommandType.Text;
          string sql = $@"
            SELECT COUNT_BIG(*)
            FROM [core].[ProductInStock](@productId) pv
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
    public ICollection<IProductInStockDtoV> ProductInStockGets(long? productId, params OrderProductInStock[] orderBy)
    {
      return ProductInStockGets(new WhereClause(), false, productId, null, null, orderBy);
    }
    public ICollection<IProductInStockDtoV> ProductInStockGets(long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      return ProductInStockGets(new WhereClause(), false, productId, pageNum, pageSize, orderBy);
    }
    public ICollection<IProductInStockDtoV> ProductInStockGets(WhereClause whereClause, bool distinct, long? productId, params OrderProductInStock[] orderBy)
    {
      return ProductInStockGets(whereClause, distinct, productId, null, null, orderBy);
    }
    public ICollection<IProductInStockDtoV> ProductInStockGets(WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = ProductInStockGets(con, cmd, whereClause, distinct, productId, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IProductInStockDtoV> ProductInStockGets(SqlConnection con, SqlCommand cmd, long? productId)
    {
      return ProductInStockGets(con, cmd, new WhereClause(), false, productId, null, null);
    }
    public ICollection<IProductInStockDtoV> ProductInStockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, long? productId, int? pageNum, int? pageSize, params OrderProductInStock[] orderBy)
    {
      ICollection<IProductInStockDtoV> dtos = new List<IProductInStockDtoV>();
      try
      {
        GetPrepareCommand(productId, cmd, whereClause,  distinct, pageNum, pageSize, orderBy);
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
    private void GetPrepareCommand(long? productId, SqlCommand cmd, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductInStock[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      cmd.Parameters.Add("@productId", SqlDbType.BigInt).Value = productId != null ? productId : DBNull.Value;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetSqlStatement(productId, where, distinct, pageNum, pageSize, orderBy);
    }
    private void GetPrepareCommand(long? productId, SqlCommand cmd, WhereClause whereClause, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductInStock[] orderBy)
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
      cmd.CommandText = GetSqlStatement(productId, whereClause.Where, distinct, pageNum, pageSize, orderBy);
    }
    private string GetSqlStatement(long? productId, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductInStock[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}
               pv.[Id]
              ,pv.[ProductName]
              ,pv.[Price]
              ,pv.[Quantity]
          FROM [core].[ProductInStock](@productId) pv
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
    private string GetOrderBy(params OrderProductInStock[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderProductInStock order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderProductInStock), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderProductInStock[] orderBy)
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
    private IProductInStockDtoV GetRead(SqlDataReader reader)
    {
      IProductInStockDtoV dto = new ProductInStockDtoV();
      dto.Id = reader.GetInt64(0);
      dto.ProductName = reader.GetString(1);
      dto.Price = reader.GetDouble(2);
      dto.Quantity = reader.GetInt64(3);
      return dto;
    }
    #endregion
  }
}


