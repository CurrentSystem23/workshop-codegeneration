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
  public partial class DomainTypeDao : Dao, IDomainTypeDao, IDomainTypeInternalDao
  {
    private readonly ILogger<DomainTypeDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  DomainTypeDao(IServiceProvider provider, ILogger<DomainTypeDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> DomainTypeGetCountAsync()
    {
      return await DomainTypeGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> DomainTypeGetCountAsync(WhereClause whereClause)
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
            FROM [core].[DomainType] pv
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
    public async Task<IDomainTypeDto> DomainTypeGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainTypeGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IDomainTypeDto> DomainTypeGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      IDomainTypeDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(params OrderDomainType[] orderBy)
    {
      return await DomainTypeGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      return await DomainTypeGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(WhereClause whereClause, bool distinct, params OrderDomainType[] orderBy)
    {
      return await DomainTypeGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainTypeGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await DomainTypeGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IDomainTypeDto>> DomainTypeGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      ICollection<IDomainTypeDto> dtos = new List<IDomainTypeDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long DomainTypeGetCount()
    {
      return DomainTypeGetCount(new WhereClause());
    }
    public long DomainTypeGetCount(WhereClause whereClause)
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
            FROM [core].[DomainType] pv
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
    public IDomainTypeDto DomainTypeGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = DomainTypeGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public IDomainTypeDto DomainTypeGet(SqlConnection con, SqlCommand cmd, long id)
    {
      IDomainTypeDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<IDomainTypeDto> DomainTypeGets(params OrderDomainType[] orderBy)
    {
      return DomainTypeGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IDomainTypeDto> DomainTypeGets(int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      return DomainTypeGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IDomainTypeDto> DomainTypeGets(WhereClause whereClause, bool distinct, params OrderDomainType[] orderBy)
    {
      return DomainTypeGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IDomainTypeDto> DomainTypeGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = DomainTypeGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IDomainTypeDto> DomainTypeGets(SqlConnection con, SqlCommand cmd)
    {
      return DomainTypeGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IDomainTypeDto> DomainTypeGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderDomainType[] orderBy)
    {
      ICollection<IDomainTypeDto> dtos = new List<IDomainTypeDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderDomainType[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderDomainType[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderDomainType[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[Type]
              ,pt.[Description]
              ,pt.[Mode]
              ,pt.[StandardId]
              ,pt.[Editable]
          FROM [core].[DomainType] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderDomainType[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderDomainType order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderDomainType), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderDomainType[] orderBy)
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
    private IDomainTypeDto GetRead(SqlDataReader reader)
    {
      IDomainTypeDto dto = new DomainTypeDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.Type = reader.GetString(4);
      dto.Description = reader.GetString(5);
      dto.Mode = reader.GetSingleChar(6);
      dto.StandardId = reader.GetInt64NullableFromNullableDbValue(7);
      dto.Editable = reader.GetInt64(8);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<IDomainTypeHistDto>> DomainTypeHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainTypeHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IDomainTypeHistDto>> DomainTypeHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IDomainTypeHistDto> dtos = new List<IDomainTypeHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<IDomainTypeHistDto> DomainTypeHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainTypeHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IDomainTypeHistDto> DomainTypeHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      IDomainTypeHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<IDomainTypeHistDto> DomainTypeHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = DomainTypeHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IDomainTypeHistDto> DomainTypeHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IDomainTypeHistDto> dtos = new List<IDomainTypeHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistGets)}");
        throw;
      }
      return dtos;
    }
    public IDomainTypeHistDto DomainTypeHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = DomainTypeHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public IDomainTypeHistDto DomainTypeHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      IDomainTypeHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistEntryGet)}");
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
              ,[Type]
              ,[Description]
              ,[Mode]
              ,[StandardId]
              ,[Editable]
          FROM [core].[DomainType_Hist]
        WHERE [Id] = @id";
    }
    private IDomainTypeHistDto GetHistRead(SqlDataReader reader)
    {
      IDomainTypeHistDto dto = new DomainTypeHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.Type = reader.GetString(6);
      dto.Description = reader.GetString(7);
      dto.Mode = reader.GetSingleChar(8);
      dto.StandardId = reader.GetInt64NullableFromNullableDbValue(9);
      dto.Editable = reader.GetInt64(10);
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
              ,[Type]
              ,[Description]
              ,[Mode]
              ,[StandardId]
              ,[Editable]
          FROM [core].[DomainType_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task DomainTypeHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainTypeHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainTypeHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainTypeHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainTypeHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistDeleteAsync)}");
        throw;
      }
    }
    public async Task DomainTypeHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void DomainTypeHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          DomainTypeHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void DomainTypeHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          DomainTypeHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void DomainTypeHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistDelete)}");
        throw;
      }
    }
    public void DomainTypeHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeHistDelete)}");
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
              DELETE FROM [core].[DomainType_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[DomainType_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task DomainTypeSaveAsync(IDomainTypeDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainTypeSaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainTypeSaveAsync(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeSaveAsync)}");
        throw;
      }
    }
    public async Task DomainTypeMergeAsync(IDomainTypeDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainTypeMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainTypeMergeAsync(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void DomainTypeSave(IDomainTypeDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainTypeSave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void DomainTypeSave(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeSave)}");
        throw;
      }
    }
    public void DomainTypeMerge(IDomainTypeDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainTypeMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void DomainTypeMerge(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, IDomainTypeDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value =  dto.Type ?? string.Empty;
      cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value =  dto.Description ?? string.Empty;
      cmd.Parameters.Add("@Mode", SqlDbType.Char).Value =  dto.Mode;
      cmd.Parameters.Add("@StandardId", SqlDbType.BigInt).Value =  dto.StandardId == null ? (object)DBNull.Value : dto.StandardId;
      cmd.Parameters.Add("@Editable", SqlDbType.BigInt).Value =  dto.Editable;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[DomainType] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[Type]
                   ,[Description]
                   ,[Mode]
                   ,[StandardId]
                   ,[Editable]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@Type
                   ,@Description
                   ,@Mode
                   ,@StandardId
                   ,@Editable
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[DomainType]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[Type] = @Type
                   ,[Description] = @Description
                   ,[Mode] = @Mode
                   ,[StandardId] = @StandardId
                   ,[Editable] = @Editable
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[DomainType] ON;
          MERGE INTO [core].[DomainType] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @Type, @Description, @Mode, @StandardId, @Editable)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Type],[Description],[Mode],[StandardId],[Editable])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Type]
                  ,[Description]
                  ,[Mode]
                  ,[StandardId]
                  ,[Editable]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Type]
                 ,Source.[Description]
                 ,Source.[Mode]
                 ,Source.[StandardId]
                 ,Source.[Editable]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Type] = Source.[Type]
                ,[Description] = Source.[Description]
                ,[Mode] = Source.[Mode]
                ,[StandardId] = Source.[StandardId]
                ,[Editable] = Source.[Editable]
          ;
          SET IDENTITY_INSERT [core].[DomainType] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task DomainTypeDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainTypeDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainTypeDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await DomainTypeDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task DomainTypeDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeDeleteAsync)}");
        throw;
      }
    }
    public async Task DomainTypeDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void DomainTypeDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainTypeDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void DomainTypeDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          DomainTypeDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void DomainTypeDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeDelete)}");
        throw;
      }
    }
    public void DomainTypeDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(DomainTypeDao)}.{nameof(DomainTypeDelete)}");
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
              DELETE FROM [core].[DomainType]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[DomainType] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task DomainTypeBulkInsertAsync(ICollection<IDomainTypeDto> dtos)
    {
      await DomainTypeBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task DomainTypeBulkInsertAsync(ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      await DomainTypeBulkInsertAsync("[core].[DomainType]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task DomainType_TempBulkInsertAsync(ICollection<IDomainTypeDto> dtos)
    {
      await DomainType_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task DomainType_TempBulkInsertAsync(ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      await DomainTypeBulkInsertAsync("[core].[DomainType_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task DomainTypeBulkMergeAsync(ICollection<IDomainTypeDto> dtos)
    {
      await DomainTypeBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task DomainTypeBulkMergeAsync(ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      await DomainTypeCreateTempTableAsync().ConfigureAwait(false);
      await DomainType_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await DomainTypeMergeFromTempAsync().ConfigureAwait(false);
      await DomainTypeDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task DomainTypeBulkUpdateAsync(ICollection<IDomainTypeDto> dtos)
    {
      await DomainTypeCreateTempTableAsync().ConfigureAwait(false);
      await DomainType_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await DomainTypeUpdateFromTempAsync().ConfigureAwait(false);
      await DomainTypeDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task DomainTypeBulkDeleteAsync(ICollection<IDomainTypeDto> dtos)
    {
      await DomainTypeCreateTempTableAsync().ConfigureAwait(false);
      await DomainType_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await DomainTypeDeleteFromTempAsync().ConfigureAwait(false);
      await DomainTypeDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task DomainTypeBulkInsertAsync(string tableName, ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(DomainTypeGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task DomainTypeMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task DomainTypeUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task DomainTypeDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task DomainTypeCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task DomainTypeDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void DomainTypeBulkInsert(ICollection<IDomainTypeDto> dtos)
    {
      DomainTypeBulkInsert(dtos, false);
    }
    public void DomainTypeBulkInsert(ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      DomainTypeBulkInsert("[core].[DomainType]", dtos, identityInsert);
    }
    public void DomainType_TempBulkInsert(ICollection<IDomainTypeDto> dtos)
    {
      DomainType_TempBulkInsert(dtos, false);
    }
    public void DomainType_TempBulkInsert(ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      DomainTypeBulkInsert("[core].[DomainType_Temp]", dtos, identityInsert);
    }
    public void DomainTypeBulkMerge(ICollection<IDomainTypeDto> dtos)
    {
      DomainTypeBulkMerge(dtos, false);
    }
    public void DomainTypeBulkMerge(ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      DomainTypeCreateTempTable();
      DomainType_TempBulkInsert(dtos, identityInsert);
      DomainTypeMergeFromTemp();
      DomainTypeDropTempTable();
    }
    public void DomainTypeBulkUpdate(ICollection<IDomainTypeDto> dtos)
    {
      DomainTypeCreateTempTable();
      DomainType_TempBulkInsert(dtos, true);
      DomainTypeUpdateFromTemp();
      DomainTypeDropTempTable();
    }
    public void DomainTypeBulkDelete(ICollection<IDomainTypeDto> dtos)
    {
      DomainTypeCreateTempTable();
      DomainType_TempBulkInsert(dtos, true);
      DomainTypeDeleteFromTemp();
      DomainTypeDropTempTable();
    }
    private void DomainTypeBulkInsert(string tableName, ICollection<IDomainTypeDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(DomainTypeGetListAsDataTable(tableName, dtos));
        };
    }
    private void DomainTypeMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void DomainTypeUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void DomainTypeDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void DomainTypeCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void DomainTypeDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetDomainTypeDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetDomainTypeMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[DomainType] ON;
          MERGE INTO [core].[DomainType] AS Target
          USING [core].[DomainType_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Type]
                  ,[Description]
                  ,[Mode]
                  ,[StandardId]
                  ,[Editable]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Type]
                 ,Source.[Description]
                 ,Source.[Mode]
                 ,Source.[StandardId]
                 ,Source.[Editable]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Type] = Source.[Type]
                ,[Description] = Source.[Description]
                ,[Mode] = Source.[Mode]
                ,[StandardId] = Source.[StandardId]
                ,[Editable] = Source.[Editable]
          ;
          SET IDENTITY_INSERT [core].[DomainType] OFF;
      ";
    }
    private string GetDomainTypeUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[Type] = Source.[Type]
                ,Target.[Description] = Source.[Description]
                ,Target.[Mode] = Source.[Mode]
                ,Target.[StandardId] = Source.[StandardId]
                ,Target.[Editable] = Source.[Editable]
          FROM [core].[DomainType] AS Target
          INNER JOIN [core].[DomainType_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetDomainTypeDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[DomainType] AS Target
          INNER JOIN [core].[DomainType_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetDomainTypeCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[DomainType_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[DomainType_Temp];
        
                  CREATE TABLE [core].[DomainType_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkDomainType_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[Type]   nvarchar(50)   NULL
                     ,[Description]   nvarchar(MAX)   NULL
                     ,[Mode]   char(1)   NULL
                     ,[StandardId]   bigint   NULL
                     ,[Editable]   bigint   NULL
                  );
      ";
    }
    private string GetDomainTypeDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[DomainType_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[DomainType_Temp];
                ";
    }
    private DataTable DomainTypeGetListAsDataTable(string tableName, ICollection<IDomainTypeDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcType = new DataColumn("Type", typeof(string));
      DataColumn dtcDescription = new DataColumn("Description", typeof(string));
      DataColumn dtcMode = new DataColumn("Mode", typeof(char));
      DataColumn dtcStandardId = new DataColumn("StandardId", typeof(long));
      DataColumn dtcEditable = new DataColumn("Editable", typeof(long));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcType.AllowDBNull = false;
      dtcDescription.AllowDBNull = false;
      dtcMode.AllowDBNull = false;
      dtcStandardId.AllowDBNull = true;
      dtcEditable.AllowDBNull = false;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcType);
      table.Columns.Add(dtcDescription);
      table.Columns.Add(dtcMode);
      table.Columns.Add(dtcStandardId);
      table.Columns.Add(dtcEditable);
      
      foreach (DomainTypeDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.Type
          ,row.Description
          ,row.Mode
          ,row.StandardId
          ,row.Editable
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> DomainTypeHasChangedAsync(IDomainTypeDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await DomainTypeHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> DomainTypeHasChangedAsync(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IDomainTypeDto dtoDb = await DomainTypeGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool DomainTypeHasChanged(IDomainTypeDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = DomainTypeHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool DomainTypeHasChanged(SqlConnection con, SqlCommand cmd, IDomainTypeDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IDomainTypeDto dtoDb = DomainTypeGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(IDomainTypeDto dto, IDomainTypeDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.Type == dtoDb.Type;
      ret = ret && dto.Description == dtoDb.Description;
      ret = ret && dto.Mode == dtoDb.Mode;
      ret = ret && dto.StandardId == dtoDb.StandardId;
      ret = ret && dto.Editable == dtoDb.Editable;
      return !ret;
    }
    #endregion
  }
}


