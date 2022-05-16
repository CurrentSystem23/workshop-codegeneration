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
  public partial class CountryDao : Dao, ICountryDao, ICountryInternalDao
  {
    private readonly ILogger<CountryDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  CountryDao(IServiceProvider provider, ILogger<CountryDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> CountryGetCountAsync()
    {
      return await CountryGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> CountryGetCountAsync(WhereClause whereClause)
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
            FROM [core].[Country] pv
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
    public async Task<ICountryDto> CountryGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CountryGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICountryDto> CountryGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICountryDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<ICountryDto>> CountryGetsAsync(params OrderCountry[] orderBy)
    {
      return await CountryGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ICountryDto>> CountryGetsAsync(int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      return await CountryGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ICountryDto>> CountryGetsAsync(WhereClause whereClause, bool distinct, params OrderCountry[] orderBy)
    {
      return await CountryGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<ICountryDto>> CountryGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CountryGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<ICountryDto>> CountryGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await CountryGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<ICountryDto>> CountryGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      ICollection<ICountryDto> dtos = new List<ICountryDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long CountryGetCount()
    {
      return CountryGetCount(new WhereClause());
    }
    public long CountryGetCount(WhereClause whereClause)
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
            FROM [core].[Country] pv
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
    public ICountryDto CountryGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = CountryGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICountryDto CountryGet(SqlConnection con, SqlCommand cmd, long id)
    {
      ICountryDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<ICountryDto> CountryGets(params OrderCountry[] orderBy)
    {
      return CountryGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<ICountryDto> CountryGets(int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      return CountryGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<ICountryDto> CountryGets(WhereClause whereClause, bool distinct, params OrderCountry[] orderBy)
    {
      return CountryGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<ICountryDto> CountryGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = CountryGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<ICountryDto> CountryGets(SqlConnection con, SqlCommand cmd)
    {
      return CountryGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<ICountryDto> CountryGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderCountry[] orderBy)
    {
      ICollection<ICountryDto> dtos = new List<ICountryDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderCountry[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderCountry[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderCountry[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[Country]
              ,pt.[CountryKey]
              ,pt.[CurrencyId]
          FROM [core].[Country] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderCountry[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderCountry order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderCountry), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderCountry[] orderBy)
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
    private ICountryDto GetRead(SqlDataReader reader)
    {
      ICountryDto dto = new CountryDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.Country = reader.GetString(4);
      dto.CountryKey = reader.GetStringFromNullableDbValue(5);
      dto.CurrencyId = reader.GetInt64NullableFromNullableDbValue(6);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<ICountryHistDto>> CountryHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CountryHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<ICountryHistDto>> CountryHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<ICountryHistDto> dtos = new List<ICountryHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<ICountryHistDto> CountryHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CountryHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICountryHistDto> CountryHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      ICountryHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<ICountryHistDto> CountryHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = CountryHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<ICountryHistDto> CountryHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<ICountryHistDto> dtos = new List<ICountryHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistGets)}");
        throw;
      }
      return dtos;
    }
    public ICountryHistDto CountryHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = CountryHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public ICountryHistDto CountryHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      ICountryHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistEntryGet)}");
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
              ,[Country]
              ,[CountryKey]
              ,[CurrencyId]
          FROM [core].[Country_Hist]
        WHERE [Id] = @id";
    }
    private ICountryHistDto GetHistRead(SqlDataReader reader)
    {
      ICountryHistDto dto = new CountryHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.Country = reader.GetString(6);
      dto.CountryKey = reader.GetStringFromNullableDbValue(7);
      dto.CurrencyId = reader.GetInt64NullableFromNullableDbValue(8);
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
              ,[Country]
              ,[CountryKey]
              ,[CurrencyId]
          FROM [core].[Country_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task CountryHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CountryHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CountryHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CountryHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CountryHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistDeleteAsync)}");
        throw;
      }
    }
    public async Task CountryHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void CountryHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          CountryHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void CountryHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          CountryHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void CountryHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistDelete)}");
        throw;
      }
    }
    public void CountryHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryHistDelete)}");
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
              DELETE FROM [core].[Country_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[Country_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task CountrySaveAsync(ICountryDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CountrySaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CountrySaveAsync(SqlConnection con, SqlCommand cmd, ICountryDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountrySaveAsync)}");
        throw;
      }
    }
    public async Task CountryMergeAsync(ICountryDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CountryMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CountryMergeAsync(SqlConnection con, SqlCommand cmd, ICountryDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void CountrySave(ICountryDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CountrySave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void CountrySave(SqlConnection con, SqlCommand cmd, ICountryDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountrySave)}");
        throw;
      }
    }
    public void CountryMerge(ICountryDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CountryMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void CountryMerge(SqlConnection con, SqlCommand cmd, ICountryDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, ICountryDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value =  dto.Country ?? string.Empty;
      cmd.Parameters.Add("@CountryKey", SqlDbType.NVarChar).Value =  dto.CountryKey == null ? (object)DBNull.Value : dto.CountryKey;
      cmd.Parameters.Add("@CurrencyId", SqlDbType.BigInt).Value =  dto.CurrencyId == null ? (object)DBNull.Value : dto.CurrencyId;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[Country] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[Country]
                   ,[CountryKey]
                   ,[CurrencyId]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@Country
                   ,@CountryKey
                   ,@CurrencyId
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[Country]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[Country] = @Country
                   ,[CountryKey] = @CountryKey
                   ,[CurrencyId] = @CurrencyId
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Country] ON;
          MERGE INTO [core].[Country] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @Country, @CountryKey, @CurrencyId)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Country],[CountryKey],[CurrencyId])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Country]
                  ,[CountryKey]
                  ,[CurrencyId]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Country]
                 ,Source.[CountryKey]
                 ,Source.[CurrencyId]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Country] = Source.[Country]
                ,[CountryKey] = Source.[CountryKey]
                ,[CurrencyId] = Source.[CurrencyId]
          ;
          SET IDENTITY_INSERT [core].[Country] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task CountryDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CountryDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CountryDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await CountryDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task CountryDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryDeleteAsync)}");
        throw;
      }
    }
    public async Task CountryDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void CountryDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CountryDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void CountryDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          CountryDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void CountryDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryDelete)}");
        throw;
      }
    }
    public void CountryDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(CountryDao)}.{nameof(CountryDelete)}");
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
              DELETE FROM [core].[Country]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[Country] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task CountryBulkInsertAsync(ICollection<ICountryDto> dtos)
    {
      await CountryBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task CountryBulkInsertAsync(ICollection<ICountryDto> dtos, bool identityInsert)
    {
      await CountryBulkInsertAsync("[core].[Country]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task Country_TempBulkInsertAsync(ICollection<ICountryDto> dtos)
    {
      await Country_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task Country_TempBulkInsertAsync(ICollection<ICountryDto> dtos, bool identityInsert)
    {
      await CountryBulkInsertAsync("[core].[Country_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task CountryBulkMergeAsync(ICollection<ICountryDto> dtos)
    {
      await CountryBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task CountryBulkMergeAsync(ICollection<ICountryDto> dtos, bool identityInsert)
    {
      await CountryCreateTempTableAsync().ConfigureAwait(false);
      await Country_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await CountryMergeFromTempAsync().ConfigureAwait(false);
      await CountryDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task CountryBulkUpdateAsync(ICollection<ICountryDto> dtos)
    {
      await CountryCreateTempTableAsync().ConfigureAwait(false);
      await Country_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await CountryUpdateFromTempAsync().ConfigureAwait(false);
      await CountryDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task CountryBulkDeleteAsync(ICollection<ICountryDto> dtos)
    {
      await CountryCreateTempTableAsync().ConfigureAwait(false);
      await Country_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await CountryDeleteFromTempAsync().ConfigureAwait(false);
      await CountryDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task CountryBulkInsertAsync(string tableName, ICollection<ICountryDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(CountryGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task CountryMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task CountryUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task CountryDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task CountryCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task CountryDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void CountryBulkInsert(ICollection<ICountryDto> dtos)
    {
      CountryBulkInsert(dtos, false);
    }
    public void CountryBulkInsert(ICollection<ICountryDto> dtos, bool identityInsert)
    {
      CountryBulkInsert("[core].[Country]", dtos, identityInsert);
    }
    public void Country_TempBulkInsert(ICollection<ICountryDto> dtos)
    {
      Country_TempBulkInsert(dtos, false);
    }
    public void Country_TempBulkInsert(ICollection<ICountryDto> dtos, bool identityInsert)
    {
      CountryBulkInsert("[core].[Country_Temp]", dtos, identityInsert);
    }
    public void CountryBulkMerge(ICollection<ICountryDto> dtos)
    {
      CountryBulkMerge(dtos, false);
    }
    public void CountryBulkMerge(ICollection<ICountryDto> dtos, bool identityInsert)
    {
      CountryCreateTempTable();
      Country_TempBulkInsert(dtos, identityInsert);
      CountryMergeFromTemp();
      CountryDropTempTable();
    }
    public void CountryBulkUpdate(ICollection<ICountryDto> dtos)
    {
      CountryCreateTempTable();
      Country_TempBulkInsert(dtos, true);
      CountryUpdateFromTemp();
      CountryDropTempTable();
    }
    public void CountryBulkDelete(ICollection<ICountryDto> dtos)
    {
      CountryCreateTempTable();
      Country_TempBulkInsert(dtos, true);
      CountryDeleteFromTemp();
      CountryDropTempTable();
    }
    private void CountryBulkInsert(string tableName, ICollection<ICountryDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(CountryGetListAsDataTable(tableName, dtos));
        };
    }
    private void CountryMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void CountryUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void CountryDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void CountryCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void CountryDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetCountryDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetCountryMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Country] ON;
          MERGE INTO [core].[Country] AS Target
          USING [core].[Country_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Country]
                  ,[CountryKey]
                  ,[CurrencyId]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Country]
                 ,Source.[CountryKey]
                 ,Source.[CurrencyId]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Country] = Source.[Country]
                ,[CountryKey] = Source.[CountryKey]
                ,[CurrencyId] = Source.[CurrencyId]
          ;
          SET IDENTITY_INSERT [core].[Country] OFF;
      ";
    }
    private string GetCountryUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[Country] = Source.[Country]
                ,Target.[CountryKey] = Source.[CountryKey]
                ,Target.[CurrencyId] = Source.[CurrencyId]
          FROM [core].[Country] AS Target
          INNER JOIN [core].[Country_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetCountryDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[Country] AS Target
          INNER JOIN [core].[Country_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetCountryCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[Country_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[Country_Temp];
        
                  CREATE TABLE [core].[Country_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkCountry_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[Country]   nvarchar(100)   NULL
                     ,[CountryKey]   nvarchar(3)   NULL
                     ,[CurrencyId]   bigint   NULL
                  );
      ";
    }
    private string GetCountryDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[Country_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[Country_Temp];
                ";
    }
    private DataTable CountryGetListAsDataTable(string tableName, ICollection<ICountryDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcCountry = new DataColumn("Country", typeof(string));
      DataColumn dtcCountryKey = new DataColumn("CountryKey", typeof(string));
      DataColumn dtcCurrencyId = new DataColumn("CurrencyId", typeof(long));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcCountry.AllowDBNull = false;
      dtcCountryKey.AllowDBNull = true;
      dtcCurrencyId.AllowDBNull = true;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcCountry);
      table.Columns.Add(dtcCountryKey);
      table.Columns.Add(dtcCurrencyId);
      
      foreach (CountryDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.Country
          ,row.CountryKey
          ,row.CurrencyId
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> CountryHasChangedAsync(ICountryDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await CountryHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> CountryHasChangedAsync(SqlConnection con, SqlCommand cmd, ICountryDto dto)
    {
      if (dto.Id <= 0)
        return true;
      ICountryDto dtoDb = await CountryGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool CountryHasChanged(ICountryDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = CountryHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool CountryHasChanged(SqlConnection con, SqlCommand cmd, ICountryDto dto)
    {
      if (dto.Id <= 0)
        return true;
      ICountryDto dtoDb = CountryGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(ICountryDto dto, ICountryDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.Country == dtoDb.Country;
      ret = ret && dto.CountryKey == dtoDb.CountryKey;
      ret = ret && dto.CurrencyId == dtoDb.CurrencyId;
      return !ret;
    }
    #endregion
  }
}


