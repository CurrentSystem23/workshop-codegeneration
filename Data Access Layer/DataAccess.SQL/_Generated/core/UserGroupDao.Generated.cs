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
  public partial class UserGroupDao : Dao, IUserGroupDao, IUserGroupInternalDao
  {
    private readonly ILogger<UserGroupDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  UserGroupDao(IServiceProvider provider, ILogger<UserGroupDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> UserGroupGetCountAsync()
    {
      return await UserGroupGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> UserGroupGetCountAsync(WhereClause whereClause)
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
            FROM [core].[UserGroup] pv
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
    public async Task<IUserGroupDto> UserGroupGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserGroupGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserGroupDto> UserGroupGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserGroupDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(params OrderUserGroup[] orderBy)
    {
      return await UserGroupGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      return await UserGroupGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(WhereClause whereClause, bool distinct, params OrderUserGroup[] orderBy)
    {
      return await UserGroupGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserGroupGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await UserGroupGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserGroupDto>> UserGroupGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      ICollection<IUserGroupDto> dtos = new List<IUserGroupDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long UserGroupGetCount()
    {
      return UserGroupGetCount(new WhereClause());
    }
    public long UserGroupGetCount(WhereClause whereClause)
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
            FROM [core].[UserGroup] pv
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
    public IUserGroupDto UserGroupGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserGroupGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public IUserGroupDto UserGroupGet(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserGroupDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<IUserGroupDto> UserGroupGets(params OrderUserGroup[] orderBy)
    {
      return UserGroupGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IUserGroupDto> UserGroupGets(int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      return UserGroupGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IUserGroupDto> UserGroupGets(WhereClause whereClause, bool distinct, params OrderUserGroup[] orderBy)
    {
      return UserGroupGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IUserGroupDto> UserGroupGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserGroupGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserGroupDto> UserGroupGets(SqlConnection con, SqlCommand cmd)
    {
      return UserGroupGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IUserGroupDto> UserGroupGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserGroup[] orderBy)
    {
      ICollection<IUserGroupDto> dtos = new List<IUserGroupDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserGroup[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserGroup[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserGroup[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[Group]
              ,pt.[Description]
          FROM [core].[UserGroup] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderUserGroup[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderUserGroup order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderUserGroup), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderUserGroup[] orderBy)
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
    private IUserGroupDto GetRead(SqlDataReader reader)
    {
      IUserGroupDto dto = new UserGroupDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.Group = reader.GetString(4);
      dto.Description = reader.GetString(5);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<IUserGroupHistDto>> UserGroupHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserGroupHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserGroupHistDto>> UserGroupHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserGroupHistDto> dtos = new List<IUserGroupHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<IUserGroupHistDto> UserGroupHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserGroupHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserGroupHistDto> UserGroupHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserGroupHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<IUserGroupHistDto> UserGroupHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserGroupHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserGroupHistDto> UserGroupHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserGroupHistDto> dtos = new List<IUserGroupHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistGets)}");
        throw;
      }
      return dtos;
    }
    public IUserGroupHistDto UserGroupHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserGroupHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public IUserGroupHistDto UserGroupHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserGroupHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistEntryGet)}");
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
              ,[Group]
              ,[Description]
          FROM [core].[UserGroup_Hist]
        WHERE [Id] = @id";
    }
    private IUserGroupHistDto GetHistRead(SqlDataReader reader)
    {
      IUserGroupHistDto dto = new UserGroupHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.Group = reader.GetString(6);
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
              ,[Group]
              ,[Description]
          FROM [core].[UserGroup_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task UserGroupHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserGroupHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserGroupHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserGroupHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserGroupHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistDeleteAsync)}");
        throw;
      }
    }
    public async Task UserGroupHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserGroupHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserGroupHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void UserGroupHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserGroupHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserGroupHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistDelete)}");
        throw;
      }
    }
    public void UserGroupHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupHistDelete)}");
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
              DELETE FROM [core].[UserGroup_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[UserGroup_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task UserGroupSaveAsync(IUserGroupDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserGroupSaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserGroupSaveAsync(SqlConnection con, SqlCommand cmd, IUserGroupDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupSaveAsync)}");
        throw;
      }
    }
    public async Task UserGroupMergeAsync(IUserGroupDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserGroupMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserGroupMergeAsync(SqlConnection con, SqlCommand cmd, IUserGroupDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserGroupSave(IUserGroupDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserGroupSave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserGroupSave(SqlConnection con, SqlCommand cmd, IUserGroupDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupSave)}");
        throw;
      }
    }
    public void UserGroupMerge(IUserGroupDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserGroupMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserGroupMerge(SqlConnection con, SqlCommand cmd, IUserGroupDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, IUserGroupDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@Group", SqlDbType.NVarChar).Value =  dto.Group ?? string.Empty;
      cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value =  dto.Description ?? string.Empty;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[UserGroup] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[Group]
                   ,[Description]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@Group
                   ,@Description
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[UserGroup]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[Group] = @Group
                   ,[Description] = @Description
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[UserGroup] ON;
          MERGE INTO [core].[UserGroup] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @Group, @Description)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Group],[Description])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Group]
                  ,[Description]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Group]
                 ,Source.[Description]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Group] = Source.[Group]
                ,[Description] = Source.[Description]
          ;
          SET IDENTITY_INSERT [core].[UserGroup] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task UserGroupDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserGroupDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserGroupDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserGroupDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserGroupDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupDeleteAsync)}");
        throw;
      }
    }
    public async Task UserGroupDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserGroupDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserGroupDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void UserGroupDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserGroupDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserGroupDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupDelete)}");
        throw;
      }
    }
    public void UserGroupDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserGroupDao)}.{nameof(UserGroupDelete)}");
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
              DELETE FROM [core].[UserGroup]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[UserGroup] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task UserGroupBulkInsertAsync(ICollection<IUserGroupDto> dtos)
    {
      await UserGroupBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserGroupBulkInsertAsync(ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      await UserGroupBulkInsertAsync("[core].[UserGroup]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task UserGroup_TempBulkInsertAsync(ICollection<IUserGroupDto> dtos)
    {
      await UserGroup_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserGroup_TempBulkInsertAsync(ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      await UserGroupBulkInsertAsync("[core].[UserGroup_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task UserGroupBulkMergeAsync(ICollection<IUserGroupDto> dtos)
    {
      await UserGroupBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserGroupBulkMergeAsync(ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      await UserGroupCreateTempTableAsync().ConfigureAwait(false);
      await UserGroup_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await UserGroupMergeFromTempAsync().ConfigureAwait(false);
      await UserGroupDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserGroupBulkUpdateAsync(ICollection<IUserGroupDto> dtos)
    {
      await UserGroupCreateTempTableAsync().ConfigureAwait(false);
      await UserGroup_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserGroupUpdateFromTempAsync().ConfigureAwait(false);
      await UserGroupDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserGroupBulkDeleteAsync(ICollection<IUserGroupDto> dtos)
    {
      await UserGroupCreateTempTableAsync().ConfigureAwait(false);
      await UserGroup_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserGroupDeleteFromTempAsync().ConfigureAwait(false);
      await UserGroupDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task UserGroupBulkInsertAsync(string tableName, ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(UserGroupGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task UserGroupMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserGroupUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserGroupDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserGroupCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task UserGroupDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void UserGroupBulkInsert(ICollection<IUserGroupDto> dtos)
    {
      UserGroupBulkInsert(dtos, false);
    }
    public void UserGroupBulkInsert(ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      UserGroupBulkInsert("[core].[UserGroup]", dtos, identityInsert);
    }
    public void UserGroup_TempBulkInsert(ICollection<IUserGroupDto> dtos)
    {
      UserGroup_TempBulkInsert(dtos, false);
    }
    public void UserGroup_TempBulkInsert(ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      UserGroupBulkInsert("[core].[UserGroup_Temp]", dtos, identityInsert);
    }
    public void UserGroupBulkMerge(ICollection<IUserGroupDto> dtos)
    {
      UserGroupBulkMerge(dtos, false);
    }
    public void UserGroupBulkMerge(ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      UserGroupCreateTempTable();
      UserGroup_TempBulkInsert(dtos, identityInsert);
      UserGroupMergeFromTemp();
      UserGroupDropTempTable();
    }
    public void UserGroupBulkUpdate(ICollection<IUserGroupDto> dtos)
    {
      UserGroupCreateTempTable();
      UserGroup_TempBulkInsert(dtos, true);
      UserGroupUpdateFromTemp();
      UserGroupDropTempTable();
    }
    public void UserGroupBulkDelete(ICollection<IUserGroupDto> dtos)
    {
      UserGroupCreateTempTable();
      UserGroup_TempBulkInsert(dtos, true);
      UserGroupDeleteFromTemp();
      UserGroupDropTempTable();
    }
    private void UserGroupBulkInsert(string tableName, ICollection<IUserGroupDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(UserGroupGetListAsDataTable(tableName, dtos));
        };
    }
    private void UserGroupMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserGroupUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserGroupDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserGroupCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void UserGroupDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserGroupDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetUserGroupMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[UserGroup] ON;
          MERGE INTO [core].[UserGroup] AS Target
          USING [core].[UserGroup_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Group]
                  ,[Description]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Group]
                 ,Source.[Description]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Group] = Source.[Group]
                ,[Description] = Source.[Description]
          ;
          SET IDENTITY_INSERT [core].[UserGroup] OFF;
      ";
    }
    private string GetUserGroupUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[Group] = Source.[Group]
                ,Target.[Description] = Source.[Description]
          FROM [core].[UserGroup] AS Target
          INNER JOIN [core].[UserGroup_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserGroupDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[UserGroup] AS Target
          INNER JOIN [core].[UserGroup_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserGroupCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[UserGroup_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[UserGroup_Temp];
        
                  CREATE TABLE [core].[UserGroup_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkUserGroup_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[Group]   nvarchar(1000)   NULL
                     ,[Description]   nvarchar(4000)   NULL
                  );
      ";
    }
    private string GetUserGroupDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[UserGroup_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[UserGroup_Temp];
                ";
    }
    private DataTable UserGroupGetListAsDataTable(string tableName, ICollection<IUserGroupDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcGroup = new DataColumn("Group", typeof(string));
      DataColumn dtcDescription = new DataColumn("Description", typeof(string));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcGroup.AllowDBNull = false;
      dtcDescription.AllowDBNull = false;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcGroup);
      table.Columns.Add(dtcDescription);
      
      foreach (UserGroupDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.Group
          ,row.Description
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> UserGroupHasChangedAsync(IUserGroupDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserGroupHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> UserGroupHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserGroupDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserGroupDto dtoDb = await UserGroupGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool UserGroupHasChanged(IUserGroupDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserGroupHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool UserGroupHasChanged(SqlConnection con, SqlCommand cmd, IUserGroupDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserGroupDto dtoDb = UserGroupGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(IUserGroupDto dto, IUserGroupDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.Group == dtoDb.Group;
      ret = ret && dto.Description == dtoDb.Description;
      return !ret;
    }
    #endregion
  }
}


