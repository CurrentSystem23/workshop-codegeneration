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
  public partial class StockDao : Dao, IStockDao, IStockInternalDao
  {
    private readonly ILogger<StockDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  StockDao(IServiceProvider provider, ILogger<StockDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> StockGetCountAsync()
    {
      return await StockGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> StockGetCountAsync(WhereClause whereClause)
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
            FROM [core].[Stock] pv
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
    public async Task<IStockDto> StockGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await StockGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IStockDto> StockGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      IStockDto dto = null;
      try
      {
        GetPrepareCommand(cmd, id);
        using (SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
        {
          while (await reader.ReadAsync().ConfigureAwait(false))
          {
            dto = GetRead(reader);
            break;
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<IStockDto>> StockGetsAsync(params OrderStock[] orderBy)
    {
      return await StockGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IStockDto>> StockGetsAsync(int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      return await StockGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IStockDto>> StockGetsAsync(WhereClause whereClause, bool distinct, params OrderStock[] orderBy)
    {
      return await StockGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IStockDto>> StockGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await StockGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IStockDto>> StockGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await StockGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IStockDto>> StockGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      ICollection<IStockDto> dtos = new List<IStockDto>();
      try
      {
        GetPrepareCommand(cmd, whereClause,  null, distinct, pageNum, pageSize, orderBy);
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long StockGetCount()
    {
      return StockGetCount(new WhereClause());
    }
    public long StockGetCount(WhereClause whereClause)
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
            FROM [core].[Stock] pv
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
    public IStockDto StockGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = StockGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public IStockDto StockGet(SqlConnection con, SqlCommand cmd, long id)
    {
      IStockDto dto = null;
      try
      {
        GetPrepareCommand(cmd, id);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            dto = GetRead(reader);
            break;
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<IStockDto> StockGets(params OrderStock[] orderBy)
    {
      return StockGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IStockDto> StockGets(int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      return StockGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IStockDto> StockGets(WhereClause whereClause, bool distinct, params OrderStock[] orderBy)
    {
      return StockGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IStockDto> StockGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = StockGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IStockDto> StockGets(SqlConnection con, SqlCommand cmd)
    {
      return StockGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IStockDto> StockGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderStock[] orderBy)
    {
      ICollection<IStockDto> dtos = new List<IStockDto>();
      try
      {
        GetPrepareCommand(cmd, whereClause,  null, distinct, pageNum, pageSize, orderBy);
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderStock[] orderBy)
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
      cmd.CommandText = GetSqlStatement(id, where, distinct, pageNum, pageSize, orderBy);
    }
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderStock[] orderBy)
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
      cmd.CommandText = GetSqlStatement(id, whereClause.Where, distinct, pageNum, pageSize, orderBy);
    }
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderStock[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[ProductId]
              ,pt.[Quantity]
          FROM [core].[Stock] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderStock[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderStock order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderStock), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderStock[] orderBy)
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
    private IStockDto GetRead(SqlDataReader reader)
    {
      IStockDto dto = new StockDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.ProductId = reader.GetInt64(4);
      dto.Quantity = reader.GetInt64(5);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<IStockHistDto>> StockHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await StockHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IStockHistDto>> StockHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IStockHistDto> dtos = new List<IStockHistDto>();
      try
      {
        GetHistPrepareCommand(cmd, id);
        using (SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
        {
          while (await reader.ReadAsync().ConfigureAwait(false))
          {
            dtos.Add(GetHistRead(reader));
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<IStockHistDto> StockHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await StockHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IStockHistDto> StockHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      IStockHistDto dto = null;
      try
      {
        GetHistEntryPrepareCommand(cmd, histId);
        using (SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
        {
          while (await reader.ReadAsync().ConfigureAwait(false))
          {
            dto = GetHistRead(reader);
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<IStockHistDto> StockHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = StockHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IStockHistDto> StockHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IStockHistDto> dtos = new List<IStockHistDto>();
      try
      {
        GetHistPrepareCommand(cmd, id);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            dtos.Add(GetHistRead(reader));
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistGets)}");
        throw;
      }
      return dtos;
    }
    public IStockHistDto StockHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = StockHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public IStockHistDto StockHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      IStockHistDto dto = null;
      try
      {
        GetHistEntryPrepareCommand(cmd, histId);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            dto = GetHistRead(reader);
          }
          reader.Close();
        }
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistEntryGet)}");
        throw;
      }
      return dto;
    }
    #endregion
    private void GetHistPrepareCommand(SqlCommand cmd, long id)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = GetHistSqlStatement();
    }
    private string GetHistSqlStatement()
    {
      return  @"
        SELECT [core].[GetInsertUpdateDeleteInformation] ([ModifiedUser], [ModifiedDate])
              ,[Hist_Id]
              ,[Hist_Action]
              ,[Id]
              ,[ModifiedDate]
              ,[ModifiedUser]
              ,[ProductId]
              ,[Quantity]
          FROM [core].[Stock_Hist]
        WHERE [Id] = @id";
    }
    private IStockHistDto GetHistRead(SqlDataReader reader)
    {
      IStockHistDto dto = new StockHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.ProductId = reader.GetInt64(6);
      dto.Quantity = reader.GetInt64(7);
      return dto;
    }
    private void GetHistEntryPrepareCommand(SqlCommand cmd, long histId)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@histId", SqlDbType.BigInt).Value = histId;
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = GetHistEntrySqlStatement();
    }
    private string GetHistEntrySqlStatement()
    {
      return  @"
        SELECT [core].[GetInsertUpdateDeleteInformation] ([ModifiedUser], [ModifiedDate])
              ,[Hist_Id]
              ,[Hist_Action]
              ,[Id]
              ,[ModifiedDate]
              ,[ModifiedUser]
              ,[ProductId]
              ,[Quantity]
          FROM [core].[Stock_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task StockHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await StockHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task StockHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await StockHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task StockHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistDeleteAsync)}");
        throw;
      }
    }
    public async Task StockHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void StockHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          StockHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void StockHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          StockHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void StockHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistDelete)}");
        throw;
      }
    }
    public void StockHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockHistDelete)}");
        throw;
      }
    }
    #endregion
    private void HistDeletePrepareCommand(SqlCommand cmd, long histId)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Hist_Id", SqlDbType.BigInt).Value = histId;
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = HistDeleteSqlStatement();
    }
    private void HistDeletePrepareCommand(SqlCommand cmd, WhereClause whereClause)
    {
      cmd.Parameters.Clear();
      foreach (IWhereParameter whereParameter in whereClause.Parameters)
      {
        cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
      }
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = HistDeleteSqlStatement(whereClause.Where);
    }
    private string HistDeleteSqlStatement()
    {
      return @"
              DELETE FROM [core].[Stock_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[Stock_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task StockSaveAsync(IStockDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await StockSaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task StockSaveAsync(SqlConnection con, SqlCommand cmd, IStockDto dto)
    {
      try
      {
        if (!this.BeforeSave(con, cmd, dto))
          return;
        SavePrepareCommand(cmd, dto);
        if (dto.Id <= 0)
        {
          cmd.CommandText = SaveInsertSqlStatement();
          dto.Id = Convert.ToInt64(await cmd.ExecuteScalarAsync().ConfigureAwait(false));
        }
        else
        {
          cmd.CommandText = SaveUpdateSqlStatement();
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
        if (!this.AfterSave(con, cmd, dto))
          return;
        
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockSaveAsync)}");
        throw;
      }
    }
    public async Task StockMergeAsync(IStockDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await StockMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task StockMergeAsync(SqlConnection con, SqlCommand cmd, IStockDto dto)
    {
      try
      {
        if (!this.BeforeSave(con, cmd, dto))
          return;
        
        SavePrepareCommand(cmd, dto);
        cmd.CommandText = MergeSqlStatement();
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        
        if (!this.AfterSave(con, cmd, dto))
          return;
        
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void StockSave(IStockDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          StockSave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void StockSave(SqlConnection con, SqlCommand cmd, IStockDto dto)
    {
      try
      {
        if (!this.BeforeSave(con, cmd, dto))
          return;
        
        SavePrepareCommand(cmd, dto);
        if (dto.Id <= 0)
        {
          cmd.CommandText = SaveInsertSqlStatement();
          dto.Id = Convert.ToInt64(cmd.ExecuteScalar());
        }
        else
        {
          cmd.CommandText = SaveUpdateSqlStatement();
          cmd.ExecuteNonQuery();
        }
        if (!this.AfterSave(con, cmd, dto))
          return;
        
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockSave)}");
        throw;
      }
    }
    public void StockMerge(IStockDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          StockMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void StockMerge(SqlConnection con, SqlCommand cmd, IStockDto dto)
    {
      try
      {
        if (!this.BeforeSave(con, cmd, dto))
          return;
        
        SavePrepareCommand(cmd, dto);
        cmd.CommandText = MergeSqlStatement();
        cmd.ExecuteNonQuery();
        
        if (!this.AfterSave(con, cmd, dto))
          return;
        
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, IStockDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@ProductId", SqlDbType.BigInt).Value =  dto.ProductId;
      cmd.Parameters.Add("@Quantity", SqlDbType.BigInt).Value =  dto.Quantity;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[Stock] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[ProductId]
                   ,[Quantity]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@ProductId
                   ,@Quantity
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[Stock]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[ProductId] = @ProductId
                   ,[Quantity] = @Quantity
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Stock] ON;
          MERGE INTO [core].[Stock] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @ProductId, @Quantity)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[ProductId],[Quantity])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[ProductId]
                  ,[Quantity]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[ProductId]
                 ,Source.[Quantity]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[ProductId] = Source.[ProductId]
                ,[Quantity] = Source.[Quantity]
          ;
          SET IDENTITY_INSERT [core].[Stock] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task StockDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await StockDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task StockDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await StockDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task StockDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockDeleteAsync)}");
        throw;
      }
    }
    public async Task StockDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void StockDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          StockDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void StockDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          StockDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void StockDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockDelete)}");
        throw;
      }
    }
    public void StockDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(StockDao)}.{nameof(StockDelete)}");
        throw;
      }
    }
    #endregion
    private void DeletePrepareCommand(SqlCommand cmd, long id)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = DeleteSqlStatement();
    }
    private void DeletePrepareCommand(SqlCommand cmd, WhereClause whereClause)
    {
      cmd.Parameters.Clear();
      foreach (IWhereParameter whereParameter in whereClause.Parameters)
      {
        cmd.Parameters.Add(whereParameter.ParameterName, whereParameter.ParameterType).Value = whereParameter.ParameterValue;
      }
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = DeleteSqlStatement(whereClause.Where);
    }
    private string DeleteSqlStatement()
    {
      return @"
              DELETE FROM [core].[Stock]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[Stock] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task StockBulkInsertAsync(ICollection<IStockDto> dtos)
    {
      await StockBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task StockBulkInsertAsync(ICollection<IStockDto> dtos, bool identityInsert)
    {
      await StockBulkInsertAsync("[core].[Stock]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task Stock_TempBulkInsertAsync(ICollection<IStockDto> dtos)
    {
      await Stock_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task Stock_TempBulkInsertAsync(ICollection<IStockDto> dtos, bool identityInsert)
    {
      await StockBulkInsertAsync("[core].[Stock_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task StockBulkMergeAsync(ICollection<IStockDto> dtos)
    {
      await StockBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task StockBulkMergeAsync(ICollection<IStockDto> dtos, bool identityInsert)
    {
      await StockCreateTempTableAsync().ConfigureAwait(false);
      await Stock_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await StockMergeFromTempAsync().ConfigureAwait(false);
      await StockDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task StockBulkUpdateAsync(ICollection<IStockDto> dtos)
    {
      await StockCreateTempTableAsync().ConfigureAwait(false);
      await Stock_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await StockUpdateFromTempAsync().ConfigureAwait(false);
      await StockDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task StockBulkDeleteAsync(ICollection<IStockDto> dtos)
    {
      await StockCreateTempTableAsync().ConfigureAwait(false);
      await Stock_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await StockDeleteFromTempAsync().ConfigureAwait(false);
      await StockDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task StockBulkInsertAsync(string tableName, ICollection<IStockDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(StockGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task StockMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task StockUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task StockDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task StockCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task StockDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void StockBulkInsert(ICollection<IStockDto> dtos)
    {
      StockBulkInsert(dtos, false);
    }
    public void StockBulkInsert(ICollection<IStockDto> dtos, bool identityInsert)
    {
      StockBulkInsert("[core].[Stock]", dtos, identityInsert);
    }
    public void Stock_TempBulkInsert(ICollection<IStockDto> dtos)
    {
      Stock_TempBulkInsert(dtos, false);
    }
    public void Stock_TempBulkInsert(ICollection<IStockDto> dtos, bool identityInsert)
    {
      StockBulkInsert("[core].[Stock_Temp]", dtos, identityInsert);
    }
    public void StockBulkMerge(ICollection<IStockDto> dtos)
    {
      StockBulkMerge(dtos, false);
    }
    public void StockBulkMerge(ICollection<IStockDto> dtos, bool identityInsert)
    {
      StockCreateTempTable();
      Stock_TempBulkInsert(dtos, identityInsert);
      StockMergeFromTemp();
      StockDropTempTable();
    }
    public void StockBulkUpdate(ICollection<IStockDto> dtos)
    {
      StockCreateTempTable();
      Stock_TempBulkInsert(dtos, true);
      StockUpdateFromTemp();
      StockDropTempTable();
    }
    public void StockBulkDelete(ICollection<IStockDto> dtos)
    {
      StockCreateTempTable();
      Stock_TempBulkInsert(dtos, true);
      StockDeleteFromTemp();
      StockDropTempTable();
    }
    private void StockBulkInsert(string tableName, ICollection<IStockDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(StockGetListAsDataTable(tableName, dtos));
        };
    }
    private void StockMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void StockUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void StockDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void StockCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void StockDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetStockDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetStockMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Stock] ON;
          MERGE INTO [core].[Stock] AS Target
          USING [core].[Stock_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[ProductId]
                  ,[Quantity]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[ProductId]
                 ,Source.[Quantity]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[ProductId] = Source.[ProductId]
                ,[Quantity] = Source.[Quantity]
          ;
          SET IDENTITY_INSERT [core].[Stock] OFF;
      ";
    }
    private string GetStockUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[ProductId] = Source.[ProductId]
                ,Target.[Quantity] = Source.[Quantity]
          FROM [core].[Stock] AS Target
          INNER JOIN [core].[Stock_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetStockDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[Stock] AS Target
          INNER JOIN [core].[Stock_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetStockCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[Stock_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[Stock_Temp];
        
                  CREATE TABLE [core].[Stock_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkStock_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[ProductId]   bigint   NULL
                     ,[Quantity]   bigint   NULL
                  );
      ";
    }
    private string GetStockDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[Stock_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[Stock_Temp];
                ";
    }
    private DataTable StockGetListAsDataTable(string tableName, ICollection<IStockDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcProductId = new DataColumn("ProductId", typeof(long));
      DataColumn dtcQuantity = new DataColumn("Quantity", typeof(long));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcProductId.AllowDBNull = false;
      dtcQuantity.AllowDBNull = false;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcProductId);
      table.Columns.Add(dtcQuantity);
      
      foreach (StockDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.ProductId
          ,row.Quantity
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> StockHasChangedAsync(IStockDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await StockHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> StockHasChangedAsync(SqlConnection con, SqlCommand cmd, IStockDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IStockDto dtoDb = await StockGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool StockHasChanged(IStockDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = StockHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool StockHasChanged(SqlConnection con, SqlCommand cmd, IStockDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IStockDto dtoDb = StockGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(IStockDto dto, IStockDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.ProductId == dtoDb.ProductId;
      ret = ret && dto.Quantity == dtoDb.Quantity;
      return !ret;
    }
    #endregion
  }
}


