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
  public partial class DomainValueDao : Dao, IDomainValueDao, IDomainValueInternalDao
  {
    private readonly ILogger<DomainValueDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  DomainValueDao(IServiceProvider provider, ILogger<DomainValueDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> DomainValueGetCountAsync()
    {
      return await DomainValueGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> DomainValueGetCountAsync(WhereClause whereClause)
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
            FROM [core].[DomainValue] pv
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
    public async Task<IDomainValueDto> DomainValueGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainValueGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IDomainValueDto> DomainValueGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      IDomainValueDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(params OrderDomainValue[] orderBy)
    {
      return await DomainValueGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      return await DomainValueGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(WhereClause whereClause, bool distinct, params OrderDomainValue[] orderBy)
    {
      return await DomainValueGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainValueGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await DomainValueGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainValueDto>> DomainValueGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      ICollection<IDomainValueDto> dtos = new List<IDomainValueDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long DomainValueGetCount()
    {
      return DomainValueGetCount(new WhereClause());
    }
    public long DomainValueGetCount(WhereClause whereClause)
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
            FROM [core].[DomainValue] pv
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
    public IDomainValueDto DomainValueGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = DomainValueGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public IDomainValueDto DomainValueGet(SqlConnection con, SqlCommand cmd, long id)
    {
      IDomainValueDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<IDomainValueDto> DomainValueGets(params OrderDomainValue[] orderBy)
    {
      return DomainValueGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IDomainValueDto> DomainValueGets(int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      return DomainValueGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IDomainValueDto> DomainValueGets(WhereClause whereClause, bool distinct, params OrderDomainValue[] orderBy)
    {
      return DomainValueGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IDomainValueDto> DomainValueGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = DomainValueGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IDomainValueDto> DomainValueGets(SqlConnection con, SqlCommand cmd)
    {
      return DomainValueGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IDomainValueDto> DomainValueGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainValue[] orderBy)
    {
      ICollection<IDomainValueDto> dtos = new List<IDomainValueDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderDomainValue[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderDomainValue[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderDomainValue[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[TypeId]
              ,pt.[ValueC]
              ,pt.[ValueN]
              ,pt.[ValueD]
              ,pt.[ValueF]
              ,pt.[DivId]
              ,pt.[Description]
              ,pt.[Unit]
              ,pt.[TenantId]
          FROM [core].[DomainValue] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderDomainValue[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderDomainValue order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderDomainValue), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderDomainValue[] orderBy)
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
    private IDomainValueDto GetRead(SqlDataReader reader)
    {
      IDomainValueDto dto = new DomainValueDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.TypeId = reader.GetInt64(4);
      dto.ValueC = reader.GetStringFromNullableDbValue(5);
      dto.ValueN = reader.GetInt64NullableFromNullableDbValue(6);
      dto.ValueD = reader.GetDateTimeNullableFromNullableDbValue(7);
      dto.ValueF = reader.GetDoubleNullableFromNullableDbValue(8);
      dto.DivId = reader.GetStringFromNullableDbValue(9);
      dto.Description = reader.GetString(10);
      dto.Unit = reader.GetStringFromNullableDbValue(11);
      dto.TenantId = reader.GetInt64(12);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<IDomainValueHistDto>> DomainValueHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainValueHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IDomainValueHistDto>> DomainValueHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IDomainValueHistDto> dtos = new List<IDomainValueHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<IDomainValueHistDto> DomainValueHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainValueHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IDomainValueHistDto> DomainValueHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      IDomainValueHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<IDomainValueHistDto> DomainValueHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = DomainValueHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IDomainValueHistDto> DomainValueHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IDomainValueHistDto> dtos = new List<IDomainValueHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistGets)}");
        throw;
      }
      return dtos;
    }
    public IDomainValueHistDto DomainValueHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = DomainValueHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public IDomainValueHistDto DomainValueHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      IDomainValueHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistEntryGet)}");
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
              ,[TypeId]
              ,[ValueC]
              ,[ValueN]
              ,[ValueD]
              ,[ValueF]
              ,[DivId]
              ,[Description]
              ,[Unit]
              ,[TenantId]
          FROM [core].[DomainValue_Hist]
        WHERE [Id] = @id";
    }
    private IDomainValueHistDto GetHistRead(SqlDataReader reader)
    {
      IDomainValueHistDto dto = new DomainValueHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.TypeId = reader.GetInt64(6);
      dto.ValueC = reader.GetStringFromNullableDbValue(7);
      dto.ValueN = reader.GetInt64NullableFromNullableDbValue(8);
      dto.ValueD = reader.GetDateTimeNullableFromNullableDbValue(9);
      dto.ValueF = reader.GetDoubleNullableFromNullableDbValue(10);
      dto.DivId = reader.GetStringFromNullableDbValue(11);
      dto.Description = reader.GetString(12);
      dto.Unit = reader.GetStringFromNullableDbValue(13);
      dto.TenantId = reader.GetInt64(14);
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
              ,[TypeId]
              ,[ValueC]
              ,[ValueN]
              ,[ValueD]
              ,[ValueF]
              ,[DivId]
              ,[Description]
              ,[Unit]
              ,[TenantId]
          FROM [core].[DomainValue_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task DomainValueHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainValueHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainValueHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainValueHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainValueHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistDeleteAsync)}");
        throw;
      }
    }
    public async Task DomainValueHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void DomainValueHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          DomainValueHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void DomainValueHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          DomainValueHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void DomainValueHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistDelete)}");
        throw;
      }
    }
    public void DomainValueHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueHistDelete)}");
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
              DELETE FROM [core].[DomainValue_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[DomainValue_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task DomainValueSaveAsync(IDomainValueDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainValueSaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainValueSaveAsync(SqlConnection con, SqlCommand cmd, IDomainValueDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueSaveAsync)}");
        throw;
      }
    }
    public async Task DomainValueMergeAsync(IDomainValueDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainValueMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainValueMergeAsync(SqlConnection con, SqlCommand cmd, IDomainValueDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void DomainValueSave(IDomainValueDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainValueSave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void DomainValueSave(SqlConnection con, SqlCommand cmd, IDomainValueDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueSave)}");
        throw;
      }
    }
    public void DomainValueMerge(IDomainValueDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainValueMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void DomainValueMerge(SqlConnection con, SqlCommand cmd, IDomainValueDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, IDomainValueDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@TypeId", SqlDbType.BigInt).Value =  dto.TypeId;
      cmd.Parameters.Add("@ValueC", SqlDbType.NVarChar).Value =  dto.ValueC == null ? (object)DBNull.Value : dto.ValueC;
      cmd.Parameters.Add("@ValueN", SqlDbType.BigInt).Value =  dto.ValueN == null ? (object)DBNull.Value : dto.ValueN;
      cmd.Parameters.Add("@ValueD", SqlDbType.DateTime2).Value =  dto.ValueD == null ? (object)DBNull.Value : dto.ValueD;
      cmd.Parameters.Add("@ValueF", SqlDbType.Float).Value =  dto.ValueF == null ? (object)DBNull.Value : dto.ValueF;
      cmd.Parameters.Add("@DivId", SqlDbType.NVarChar).Value =  dto.DivId == null ? (object)DBNull.Value : dto.DivId;
      cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value =  dto.Description ?? string.Empty;
      cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value =  dto.Unit == null ? (object)DBNull.Value : dto.Unit;
      cmd.Parameters.Add("@TenantId", SqlDbType.BigInt).Value =  dto.TenantId;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[DomainValue] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[TypeId]
                   ,[ValueC]
                   ,[ValueN]
                   ,[ValueD]
                   ,[ValueF]
                   ,[DivId]
                   ,[Description]
                   ,[Unit]
                   ,[TenantId]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@TypeId
                   ,@ValueC
                   ,@ValueN
                   ,@ValueD
                   ,@ValueF
                   ,@DivId
                   ,@Description
                   ,@Unit
                   ,@TenantId
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[DomainValue]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[TypeId] = @TypeId
                   ,[ValueC] = @ValueC
                   ,[ValueN] = @ValueN
                   ,[ValueD] = @ValueD
                   ,[ValueF] = @ValueF
                   ,[DivId] = @DivId
                   ,[Description] = @Description
                   ,[Unit] = @Unit
                   ,[TenantId] = @TenantId
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[DomainValue] ON;
          MERGE INTO [core].[DomainValue] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @TypeId, @ValueC, @ValueN, @ValueD, @ValueF, @DivId, @Description, @Unit, @TenantId)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[TypeId],[ValueC],[ValueN],[ValueD],[ValueF],[DivId],[Description],[Unit],[TenantId])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[TypeId]
                  ,[ValueC]
                  ,[ValueN]
                  ,[ValueD]
                  ,[ValueF]
                  ,[DivId]
                  ,[Description]
                  ,[Unit]
                  ,[TenantId]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[TypeId]
                 ,Source.[ValueC]
                 ,Source.[ValueN]
                 ,Source.[ValueD]
                 ,Source.[ValueF]
                 ,Source.[DivId]
                 ,Source.[Description]
                 ,Source.[Unit]
                 ,Source.[TenantId]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[TypeId] = Source.[TypeId]
                ,[ValueC] = Source.[ValueC]
                ,[ValueN] = Source.[ValueN]
                ,[ValueD] = Source.[ValueD]
                ,[ValueF] = Source.[ValueF]
                ,[DivId] = Source.[DivId]
                ,[Description] = Source.[Description]
                ,[Unit] = Source.[Unit]
                ,[TenantId] = Source.[TenantId]
          ;
          SET IDENTITY_INSERT [core].[DomainValue] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task DomainValueDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainValueDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainValueDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainValueDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainValueDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueDeleteAsync)}");
        throw;
      }
    }
    public async Task DomainValueDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void DomainValueDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainValueDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void DomainValueDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainValueDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void DomainValueDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueDelete)}");
        throw;
      }
    }
    public void DomainValueDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainValueDao)}.{nameof(DomainValueDelete)}");
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
              DELETE FROM [core].[DomainValue]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[DomainValue] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task DomainValueBulkInsertAsync(ICollection<IDomainValueDto> dtos)
    {
      await DomainValueBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task DomainValueBulkInsertAsync(ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      await DomainValueBulkInsertAsync("[core].[DomainValue]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task DomainValue_TempBulkInsertAsync(ICollection<IDomainValueDto> dtos)
    {
      await DomainValue_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task DomainValue_TempBulkInsertAsync(ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      await DomainValueBulkInsertAsync("[core].[DomainValue_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task DomainValueBulkMergeAsync(ICollection<IDomainValueDto> dtos)
    {
      await DomainValueBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task DomainValueBulkMergeAsync(ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      await DomainValueCreateTempTableAsync().ConfigureAwait(false);
      await DomainValue_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await DomainValueMergeFromTempAsync().ConfigureAwait(false);
      await DomainValueDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task DomainValueBulkUpdateAsync(ICollection<IDomainValueDto> dtos)
    {
      await DomainValueCreateTempTableAsync().ConfigureAwait(false);
      await DomainValue_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await DomainValueUpdateFromTempAsync().ConfigureAwait(false);
      await DomainValueDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task DomainValueBulkDeleteAsync(ICollection<IDomainValueDto> dtos)
    {
      await DomainValueCreateTempTableAsync().ConfigureAwait(false);
      await DomainValue_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await DomainValueDeleteFromTempAsync().ConfigureAwait(false);
      await DomainValueDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task DomainValueBulkInsertAsync(string tableName, ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(DomainValueGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task DomainValueMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task DomainValueUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task DomainValueDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task DomainValueCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task DomainValueDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void DomainValueBulkInsert(ICollection<IDomainValueDto> dtos)
    {
      DomainValueBulkInsert(dtos, false);
    }
    public void DomainValueBulkInsert(ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      DomainValueBulkInsert("[core].[DomainValue]", dtos, identityInsert);
    }
    public void DomainValue_TempBulkInsert(ICollection<IDomainValueDto> dtos)
    {
      DomainValue_TempBulkInsert(dtos, false);
    }
    public void DomainValue_TempBulkInsert(ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      DomainValueBulkInsert("[core].[DomainValue_Temp]", dtos, identityInsert);
    }
    public void DomainValueBulkMerge(ICollection<IDomainValueDto> dtos)
    {
      DomainValueBulkMerge(dtos, false);
    }
    public void DomainValueBulkMerge(ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      DomainValueCreateTempTable();
      DomainValue_TempBulkInsert(dtos, identityInsert);
      DomainValueMergeFromTemp();
      DomainValueDropTempTable();
    }
    public void DomainValueBulkUpdate(ICollection<IDomainValueDto> dtos)
    {
      DomainValueCreateTempTable();
      DomainValue_TempBulkInsert(dtos, true);
      DomainValueUpdateFromTemp();
      DomainValueDropTempTable();
    }
    public void DomainValueBulkDelete(ICollection<IDomainValueDto> dtos)
    {
      DomainValueCreateTempTable();
      DomainValue_TempBulkInsert(dtos, true);
      DomainValueDeleteFromTemp();
      DomainValueDropTempTable();
    }
    private void DomainValueBulkInsert(string tableName, ICollection<IDomainValueDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(DomainValueGetListAsDataTable(tableName, dtos));
        };
    }
    private void DomainValueMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void DomainValueUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void DomainValueDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void DomainValueCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void DomainValueDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainValueDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetDomainValueMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[DomainValue] ON;
          MERGE INTO [core].[DomainValue] AS Target
          USING [core].[DomainValue_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[TypeId]
                  ,[ValueC]
                  ,[ValueN]
                  ,[ValueD]
                  ,[ValueF]
                  ,[DivId]
                  ,[Description]
                  ,[Unit]
                  ,[TenantId]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[TypeId]
                 ,Source.[ValueC]
                 ,Source.[ValueN]
                 ,Source.[ValueD]
                 ,Source.[ValueF]
                 ,Source.[DivId]
                 ,Source.[Description]
                 ,Source.[Unit]
                 ,Source.[TenantId]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[TypeId] = Source.[TypeId]
                ,[ValueC] = Source.[ValueC]
                ,[ValueN] = Source.[ValueN]
                ,[ValueD] = Source.[ValueD]
                ,[ValueF] = Source.[ValueF]
                ,[DivId] = Source.[DivId]
                ,[Description] = Source.[Description]
                ,[Unit] = Source.[Unit]
                ,[TenantId] = Source.[TenantId]
          ;
          SET IDENTITY_INSERT [core].[DomainValue] OFF;
      ";
    }
    private string GetDomainValueUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[TypeId] = Source.[TypeId]
                ,Target.[ValueC] = Source.[ValueC]
                ,Target.[ValueN] = Source.[ValueN]
                ,Target.[ValueD] = Source.[ValueD]
                ,Target.[ValueF] = Source.[ValueF]
                ,Target.[DivId] = Source.[DivId]
                ,Target.[Description] = Source.[Description]
                ,Target.[Unit] = Source.[Unit]
                ,Target.[TenantId] = Source.[TenantId]
          FROM [core].[DomainValue] AS Target
          INNER JOIN [core].[DomainValue_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetDomainValueDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[DomainValue] AS Target
          INNER JOIN [core].[DomainValue_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetDomainValueCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[DomainValue_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[DomainValue_Temp];
        
                  CREATE TABLE [core].[DomainValue_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkDomainValue_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[TypeId]   bigint   NULL
                     ,[ValueC]   nvarchar(400)   NULL
                     ,[ValueN]   bigint   NULL
                     ,[ValueD]   datetime2   NULL
                     ,[ValueF]   float   NULL
                     ,[DivId]   nvarchar(MAX)   NULL
                     ,[Description]   nvarchar(4000)   NULL
                     ,[Unit]   nvarchar(100)   NULL
                     ,[TenantId]   bigint   NULL
                  );
      ";
    }
    private string GetDomainValueDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[DomainValue_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[DomainValue_Temp];
                ";
    }
    private DataTable DomainValueGetListAsDataTable(string tableName, ICollection<IDomainValueDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcTypeId = new DataColumn("TypeId", typeof(long));
      DataColumn dtcValueC = new DataColumn("ValueC", typeof(string));
      DataColumn dtcValueN = new DataColumn("ValueN", typeof(long));
      DataColumn dtcValueD = new DataColumn("ValueD", typeof(DateTime));
      DataColumn dtcValueF = new DataColumn("ValueF", typeof(double));
      DataColumn dtcDivId = new DataColumn("DivId", typeof(string));
      DataColumn dtcDescription = new DataColumn("Description", typeof(string));
      DataColumn dtcUnit = new DataColumn("Unit", typeof(string));
      DataColumn dtcTenantId = new DataColumn("TenantId", typeof(long));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcTypeId.AllowDBNull = false;
      dtcValueC.AllowDBNull = true;
      dtcValueN.AllowDBNull = true;
      dtcValueD.AllowDBNull = true;
      dtcValueF.AllowDBNull = true;
      dtcDivId.AllowDBNull = true;
      dtcDescription.AllowDBNull = false;
      dtcUnit.AllowDBNull = true;
      dtcTenantId.AllowDBNull = false;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcTypeId);
      table.Columns.Add(dtcValueC);
      table.Columns.Add(dtcValueN);
      table.Columns.Add(dtcValueD);
      table.Columns.Add(dtcValueF);
      table.Columns.Add(dtcDivId);
      table.Columns.Add(dtcDescription);
      table.Columns.Add(dtcUnit);
      table.Columns.Add(dtcTenantId);
      
      foreach (DomainValueDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.TypeId
          ,row.ValueC
          ,row.ValueN
          ,row.ValueD
          ,row.ValueF
          ,row.DivId
          ,row.Description
          ,row.Unit
          ,row.TenantId
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> DomainValueHasChangedAsync(IDomainValueDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainValueHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> DomainValueHasChangedAsync(SqlConnection con, SqlCommand cmd, IDomainValueDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IDomainValueDto dtoDb = await DomainValueGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool DomainValueHasChanged(IDomainValueDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = DomainValueHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool DomainValueHasChanged(SqlConnection con, SqlCommand cmd, IDomainValueDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IDomainValueDto dtoDb = DomainValueGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(IDomainValueDto dto, IDomainValueDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.TypeId == dtoDb.TypeId;
      ret = ret && dto.ValueC == dtoDb.ValueC;
      ret = ret && dto.ValueN == dtoDb.ValueN;
      ret = ret && dto.ValueD == dtoDb.ValueD;
      ret = ret && dto.ValueF == dtoDb.ValueF;
      ret = ret && dto.DivId == dtoDb.DivId;
      ret = ret && dto.Description == dtoDb.Description;
      ret = ret && dto.Unit == dtoDb.Unit;
      ret = ret && dto.TenantId == dtoDb.TenantId;
      return !ret;
    }
    #endregion
  }
}


