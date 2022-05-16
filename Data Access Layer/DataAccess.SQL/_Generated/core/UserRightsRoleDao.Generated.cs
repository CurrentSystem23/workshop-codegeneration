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
  public partial class UserRightsRoleDao : Dao, IUserRightsRoleDao, IUserRightsRoleInternalDao
  {
    private readonly ILogger<UserRightsRoleDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  UserRightsRoleDao(IServiceProvider provider, ILogger<UserRightsRoleDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> UserRightsRoleGetCountAsync()
    {
      return await UserRightsRoleGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> UserRightsRoleGetCountAsync(WhereClause whereClause)
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
            FROM [core].[UserRightsRole] pv
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
    public async Task<IUserRightsRoleDto> UserRightsRoleGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightsRoleGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserRightsRoleDto> UserRightsRoleGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserRightsRoleDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(params OrderUserRightsRole[] orderBy)
    {
      return await UserRightsRoleGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      return await UserRightsRoleGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(WhereClause whereClause, bool distinct, params OrderUserRightsRole[] orderBy)
    {
      return await UserRightsRoleGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightsRoleGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await UserRightsRoleGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserRightsRoleDto>> UserRightsRoleGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      ICollection<IUserRightsRoleDto> dtos = new List<IUserRightsRoleDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long UserRightsRoleGetCount()
    {
      return UserRightsRoleGetCount(new WhereClause());
    }
    public long UserRightsRoleGetCount(WhereClause whereClause)
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
            FROM [core].[UserRightsRole] pv
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
    public IUserRightsRoleDto UserRightsRoleGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserRightsRoleGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public IUserRightsRoleDto UserRightsRoleGet(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserRightsRoleDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<IUserRightsRoleDto> UserRightsRoleGets(params OrderUserRightsRole[] orderBy)
    {
      return UserRightsRoleGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IUserRightsRoleDto> UserRightsRoleGets(int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      return UserRightsRoleGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IUserRightsRoleDto> UserRightsRoleGets(WhereClause whereClause, bool distinct, params OrderUserRightsRole[] orderBy)
    {
      return UserRightsRoleGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IUserRightsRoleDto> UserRightsRoleGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserRightsRoleGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserRightsRoleDto> UserRightsRoleGets(SqlConnection con, SqlCommand cmd)
    {
      return UserRightsRoleGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IUserRightsRoleDto> UserRightsRoleGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUserRightsRole[] orderBy)
    {
      ICollection<IUserRightsRoleDto> dtos = new List<IUserRightsRoleDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserRightsRole[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserRightsRole[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUserRightsRole[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[Role]
              ,pt.[Description]
          FROM [core].[UserRightsRole] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderUserRightsRole[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderUserRightsRole order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderUserRightsRole), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderUserRightsRole[] orderBy)
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
    private IUserRightsRoleDto GetRead(SqlDataReader reader)
    {
      IUserRightsRoleDto dto = new UserRightsRoleDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.Role = reader.GetString(4);
      dto.Description = reader.GetString(5);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<IUserRightsRoleHistDto>> UserRightsRoleHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightsRoleHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserRightsRoleHistDto>> UserRightsRoleHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserRightsRoleHistDto> dtos = new List<IUserRightsRoleHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<IUserRightsRoleHistDto> UserRightsRoleHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightsRoleHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserRightsRoleHistDto> UserRightsRoleHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserRightsRoleHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<IUserRightsRoleHistDto> UserRightsRoleHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserRightsRoleHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserRightsRoleHistDto> UserRightsRoleHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserRightsRoleHistDto> dtos = new List<IUserRightsRoleHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistGets)}");
        throw;
      }
      return dtos;
    }
    public IUserRightsRoleHistDto UserRightsRoleHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserRightsRoleHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public IUserRightsRoleHistDto UserRightsRoleHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserRightsRoleHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistEntryGet)}");
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
              ,[Role]
              ,[Description]
          FROM [core].[UserRightsRole_Hist]
        WHERE [Id] = @id";
    }
    private IUserRightsRoleHistDto GetHistRead(SqlDataReader reader)
    {
      IUserRightsRoleHistDto dto = new UserRightsRoleHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.Role = reader.GetString(6);
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
              ,[Role]
              ,[Description]
          FROM [core].[UserRightsRole_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task UserRightsRoleHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightsRoleHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightsRoleHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightsRoleHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightsRoleHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistDeleteAsync)}");
        throw;
      }
    }
    public async Task UserRightsRoleHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserRightsRoleHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserRightsRoleHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void UserRightsRoleHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserRightsRoleHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserRightsRoleHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistDelete)}");
        throw;
      }
    }
    public void UserRightsRoleHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleHistDelete)}");
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
              DELETE FROM [core].[UserRightsRole_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[UserRightsRole_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task UserRightsRoleSaveAsync(IUserRightsRoleDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightsRoleSaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightsRoleSaveAsync(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleSaveAsync)}");
        throw;
      }
    }
    public async Task UserRightsRoleMergeAsync(IUserRightsRoleDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightsRoleMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightsRoleMergeAsync(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserRightsRoleSave(IUserRightsRoleDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightsRoleSave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserRightsRoleSave(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleSave)}");
        throw;
      }
    }
    public void UserRightsRoleMerge(IUserRightsRoleDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightsRoleMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserRightsRoleMerge(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, IUserRightsRoleDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value =  dto.Role ?? string.Empty;
      cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value =  dto.Description ?? string.Empty;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[UserRightsRole] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[Role]
                   ,[Description]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@Role
                   ,@Description
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[UserRightsRole]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[Role] = @Role
                   ,[Description] = @Description
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[UserRightsRole] ON;
          MERGE INTO [core].[UserRightsRole] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @Role, @Description)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Role],[Description])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Role]
                  ,[Description]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Role]
                 ,Source.[Description]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Role] = Source.[Role]
                ,[Description] = Source.[Description]
          ;
          SET IDENTITY_INSERT [core].[UserRightsRole] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task UserRightsRoleDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightsRoleDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightsRoleDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserRightsRoleDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserRightsRoleDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleDeleteAsync)}");
        throw;
      }
    }
    public async Task UserRightsRoleDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserRightsRoleDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightsRoleDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void UserRightsRoleDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserRightsRoleDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserRightsRoleDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleDelete)}");
        throw;
      }
    }
    public void UserRightsRoleDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserRightsRoleDao)}.{nameof(UserRightsRoleDelete)}");
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
              DELETE FROM [core].[UserRightsRole]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[UserRightsRole] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos)
    {
      await UserRightsRoleBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserRightsRoleBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      await UserRightsRoleBulkInsertAsync("[core].[UserRightsRole]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos)
    {
      await UserRightsRole_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserRightsRole_TempBulkInsertAsync(ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      await UserRightsRoleBulkInsertAsync("[core].[UserRightsRole_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleDto> dtos)
    {
      await UserRightsRoleBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserRightsRoleBulkMergeAsync(ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      await UserRightsRoleCreateTempTableAsync().ConfigureAwait(false);
      await UserRightsRole_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await UserRightsRoleMergeFromTempAsync().ConfigureAwait(false);
      await UserRightsRoleDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserRightsRoleBulkUpdateAsync(ICollection<IUserRightsRoleDto> dtos)
    {
      await UserRightsRoleCreateTempTableAsync().ConfigureAwait(false);
      await UserRightsRole_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserRightsRoleUpdateFromTempAsync().ConfigureAwait(false);
      await UserRightsRoleDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserRightsRoleBulkDeleteAsync(ICollection<IUserRightsRoleDto> dtos)
    {
      await UserRightsRoleCreateTempTableAsync().ConfigureAwait(false);
      await UserRightsRole_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserRightsRoleDeleteFromTempAsync().ConfigureAwait(false);
      await UserRightsRoleDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task UserRightsRoleBulkInsertAsync(string tableName, ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(UserRightsRoleGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task UserRightsRoleMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserRightsRoleUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserRightsRoleDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserRightsRoleCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task UserRightsRoleDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void UserRightsRoleBulkInsert(ICollection<IUserRightsRoleDto> dtos)
    {
      UserRightsRoleBulkInsert(dtos, false);
    }
    public void UserRightsRoleBulkInsert(ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      UserRightsRoleBulkInsert("[core].[UserRightsRole]", dtos, identityInsert);
    }
    public void UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleDto> dtos)
    {
      UserRightsRole_TempBulkInsert(dtos, false);
    }
    public void UserRightsRole_TempBulkInsert(ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      UserRightsRoleBulkInsert("[core].[UserRightsRole_Temp]", dtos, identityInsert);
    }
    public void UserRightsRoleBulkMerge(ICollection<IUserRightsRoleDto> dtos)
    {
      UserRightsRoleBulkMerge(dtos, false);
    }
    public void UserRightsRoleBulkMerge(ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      UserRightsRoleCreateTempTable();
      UserRightsRole_TempBulkInsert(dtos, identityInsert);
      UserRightsRoleMergeFromTemp();
      UserRightsRoleDropTempTable();
    }
    public void UserRightsRoleBulkUpdate(ICollection<IUserRightsRoleDto> dtos)
    {
      UserRightsRoleCreateTempTable();
      UserRightsRole_TempBulkInsert(dtos, true);
      UserRightsRoleUpdateFromTemp();
      UserRightsRoleDropTempTable();
    }
    public void UserRightsRoleBulkDelete(ICollection<IUserRightsRoleDto> dtos)
    {
      UserRightsRoleCreateTempTable();
      UserRightsRole_TempBulkInsert(dtos, true);
      UserRightsRoleDeleteFromTemp();
      UserRightsRoleDropTempTable();
    }
    private void UserRightsRoleBulkInsert(string tableName, ICollection<IUserRightsRoleDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(UserRightsRoleGetListAsDataTable(tableName, dtos));
        };
    }
    private void UserRightsRoleMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserRightsRoleUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserRightsRoleDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserRightsRoleCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void UserRightsRoleDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserRightsRoleDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetUserRightsRoleMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[UserRightsRole] ON;
          MERGE INTO [core].[UserRightsRole] AS Target
          USING [core].[UserRightsRole_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[Role]
                  ,[Description]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[Role]
                 ,Source.[Description]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[Role] = Source.[Role]
                ,[Description] = Source.[Description]
          ;
          SET IDENTITY_INSERT [core].[UserRightsRole] OFF;
      ";
    }
    private string GetUserRightsRoleUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[Role] = Source.[Role]
                ,Target.[Description] = Source.[Description]
          FROM [core].[UserRightsRole] AS Target
          INNER JOIN [core].[UserRightsRole_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserRightsRoleDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[UserRightsRole] AS Target
          INNER JOIN [core].[UserRightsRole_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserRightsRoleCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[UserRightsRole_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[UserRightsRole_Temp];
        
                  CREATE TABLE [core].[UserRightsRole_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkUserRightsRole_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[Role]   nvarchar(1000)   NULL
                     ,[Description]   nvarchar(4000)   NULL
                  );
      ";
    }
    private string GetUserRightsRoleDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[UserRightsRole_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[UserRightsRole_Temp];
                ";
    }
    private DataTable UserRightsRoleGetListAsDataTable(string tableName, ICollection<IUserRightsRoleDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcRole = new DataColumn("Role", typeof(string));
      DataColumn dtcDescription = new DataColumn("Description", typeof(string));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcRole.AllowDBNull = false;
      dtcDescription.AllowDBNull = false;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcRole);
      table.Columns.Add(dtcDescription);
      
      foreach (UserRightsRoleDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.Role
          ,row.Description
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> UserRightsRoleHasChangedAsync(IUserRightsRoleDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserRightsRoleHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> UserRightsRoleHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserRightsRoleDto dtoDb = await UserRightsRoleGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool UserRightsRoleHasChanged(IUserRightsRoleDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserRightsRoleHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool UserRightsRoleHasChanged(SqlConnection con, SqlCommand cmd, IUserRightsRoleDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserRightsRoleDto dtoDb = UserRightsRoleGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(IUserRightsRoleDto dto, IUserRightsRoleDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.Role == dtoDb.Role;
      ret = ret && dto.Description == dtoDb.Description;
      return !ret;
    }
    #endregion
  }
}


