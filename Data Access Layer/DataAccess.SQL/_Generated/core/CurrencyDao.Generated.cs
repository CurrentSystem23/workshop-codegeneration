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
  public partial class CurrencyDao : Dao, ICurrencyDao, ICurrencyInternalDao
  {
    private readonly ILogger<CurrencyDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  CurrencyDao(IServiceProvider provider, ILogger<CurrencyDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> CurrencyGetCountAsync()
    {
      return await CurrencyGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> CurrencyGetCountAsync(WhereClause whereClause)
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
            FROM [core].[Currency] pv
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
    public async Task<ICurrencyDto> CurrencyGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CurrencyGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICurrencyDto> CurrencyGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICurrencyDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(params OrderCurrency[] orderBy)
    {
      return await CurrencyGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      return await CurrencyGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(WhereClause whereClause, bool distinct, params OrderCurrency[] orderBy)
    {
      return await CurrencyGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CurrencyGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await CurrencyGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<ICurrencyDto>> CurrencyGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      ICollection<ICurrencyDto> dtos = new List<ICurrencyDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long CurrencyGetCount()
    {
      return CurrencyGetCount(new WhereClause());
    }
    public long CurrencyGetCount(WhereClause whereClause)
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
            FROM [core].[Currency] pv
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
    public ICurrencyDto CurrencyGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = CurrencyGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICurrencyDto CurrencyGet(SqlConnection con, SqlCommand cmd, long id)
    {
      ICurrencyDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<ICurrencyDto> CurrencyGets(params OrderCurrency[] orderBy)
    {
      return CurrencyGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<ICurrencyDto> CurrencyGets(int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      return CurrencyGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<ICurrencyDto> CurrencyGets(WhereClause whereClause, bool distinct, params OrderCurrency[] orderBy)
    {
      return CurrencyGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<ICurrencyDto> CurrencyGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = CurrencyGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<ICurrencyDto> CurrencyGets(SqlConnection con, SqlCommand cmd)
    {
      return CurrencyGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<ICurrencyDto> CurrencyGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCurrency[] orderBy)
    {
      ICollection<ICurrencyDto> dtos = new List<ICurrencyDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderCurrency[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderCurrency[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderCurrency[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[Iso]
              ,pt.[Currency]
              ,pt.[CurrencyParts]
              ,pt.[Region]
          FROM [core].[Currency] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderCurrency[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderCurrency order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderCurrency), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderCurrency[] orderBy)
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
    private ICurrencyDto GetRead(SqlDataReader reader)
    {
      ICurrencyDto dto = new CurrencyDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.Iso = reader.GetString(4);
      dto.Currency = reader.GetString(5);
      dto.CurrencyParts = reader.GetString(6);
      dto.Region = reader.GetString(7);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<ICurrencyHistDto>> CurrencyHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CurrencyHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<ICurrencyHistDto>> CurrencyHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<ICurrencyHistDto> dtos = new List<ICurrencyHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<ICurrencyHistDto> CurrencyHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CurrencyHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICurrencyHistDto> CurrencyHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      ICurrencyHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<ICurrencyHistDto> CurrencyHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = CurrencyHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<ICurrencyHistDto> CurrencyHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<ICurrencyHistDto> dtos = new List<ICurrencyHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistGets)}");
        throw;
      }
      return dtos;
    }
    public ICurrencyHistDto CurrencyHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = CurrencyHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public ICurrencyHistDto CurrencyHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      ICurrencyHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistEntryGet)}");
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
              ,[Iso]
              ,[Currency]
              ,[CurrencyParts]
              ,[Region]
          FROM [core].[Currency_Hist]
        WHERE [Id] = @id";
    }
    private ICurrencyHistDto GetHistRead(SqlDataReader reader)
    {
      ICurrencyHistDto dto = new CurrencyHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.Iso = reader.GetString(6);
      dto.Currency = reader.GetString(7);
      dto.CurrencyParts = reader.GetString(8);
      dto.Region = reader.GetString(9);
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
              ,[Iso]
              ,[Currency]
              ,[CurrencyParts]
              ,[Region]
          FROM [core].[Currency_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task CurrencyHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CurrencyHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CurrencyHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CurrencyHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CurrencyHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistDeleteAsync)}");
        throw;
      }
    }
    public async Task CurrencyHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void CurrencyHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          CurrencyHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void CurrencyHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          CurrencyHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void CurrencyHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistDelete)}");
        throw;
      }
    }
    public void CurrencyHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyHistDelete)}");
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
              DELETE FROM [core].[Currency_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[Currency_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task CurrencySaveAsync(ICurrencyDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CurrencySaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CurrencySaveAsync(SqlConnection con, SqlCommand cmd, ICurrencyDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencySaveAsync)}");
        throw;
      }
    }
    public async Task CurrencyMergeAsync(ICurrencyDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CurrencyMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CurrencyMergeAsync(SqlConnection con, SqlCommand cmd, ICurrencyDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void CurrencySave(ICurrencyDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CurrencySave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void CurrencySave(SqlConnection con, SqlCommand cmd, ICurrencyDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencySave)}");
        throw;
      }
    }
    public void CurrencyMerge(ICurrencyDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CurrencyMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void CurrencyMerge(SqlConnection con, SqlCommand cmd, ICurrencyDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, ICurrencyDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@Iso", SqlDbType.NVarChar).Value =  dto.Iso ?? string.Empty;
      cmd.Parameters.Add("@Currency", SqlDbType.NVarChar).Value =  dto.Currency ?? string.Empty;
      cmd.Parameters.Add("@CurrencyParts", SqlDbType.NVarChar).Value =  dto.CurrencyParts ?? string.Empty;
      cmd.Parameters.Add("@Region", SqlDbType.NVarChar).Value =  dto.Region ?? string.Empty;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[Currency] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[Iso]
                   ,[Currency]
                   ,[CurrencyParts]
                   ,[Region]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@Iso
                   ,@Currency
                   ,@CurrencyParts
                   ,@Region
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[Currency]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[Iso] = @Iso
                   ,[Currency] = @Currency
                   ,[CurrencyParts] = @CurrencyParts
                   ,[Region] = @Region
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Currency] ON;
          MERGE INTO [core].[Currency] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @Iso, @Currency, @CurrencyParts, @Region)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Iso],[Currency],[CurrencyParts],[Region])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Iso]
                  ,[Currency]
                  ,[CurrencyParts]
                  ,[Region]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Iso]
                 ,Source.[Currency]
                 ,Source.[CurrencyParts]
                 ,Source.[Region]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Iso] = Source.[Iso]
                ,[Currency] = Source.[Currency]
                ,[CurrencyParts] = Source.[CurrencyParts]
                ,[Region] = Source.[Region]
          ;
          SET IDENTITY_INSERT [core].[Currency] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task CurrencyDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CurrencyDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CurrencyDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CurrencyDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CurrencyDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyDeleteAsync)}");
        throw;
      }
    }
    public async Task CurrencyDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void CurrencyDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CurrencyDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void CurrencyDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CurrencyDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void CurrencyDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyDelete)}");
        throw;
      }
    }
    public void CurrencyDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CurrencyDao)}.{nameof(CurrencyDelete)}");
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
              DELETE FROM [core].[Currency]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[Currency] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task CurrencyBulkInsertAsync(ICollection<ICurrencyDto> dtos)
    {
      await CurrencyBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task CurrencyBulkInsertAsync(ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      await CurrencyBulkInsertAsync("[core].[Currency]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task Currency_TempBulkInsertAsync(ICollection<ICurrencyDto> dtos)
    {
      await Currency_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task Currency_TempBulkInsertAsync(ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      await CurrencyBulkInsertAsync("[core].[Currency_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task CurrencyBulkMergeAsync(ICollection<ICurrencyDto> dtos)
    {
      await CurrencyBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task CurrencyBulkMergeAsync(ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      await CurrencyCreateTempTableAsync().ConfigureAwait(false);
      await Currency_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await CurrencyMergeFromTempAsync().ConfigureAwait(false);
      await CurrencyDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task CurrencyBulkUpdateAsync(ICollection<ICurrencyDto> dtos)
    {
      await CurrencyCreateTempTableAsync().ConfigureAwait(false);
      await Currency_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await CurrencyUpdateFromTempAsync().ConfigureAwait(false);
      await CurrencyDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task CurrencyBulkDeleteAsync(ICollection<ICurrencyDto> dtos)
    {
      await CurrencyCreateTempTableAsync().ConfigureAwait(false);
      await Currency_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await CurrencyDeleteFromTempAsync().ConfigureAwait(false);
      await CurrencyDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task CurrencyBulkInsertAsync(string tableName, ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(CurrencyGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task CurrencyMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task CurrencyUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task CurrencyDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task CurrencyCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task CurrencyDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void CurrencyBulkInsert(ICollection<ICurrencyDto> dtos)
    {
      CurrencyBulkInsert(dtos, false);
    }
    public void CurrencyBulkInsert(ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      CurrencyBulkInsert("[core].[Currency]", dtos, identityInsert);
    }
    public void Currency_TempBulkInsert(ICollection<ICurrencyDto> dtos)
    {
      Currency_TempBulkInsert(dtos, false);
    }
    public void Currency_TempBulkInsert(ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      CurrencyBulkInsert("[core].[Currency_Temp]", dtos, identityInsert);
    }
    public void CurrencyBulkMerge(ICollection<ICurrencyDto> dtos)
    {
      CurrencyBulkMerge(dtos, false);
    }
    public void CurrencyBulkMerge(ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      CurrencyCreateTempTable();
      Currency_TempBulkInsert(dtos, identityInsert);
      CurrencyMergeFromTemp();
      CurrencyDropTempTable();
    }
    public void CurrencyBulkUpdate(ICollection<ICurrencyDto> dtos)
    {
      CurrencyCreateTempTable();
      Currency_TempBulkInsert(dtos, true);
      CurrencyUpdateFromTemp();
      CurrencyDropTempTable();
    }
    public void CurrencyBulkDelete(ICollection<ICurrencyDto> dtos)
    {
      CurrencyCreateTempTable();
      Currency_TempBulkInsert(dtos, true);
      CurrencyDeleteFromTemp();
      CurrencyDropTempTable();
    }
    private void CurrencyBulkInsert(string tableName, ICollection<ICurrencyDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(CurrencyGetListAsDataTable(tableName, dtos));
        };
    }
    private void CurrencyMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void CurrencyUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void CurrencyDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void CurrencyCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void CurrencyDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCurrencyDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetCurrencyMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Currency] ON;
          MERGE INTO [core].[Currency] AS Target
          USING [core].[Currency_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Iso]
                  ,[Currency]
                  ,[CurrencyParts]
                  ,[Region]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Iso]
                 ,Source.[Currency]
                 ,Source.[CurrencyParts]
                 ,Source.[Region]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Iso] = Source.[Iso]
                ,[Currency] = Source.[Currency]
                ,[CurrencyParts] = Source.[CurrencyParts]
                ,[Region] = Source.[Region]
          ;
          SET IDENTITY_INSERT [core].[Currency] OFF;
      ";
    }
    private string GetCurrencyUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[Iso] = Source.[Iso]
                ,Target.[Currency] = Source.[Currency]
                ,Target.[CurrencyParts] = Source.[CurrencyParts]
                ,Target.[Region] = Source.[Region]
          FROM [core].[Currency] AS Target
          INNER JOIN [core].[Currency_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetCurrencyDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[Currency] AS Target
          INNER JOIN [core].[Currency_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetCurrencyCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[Currency_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[Currency_Temp];
        
                  CREATE TABLE [core].[Currency_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkCurrency_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[Iso]   nvarchar(3)   NULL
                     ,[Currency]   nvarchar(200)   NULL
                     ,[CurrencyParts]   nvarchar(200)   NULL
                     ,[Region]   nvarchar(200)   NULL
                  );
      ";
    }
    private string GetCurrencyDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[Currency_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[Currency_Temp];
                ";
    }
    private DataTable CurrencyGetListAsDataTable(string tableName, ICollection<ICurrencyDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcIso = new DataColumn("Iso", typeof(string));
      DataColumn dtcCurrency = new DataColumn("Currency", typeof(string));
      DataColumn dtcCurrencyParts = new DataColumn("CurrencyParts", typeof(string));
      DataColumn dtcRegion = new DataColumn("Region", typeof(string));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcIso.AllowDBNull = false;
      dtcCurrency.AllowDBNull = false;
      dtcCurrencyParts.AllowDBNull = false;
      dtcRegion.AllowDBNull = false;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcIso);
      table.Columns.Add(dtcCurrency);
      table.Columns.Add(dtcCurrencyParts);
      table.Columns.Add(dtcRegion);
      
      foreach (CurrencyDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.Iso
          ,row.Currency
          ,row.CurrencyParts
          ,row.Region
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> CurrencyHasChangedAsync(ICurrencyDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CurrencyHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> CurrencyHasChangedAsync(SqlConnection con, SqlCommand cmd, ICurrencyDto dto)
    {
      if (dto.Id <= 0)
        return true;
      ICurrencyDto dtoDb = await CurrencyGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool CurrencyHasChanged(ICurrencyDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = CurrencyHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool CurrencyHasChanged(SqlConnection con, SqlCommand cmd, ICurrencyDto dto)
    {
      if (dto.Id <= 0)
        return true;
      ICurrencyDto dtoDb = CurrencyGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(ICurrencyDto dto, ICurrencyDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.Iso == dtoDb.Iso;
      ret = ret && dto.Currency == dtoDb.Currency;
      ret = ret && dto.CurrencyParts == dtoDb.CurrencyParts;
      ret = ret && dto.Region == dtoDb.Region;
      return !ret;
    }
    #endregion
  }
}


