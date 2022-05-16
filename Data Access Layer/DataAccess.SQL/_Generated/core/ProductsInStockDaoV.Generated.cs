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
  public partial class ProductsInStockDaoV : Dao, IProductsInStockDaoV, IProductsInStockInternalDaoV
  {
    private readonly ILogger<ProductsInStockDaoV> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  ProductsInStockDaoV(IServiceProvider provider, ILogger<ProductsInStockDaoV> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> ProductsInStockGetCountAsync()
    {
      return await ProductsInStockGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> ProductsInStockGetCountAsync(WhereClause whereClause)
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
          cmd.CommandType = CommandType.Text;
          string sql = $@"
            SELECT COUNT_BIG(*)
            FROM [core].[ProductsInStock] pv
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
    public async Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(params OrderProductsInStock[] orderBy)
    {
      return await ProductsInStockGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      return await ProductsInStockGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(WhereClause whereClause, bool distinct, params OrderProductsInStock[] orderBy)
    {
      return await ProductsInStockGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await ProductsInStockGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await ProductsInStockGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IProductsInStockDtoV>> ProductsInStockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      ICollection<IProductsInStockDtoV> dtos = new List<IProductsInStockDtoV>();
      try
      {
        GetPrepareCommand(cmd, whereClause,  distinct, pageNum, pageSize, orderBy);
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(ProductsInStockDaoV)}.{nameof(ProductsInStockGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long ProductsInStockGetCount()
    {
      return ProductsInStockGetCount(new WhereClause());
    }
    public long ProductsInStockGetCount(WhereClause whereClause)
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
          cmd.CommandType = CommandType.Text;
          string sql = $@"
            SELECT COUNT_BIG(*)
            FROM [core].[ProductsInStock] pv
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
    public ICollection<IProductsInStockDtoV> ProductsInStockGets(params OrderProductsInStock[] orderBy)
    {
      return ProductsInStockGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IProductsInStockDtoV> ProductsInStockGets(int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      return ProductsInStockGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IProductsInStockDtoV> ProductsInStockGets(WhereClause whereClause, bool distinct, params OrderProductsInStock[] orderBy)
    {
      return ProductsInStockGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IProductsInStockDtoV> ProductsInStockGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = ProductsInStockGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IProductsInStockDtoV> ProductsInStockGets(SqlConnection con, SqlCommand cmd)
    {
      return ProductsInStockGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IProductsInStockDtoV> ProductsInStockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProductsInStock[] orderBy)
    {
      ICollection<IProductsInStockDtoV> dtos = new List<IProductsInStockDtoV>();
      try
      {
        GetPrepareCommand(cmd, whereClause,  distinct, pageNum, pageSize, orderBy);
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(ProductsInStockDaoV)}.{nameof(ProductsInStockGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductsInStock[] orderBy)
    {
      cmd.Parameters.Clear();
      cmd.CommandType = CommandType.Text;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandText = GetSqlStatement(where, distinct, pageNum, pageSize, orderBy);
    }
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductsInStock[] orderBy)
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
      cmd.CommandText = GetSqlStatement(whereClause.Where, distinct, pageNum, pageSize, orderBy);
    }
    private string GetSqlStatement(string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProductsInStock[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}
               pv.[Id]
              ,pv.[ProductName]
              ,pv.[Price]
              ,pv.[Quantity]
          FROM [core].[ProductsInStock] AS pv
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
    private string GetOrderBy(params OrderProductsInStock[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderProductsInStock order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderProductsInStock), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderProductsInStock[] orderBy)
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
    private IProductsInStockDtoV GetRead(SqlDataReader reader)
    {
      IProductsInStockDtoV dto = new ProductsInStockDtoV();
      dto.Id = reader.GetInt64(0);
      dto.ProductName = reader.GetString(1);
      dto.Price = reader.GetDouble(2);
      dto.Quantity = reader.GetInt64(3);
      return dto;
    }
    #endregion
  }
}


