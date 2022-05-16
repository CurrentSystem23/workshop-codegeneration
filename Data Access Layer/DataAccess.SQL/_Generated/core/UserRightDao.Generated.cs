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
  public partial class UserRightDao : Dao, IUserRightDao, IUserRightInternalDao
  {
    private readonly ILogger<UserRightDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  UserRightDao(IServiceProvider provider, ILogger<UserRightDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> UserRightGetCountAsync()
    {
      return await UserRightGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> UserRightGetCountAsync(WhereClause whereClause)
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
            FROM [core].[UserRight] pv
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
    public async Task<IUserRightDto> UserRightGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserRightDto> UserRightGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserRightDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<IUserRightDto>> UserRightGetsAsync(params OrderUserRight[] orderBy)
    {
      return await UserRightGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightDto>> UserRightGetsAsync(int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      return await UserRightGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightDto>> UserRightGetsAsync(WhereClause whereClause, bool distinct, params OrderUserRight[] orderBy)
    {
      return await UserRightGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightDto>> UserRightGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserRightDto>> UserRightGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await UserRightGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightDto>> UserRightGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      ICollection<IUserRightDto> dtos = new List<IUserRightDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long UserRightGetCount()
    {
      return UserRightGetCount(new WhereClause());
    }
    public long UserRightGetCount(WhereClause whereClause)
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
            FROM [core].[UserRight] pv
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
    public IUserRightDto UserRightGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserRightGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public IUserRightDto UserRightGet(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserRightDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<IUserRightDto> UserRightGets(params OrderUserRight[] orderBy)
    {
      return UserRightGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IUserRightDto> UserRightGets(int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      return UserRightGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IUserRightDto> UserRightGets(WhereClause whereClause, bool distinct, params OrderUserRight[] orderBy)
    {
      return UserRightGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IUserRightDto> UserRightGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserRightGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserRightDto> UserRightGets(SqlConnection con, SqlCommand cmd)
    {
      return UserRightGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IUserRightDto> UserRightGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRight[] orderBy)
    {
      ICollection<IUserRightDto> dtos = new List<IUserRightDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserRight[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserRight[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserRight[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[Right]
              ,pt.[Description]
          FROM [core].[UserRight] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderUserRight[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderUserRight order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderUserRight), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderUserRight[] orderBy)
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
    private IUserRightDto GetRead(SqlDataReader reader)
    {
      IUserRightDto dto = new UserRightDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.Right = reader.GetString(4);
      dto.Description = reader.GetString(5);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<IUserRightHistDto>> UserRightHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserRightHistDto>> UserRightHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserRightHistDto> dtos = new List<IUserRightHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<IUserRightHistDto> UserRightHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserRightHistDto> UserRightHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserRightHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<IUserRightHistDto> UserRightHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserRightHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserRightHistDto> UserRightHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserRightHistDto> dtos = new List<IUserRightHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistGets)}");
        throw;
      }
      return dtos;
    }
    public IUserRightHistDto UserRightHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserRightHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public IUserRightHistDto UserRightHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserRightHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistEntryGet)}");
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
              ,[Right]
              ,[Description]
          FROM [core].[UserRight_Hist]
        WHERE [Id] = @id";
    }
    private IUserRightHistDto GetHistRead(SqlDataReader reader)
    {
      IUserRightHistDto dto = new UserRightHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.Right = reader.GetString(6);
      dto.Description = reader.GetString(7);
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
              ,[Right]
              ,[Description]
          FROM [core].[UserRight_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task UserRightHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistDeleteAsync)}");
        throw;
      }
    }
    public async Task UserRightHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserRightHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserRightHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void UserRightHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserRightHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserRightHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistDelete)}");
        throw;
      }
    }
    public void UserRightHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightHistDelete)}");
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
              DELETE FROM [core].[UserRight_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[UserRight_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task UserRightSaveAsync(IUserRightDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightSaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightSaveAsync(SqlConnection con, SqlCommand cmd, IUserRightDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightSaveAsync)}");
        throw;
      }
    }
    public async Task UserRightMergeAsync(IUserRightDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightMergeAsync(SqlConnection con, SqlCommand cmd, IUserRightDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserRightSave(IUserRightDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightSave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserRightSave(SqlConnection con, SqlCommand cmd, IUserRightDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightSave)}");
        throw;
      }
    }
    public void UserRightMerge(IUserRightDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserRightMerge(SqlConnection con, SqlCommand cmd, IUserRightDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, IUserRightDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@Right", SqlDbType.NVarChar).Value =  dto.Right ?? string.Empty;
      cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value =  dto.Description ?? string.Empty;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[UserRight] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[Right]
                   ,[Description]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@Right
                   ,@Description
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[UserRight]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[Right] = @Right
                   ,[Description] = @Description
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[UserRight] ON;
          MERGE INTO [core].[UserRight] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @Right, @Description)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Right],[Description])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Right]
                  ,[Description]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Right]
                 ,Source.[Description]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Right] = Source.[Right]
                ,[Description] = Source.[Description]
          ;
          SET IDENTITY_INSERT [core].[UserRight] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task UserRightDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightDeleteAsync)}");
        throw;
      }
    }
    public async Task UserRightDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserRightDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void UserRightDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserRightDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightDelete)}");
        throw;
      }
    }
    public void UserRightDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightDao)}.{nameof(UserRightDelete)}");
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
              DELETE FROM [core].[UserRight]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[UserRight] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task UserRightBulkInsertAsync(ICollection<IUserRightDto> dtos)
    {
      await UserRightBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserRightBulkInsertAsync(ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      await UserRightBulkInsertAsync("[core].[UserRight]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task UserRight_TempBulkInsertAsync(ICollection<IUserRightDto> dtos)
    {
      await UserRight_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserRight_TempBulkInsertAsync(ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      await UserRightBulkInsertAsync("[core].[UserRight_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task UserRightBulkMergeAsync(ICollection<IUserRightDto> dtos)
    {
      await UserRightBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserRightBulkMergeAsync(ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      await UserRightCreateTempTableAsync().ConfigureAwait(false);
      await UserRight_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await UserRightMergeFromTempAsync().ConfigureAwait(false);
      await UserRightDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserRightBulkUpdateAsync(ICollection<IUserRightDto> dtos)
    {
      await UserRightCreateTempTableAsync().ConfigureAwait(false);
      await UserRight_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserRightUpdateFromTempAsync().ConfigureAwait(false);
      await UserRightDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserRightBulkDeleteAsync(ICollection<IUserRightDto> dtos)
    {
      await UserRightCreateTempTableAsync().ConfigureAwait(false);
      await UserRight_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserRightDeleteFromTempAsync().ConfigureAwait(false);
      await UserRightDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task UserRightBulkInsertAsync(string tableName, ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(UserRightGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task UserRightMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserRightUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserRightDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserRightCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task UserRightDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void UserRightBulkInsert(ICollection<IUserRightDto> dtos)
    {
      UserRightBulkInsert(dtos, false);
    }
    public void UserRightBulkInsert(ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      UserRightBulkInsert("[core].[UserRight]", dtos, identityInsert);
    }
    public void UserRight_TempBulkInsert(ICollection<IUserRightDto> dtos)
    {
      UserRight_TempBulkInsert(dtos, false);
    }
    public void UserRight_TempBulkInsert(ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      UserRightBulkInsert("[core].[UserRight_Temp]", dtos, identityInsert);
    }
    public void UserRightBulkMerge(ICollection<IUserRightDto> dtos)
    {
      UserRightBulkMerge(dtos, false);
    }
    public void UserRightBulkMerge(ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      UserRightCreateTempTable();
      UserRight_TempBulkInsert(dtos, identityInsert);
      UserRightMergeFromTemp();
      UserRightDropTempTable();
    }
    public void UserRightBulkUpdate(ICollection<IUserRightDto> dtos)
    {
      UserRightCreateTempTable();
      UserRight_TempBulkInsert(dtos, true);
      UserRightUpdateFromTemp();
      UserRightDropTempTable();
    }
    public void UserRightBulkDelete(ICollection<IUserRightDto> dtos)
    {
      UserRightCreateTempTable();
      UserRight_TempBulkInsert(dtos, true);
      UserRightDeleteFromTemp();
      UserRightDropTempTable();
    }
    private void UserRightBulkInsert(string tableName, ICollection<IUserRightDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(UserRightGetListAsDataTable(tableName, dtos));
        };
    }
    private void UserRightMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserRightUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserRightDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserRightCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void UserRightDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetUserRightMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[UserRight] ON;
          MERGE INTO [core].[UserRight] AS Target
          USING [core].[UserRight_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Right]
                  ,[Description]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Right]
                 ,Source.[Description]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Right] = Source.[Right]
                ,[Description] = Source.[Description]
          ;
          SET IDENTITY_INSERT [core].[UserRight] OFF;
      ";
    }
    private string GetUserRightUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[Right] = Source.[Right]
                ,Target.[Description] = Source.[Description]
          FROM [core].[UserRight] AS Target
          INNER JOIN [core].[UserRight_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserRightDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[UserRight] AS Target
          INNER JOIN [core].[UserRight_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserRightCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[UserRight_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[UserRight_Temp];
        
                  CREATE TABLE [core].[UserRight_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkUserRight_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[Right]   nvarchar(1000)   NULL
                     ,[Description]   nvarchar(4000)   NULL
                  );
      ";
    }
    private string GetUserRightDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[UserRight_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[UserRight_Temp];
                ";
    }
    private DataTable UserRightGetListAsDataTable(string tableName, ICollection<IUserRightDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcRight = new DataColumn("Right", typeof(string));
      DataColumn dtcDescription = new DataColumn("Description", typeof(string));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcRight.AllowDBNull = false;
      dtcDescription.AllowDBNull = false;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcRight);
      table.Columns.Add(dtcDescription);
      
      foreach (UserRightDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.Right
          ,row.Description
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> UserRightHasChangedAsync(IUserRightDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> UserRightHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserRightDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserRightDto dtoDb = await UserRightGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool UserRightHasChanged(IUserRightDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserRightHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool UserRightHasChanged(SqlConnection con, SqlCommand cmd, IUserRightDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserRightDto dtoDb = UserRightGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(IUserRightDto dto, IUserRightDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.Right == dtoDb.Right;
      ret = ret && dto.Description == dtoDb.Description;
      return !ret;
    }
    #endregion
  }
}


