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
  public partial class ProductDao
  {
    #region Get
    #region async
    #endregion
    #region sync
    public ICollection<IProductDto> ProductWithoutModInfoHardCodedGets(List<long> ids)
    {
      ICollection<IProductDto> dtos = new List<IProductDto>();

      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        con.Open();
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.Parameters.Clear();
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = $@"
        SELECT pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[ProductName]
              ,pt.[Price]
          FROM [core].[Product] AS pt
         WHERE pt.[Id] IN ({string.Join(", ", ids)})
";
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              dtos.Add(ProductWithoutModInfoGetRead(reader));
            }
            reader.Close();
          }
        }
        con.Close();
      }
      return dtos;
    }
    public ICollection<IProductDto> ProductWithoutModInfoGets(List<long> ids)
    {
      ICollection<IProductDto> dtos = new List<IProductDto>();

      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        con.Open();
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.Parameters.Clear();
          cmd.Parameters.Add(GetCustomTypeSqlParameter("@productIds", "core.BigintArray", ids.Cast<object>().ToArray(), typeof(long)));

          cmd.CommandType = CommandType.Text;
          cmd.CommandText = $@"
        SELECT pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[ProductName]
              ,pt.[Price]
          FROM [core].[Product] AS pt
         WHERE pt.[Id] IN (@productIds)
";
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              dtos.Add(ProductWithoutModInfoGetRead(reader));
            }
            reader.Close();
          }
        }
        con.Close();
      }
      return dtos;
    }
    public ICollection<IProductDto> ProductWithoutModInfoGets(params OrderProduct[] orderBy)
    {
      return ProductWithoutModInfoGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IProductDto> ProductWithoutModInfoGets(int? pageNum, int? pageSize, params OrderProduct[] orderBy)
    {
      return ProductWithoutModInfoGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IProductDto> ProductWithoutModInfoGets(WhereClause whereClause, bool distinct, params OrderProduct[] orderBy)
    {
      return ProductWithoutModInfoGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IProductDto> ProductWithoutModInfoGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = ProductWithoutModInfoGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IProductDto> ProductWithoutModInfoGets(SqlConnection con, SqlCommand cmd)
    {
      return ProductWithoutModInfoGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IProductDto> ProductWithoutModInfoGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderProduct[] orderBy)
    {
      ICollection<IProductDto> dtos = new List<IProductDto>();
      try
      {
        ProductWithoutModInfoGetPrepareCommand(cmd, whereClause,  null, distinct, pageNum, pageSize, orderBy);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            dtos.Add(ProductWithoutModInfoGetRead(reader));
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(ProductDao)}.{nameof(ProductWithoutModInfoGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void ProductWithoutModInfoGetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProduct[] orderBy)
    {
      cmd.Parameters.Clear();
      if (id != null)
        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = ProductWithoutModInfoGetSqlStatement(id, where, distinct, pageNum, pageSize, orderBy);
    }
    private void ProductWithoutModInfoGetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProduct[] orderBy)
    {
      cmd.Parameters.Clear();
      if (id != null)
        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
      if (pageNum != null && pageSize != null && orderBy?.Length > 0)
      {
        cmd.Parameters.Add("@pageNum", SqlDbType.Int).Value = pageNum;
        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
      }
      foreach (IWhereParameter whereParameter in whereClause.Parameters)
      {
        cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
      }
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = ProductWithoutModInfoGetSqlStatement(id, whereClause.Where, distinct, pageNum, pageSize, orderBy);
    }
    private string ProductWithoutModInfoGetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderProduct[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}
               pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[ProductName]
              ,pt.[Price]
          FROM [core].[Product] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += ProductWithoutModInfoGetOrderBy(orderBy);
      sql += ProductWithoutModInfoGetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string ProductWithoutModInfoGetOrderBy(params OrderProduct[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderProduct order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderProduct), order);
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
    private string ProductWithoutModInfoGetPagination(int? pageNum = null, int? pageSize = null, params OrderProduct[] orderBy)
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
    private IProductDto ProductWithoutModInfoGetRead(SqlDataReader reader)
    {
      IProductDto dto = new ProductDto();
      dto.Id = reader.GetInt64(0);
      dto.ModifiedDate = reader.GetDateTime(1);
      dto.ModifiedUser = reader.GetInt64(2);
      dto.ProductName = reader.GetString(3);
      dto.Price = reader.GetDouble(4);
      return dto;
    }
    #endregion

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

  }
}


