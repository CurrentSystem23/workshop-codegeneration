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
  public partial class UserDao : Dao, IUserDao, IUserInternalDao
  {
    private readonly ILogger<UserDao> _logger;
    private readonly IServiceProvider _provider;
    #region Constructor
    public  UserDao(IServiceProvider provider, ILogger<UserDao> logger = null)
    {
      _logger = logger;
      _provider = provider;
    }
    #endregion
    #region Get
    #region async
    public async Task<long> UserGetCountAsync()
    {
      return await UserGetCountAsync(new WhereClause()).ConfigureAwait(false);
    }
    public async Task<long> UserGetCountAsync(WhereClause whereClause)
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
            FROM [core].[User] pv
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
    public async Task<IUserDto> UserGetAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserGetAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserDto> UserGetAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserGetAsync)}");
        throw;
      }
      return dto;
    }
    public async Task<ICollection<IUserDto>> UserGetsAsync(params OrderUser[] orderBy)
    {
      return await UserGetsAsync(new WhereClause(), false, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserDto>> UserGetsAsync(int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      return await UserGetsAsync(new WhereClause(), false, pageNum, pageSize, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserDto>> UserGetsAsync(WhereClause whereClause, bool distinct, params OrderUser[] orderBy)
    {
      return await UserGetsAsync(whereClause, distinct, null, null, orderBy).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserDto>> UserGetsAsync(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserGetsAsync(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserDto>> UserGetsAsync(SqlConnection con, SqlCommand cmd)
    {
      return await UserGetsAsync(con, cmd, new WhereClause(), false, null, null).ConfigureAwait(false);
    }
    public async Task<ICollection<IUserDto>> UserGetsAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      ICollection<IUserDto> dtos = new List<IUserDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserGetsAsync)}");
        throw;
      }
      return dtos;
    }
    #endregion
    #region sync
    public long UserGetCount()
    {
      return UserGetCount(new WhereClause());
    }
    public long UserGetCount(WhereClause whereClause)
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
            FROM [core].[User] pv
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
    public IUserDto UserGet(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserGet(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public IUserDto UserGet(SqlConnection con, SqlCommand cmd, long id)
    {
      IUserDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserGet)}");
        throw;
      }
      return dto;
    }
    public ICollection<IUserDto> UserGets(params OrderUser[] orderBy)
    {
      return UserGets(new WhereClause(), false, null, null, orderBy);
    }
    public ICollection<IUserDto> UserGets(int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      return UserGets(new WhereClause(), false, pageNum, pageSize, orderBy);
    }
    public ICollection<IUserDto> UserGets(WhereClause whereClause, bool distinct, params OrderUser[] orderBy)
    {
      return UserGets(whereClause, distinct, null, null, orderBy);
    }
    public ICollection<IUserDto> UserGets(WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserGets(con, cmd, whereClause, distinct, pageNum, pageSize, orderBy);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserDto> UserGets(SqlConnection con, SqlCommand cmd)
    {
      return UserGets(con, cmd, new WhereClause(), false, null, null);
    }
    public ICollection<IUserDto> UserGets(SqlConnection con, SqlCommand cmd, WhereClause whereClause, bool distinct, int? pageNum, int? pageSize, params OrderUser[] orderBy)
    {
      ICollection<IUserDto> dtos = new List<IUserDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserGets)}");
        throw;
      }
      return dtos;
    }
    #endregion
    private void GetPrepareCommand(SqlCommand cmd, long? id = null, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUser[] orderBy)
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
    private void GetPrepareCommand(SqlCommand cmd, WhereClause whereClause, long? id = null, bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUser[] orderBy)
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
    private string GetSqlStatement(long? id, string where = "", bool distinct = false, int? pageNum = null, int? pageSize = null, params OrderUser[] orderBy)
    {
      string sql =  $@"
        SELECT {(distinct ? "DISTINCT ": "")}[core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate])
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[TenantId]
              ,pt.[Login]
              ,pt.[Password]
              ,pt.[PasswordSalt]
              ,pt.[Email]
              ,pt.[State]
              ,pt.[FailedLoginCount]
              ,pt.[LastLogin]
              ,pt.[LastPasswordChange]
              ,pt.[DomainLogin]
              ,pt.[BusinessPartnerId]
              ,pt.[ConditionsId]
              ,pt.[ConditionsFixed]
              ,pt.[PrivacyPolicyId]
              ,pt.[PrivacyPolicyFixed]
              ,pt.[PasswordLinkExtension]
              ,pt.[PasswordDateOfExpiry]
              ,pt.[NewEmail]
              ,pt.[EmailLinkExtension]
              ,pt.[EmailDateOfExpiry]
          FROM [core].[User] AS pt
      ";
      if (id != null)
        sql += "WHERE pt.[Id] = @id";
      else
        sql += where;
      sql += GetOrderBy(orderBy);
      sql += GetPagination(pageNum, pageSize, orderBy);
      return sql;
    }
    private string GetOrderBy(params OrderUser[] orderBy)
    {
      string result = string.Empty;
      if (orderBy == null)
        return result;
      bool first = true;
      foreach (OrderUser order in orderBy)
      {
        string orderName = Enum.GetName(typeof(OrderUser), order);
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
    private string GetPagination(int? pageNum = null, int? pageSize = null, params OrderUser[] orderBy)
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
    private IUserDto GetRead(SqlDataReader reader)
    {
      IUserDto dto = new UserDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Id = reader.GetInt64(1);
      dto.ModifiedDate = reader.GetDateTime(2);
      dto.ModifiedUser = reader.GetInt64(3);
      dto.TenantId = reader.GetInt64(4);
      dto.Login = reader.GetString(5);
      dto.Password = reader.GetString(6);
      dto.PasswordSalt = reader.GetString(7);
      dto.Email = reader.GetString(8);
      dto.State = reader.GetInt64(9);
      dto.FailedLoginCount = reader.GetInt64(10);
      dto.LastLogin = reader.GetDateTimeNullableFromNullableDbValue(11);
      dto.LastPasswordChange = reader.GetDateTimeNullableFromNullableDbValue(12);
      dto.DomainLogin = reader.GetString(13);
      dto.BusinessPartnerId = reader.GetInt64(14);
      dto.ConditionsId = reader.GetInt64(15);
      dto.ConditionsFixed = reader.GetInt64(16);
      dto.PrivacyPolicyId = reader.GetInt64(17);
      dto.PrivacyPolicyFixed = reader.GetInt64(18);
      dto.PasswordLinkExtension = reader.GetGuidNullableFromNullableDbValue(19);
      dto.PasswordDateOfExpiry = reader.GetDateTimeNullableFromNullableDbValue(20);
      dto.NewEmail = reader.GetStringFromNullableDbValue(21);
      dto.EmailLinkExtension = reader.GetGuidNullableFromNullableDbValue(22);
      dto.EmailDateOfExpiry = reader.GetDateTimeNullableFromNullableDbValue(23);
      return dto;
    }
    #endregion
    #region HistGet
    #region async
    public async Task<ICollection<IUserHistDto>> UserHistGetsAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserHistGetsAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<ICollection<IUserHistDto>> UserHistGetsAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserHistDto> dtos = new List<IUserHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistGetsAsync)}");
        throw;
      }
      return dtos;
    }
    public async Task<IUserHistDto> UserHistEntryGetAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserHistEntryGetAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<IUserHistDto> UserHistEntryGetAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistEntryGetAsync)}");
        throw;
      }
      return dto;
    }
    #endregion
    #region sync
    public ICollection<IUserHistDto> UserHistGets(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserHistGets(con, cmd, id);
          con.Close();
          return ret;
        }
      }
    }
    public ICollection<IUserHistDto> UserHistGets(SqlConnection con, SqlCommand cmd, long id)
    {
      ICollection<IUserHistDto> dtos = new List<IUserHistDto>();
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistGets)}");
        throw;
      }
      return dtos;
    }
    public IUserHistDto UserHistEntryGet(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          var ret = UserHistEntryGet(con, cmd, histId);
          con.Close();
          return ret;
        }
      }
    }
    public IUserHistDto UserHistEntryGet(SqlConnection con, SqlCommand cmd, long histId)
    {
      IUserHistDto dto = null;
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistEntryGet)}");
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
              ,[TenantId]
              ,[Login]
              ,[Password]
              ,[PasswordSalt]
              ,[Email]
              ,[State]
              ,[FailedLoginCount]
              ,[LastLogin]
              ,[LastPasswordChange]
              ,[DomainLogin]
              ,[BusinessPartnerId]
              ,[ConditionsId]
              ,[ConditionsFixed]
              ,[PrivacyPolicyId]
              ,[PrivacyPolicyFixed]
              ,[PasswordLinkExtension]
              ,[PasswordDateOfExpiry]
              ,[NewEmail]
              ,[EmailLinkExtension]
              ,[EmailDateOfExpiry]
          FROM [core].[User_Hist]
        WHERE [Id] = @id";
    }
    private IUserHistDto GetHistRead(SqlDataReader reader)
    {
      IUserHistDto dto = new UserHistDto();
      dto.ModifiedInformation = reader.GetString(0);
      dto.Hist_Id = reader.GetInt64(1);
      dto.Hist_Action = reader.GetString(2);
      dto.Id = reader.GetInt64(3);
      dto.ModifiedDate = reader.GetDateTime(4);
      dto.ModifiedUser = reader.GetInt64(5);
      dto.TenantId = reader.GetInt64(6);
      dto.Login = reader.GetString(7);
      dto.Password = reader.GetString(8);
      dto.PasswordSalt = reader.GetString(9);
      dto.Email = reader.GetString(10);
      dto.State = reader.GetInt64(11);
      dto.FailedLoginCount = reader.GetInt64(12);
      dto.LastLogin = reader.GetDateTimeNullableFromNullableDbValue(13);
      dto.LastPasswordChange = reader.GetDateTimeNullableFromNullableDbValue(14);
      dto.DomainLogin = reader.GetString(15);
      dto.BusinessPartnerId = reader.GetInt64(16);
      dto.ConditionsId = reader.GetInt64(17);
      dto.ConditionsFixed = reader.GetInt64(18);
      dto.PrivacyPolicyId = reader.GetInt64(19);
      dto.PrivacyPolicyFixed = reader.GetInt64(20);
      dto.PasswordLinkExtension = reader.GetGuidNullableFromNullableDbValue(21);
      dto.PasswordDateOfExpiry = reader.GetDateTimeNullableFromNullableDbValue(22);
      dto.NewEmail = reader.GetStringFromNullableDbValue(23);
      dto.EmailLinkExtension = reader.GetGuidNullableFromNullableDbValue(24);
      dto.EmailDateOfExpiry = reader.GetDateTimeNullableFromNullableDbValue(25);
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
              ,[TenantId]
              ,[Login]
              ,[Password]
              ,[PasswordSalt]
              ,[Email]
              ,[State]
              ,[FailedLoginCount]
              ,[LastLogin]
              ,[LastPasswordChange]
              ,[DomainLogin]
              ,[BusinessPartnerId]
              ,[ConditionsId]
              ,[ConditionsFixed]
              ,[PrivacyPolicyId]
              ,[PrivacyPolicyFixed]
              ,[PasswordLinkExtension]
              ,[PasswordDateOfExpiry]
              ,[NewEmail]
              ,[EmailLinkExtension]
              ,[EmailDateOfExpiry]
          FROM [core].[User_Hist]
        WHERE [Hist_Id] = @histId";
    }
    #endregion
    #region HistDelete
    #region async
    public async Task UserHistDeleteAsync(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserHistDeleteAsync(con, cmd, histId).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserHistDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserHistDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserHistDeleteAsync(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistDeleteAsync)}");
        throw;
      }
    }
    public async Task UserHistDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserHistDelete(long histId)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserHistDelete(con, cmd, histId);
          con.Close();
        }
      }
    }
    public void UserHistDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.OpenAsync();
          UserHistDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserHistDelete(SqlConnection con, SqlCommand cmd, long histId)
    {
      try
      {
        HistDeletePrepareCommand(cmd, histId);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistDelete)}");
        throw;
      }
    }
    public void UserHistDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        HistDeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserHistDelete)}");
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
              DELETE FROM [core].[User_Hist]
            WHERE [Hist_Id] = @Hist_Id";
    }
    private string HistDeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[User_Hist] AS pt
            {where}";
    }
    #endregion
    #region Save
    #region async
    public async Task UserSaveAsync(IUserDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserSaveAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserSaveAsync(SqlConnection con, SqlCommand cmd, IUserDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserSaveAsync)}");
        throw;
      }
    }
    public async Task UserMergeAsync(IUserDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserMergeAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserMergeAsync(SqlConnection con, SqlCommand cmd, IUserDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserMergeAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserSave(IUserDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserSave(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserSave(SqlConnection con, SqlCommand cmd, IUserDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserSave)}");
        throw;
      }
    }
    public void UserMerge(IUserDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserMerge(con, cmd, dto);
          con.Close();
        }
      }
    }
    public void UserMerge(SqlConnection con, SqlCommand cmd, IUserDto dto)
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
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserMerge)}");
        throw;
      }
    }
    #endregion
    private void SavePrepareCommand(SqlCommand cmd, IUserDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value =  dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value =  dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value =  dto.ModifiedUser;
      cmd.Parameters.Add("@TenantId", SqlDbType.BigInt).Value =  dto.TenantId;
      cmd.Parameters.Add("@Login", SqlDbType.NVarChar).Value =  dto.Login ?? string.Empty;
      cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value =  dto.Password ?? string.Empty;
      cmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value =  dto.PasswordSalt ?? string.Empty;
      cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value =  dto.Email ?? string.Empty;
      cmd.Parameters.Add("@State", SqlDbType.BigInt).Value =  dto.State;
      cmd.Parameters.Add("@FailedLoginCount", SqlDbType.BigInt).Value =  dto.FailedLoginCount;
      cmd.Parameters.Add("@LastLogin", SqlDbType.DateTime2).Value =  dto.LastLogin == null ? (object)DBNull.Value : dto.LastLogin;
      cmd.Parameters.Add("@LastPasswordChange", SqlDbType.DateTime2).Value =  dto.LastPasswordChange == null ? (object)DBNull.Value : dto.LastPasswordChange;
      cmd.Parameters.Add("@DomainLogin", SqlDbType.NVarChar).Value =  dto.DomainLogin ?? string.Empty;
      cmd.Parameters.Add("@BusinessPartnerId", SqlDbType.BigInt).Value =  dto.BusinessPartnerId;
      cmd.Parameters.Add("@ConditionsId", SqlDbType.BigInt).Value =  dto.ConditionsId;
      cmd.Parameters.Add("@ConditionsFixed", SqlDbType.BigInt).Value =  dto.ConditionsFixed;
      cmd.Parameters.Add("@PrivacyPolicyId", SqlDbType.BigInt).Value =  dto.PrivacyPolicyId;
      cmd.Parameters.Add("@PrivacyPolicyFixed", SqlDbType.BigInt).Value =  dto.PrivacyPolicyFixed;
      cmd.Parameters.Add("@PasswordLinkExtension", SqlDbType.UniqueIdentifier).Value =  dto.PasswordLinkExtension == null ? (object)DBNull.Value : dto.PasswordLinkExtension;
      cmd.Parameters.Add("@PasswordDateOfExpiry", SqlDbType.DateTime2).Value =  dto.PasswordDateOfExpiry == null ? (object)DBNull.Value : dto.PasswordDateOfExpiry;
      cmd.Parameters.Add("@NewEmail", SqlDbType.NVarChar).Value =  dto.NewEmail == null ? (object)DBNull.Value : dto.NewEmail;
      cmd.Parameters.Add("@EmailLinkExtension", SqlDbType.UniqueIdentifier).Value =  dto.EmailLinkExtension == null ? (object)DBNull.Value : dto.EmailLinkExtension;
      cmd.Parameters.Add("@EmailDateOfExpiry", SqlDbType.DateTime2).Value =  dto.EmailDateOfExpiry == null ? (object)DBNull.Value : dto.EmailDateOfExpiry;
      cmd.CommandType = CommandType.Text;
    }
    private string SaveInsertSqlStatement()
    {
      return @"
              INSERT INTO [core].[User] (
                    [ModifiedDate]
                   ,[ModifiedUser]
                   ,[TenantId]
                   ,[Login]
                   ,[Password]
                   ,[PasswordSalt]
                   ,[Email]
                   ,[State]
                   ,[FailedLoginCount]
                   ,[LastLogin]
                   ,[LastPasswordChange]
                   ,[DomainLogin]
                   ,[BusinessPartnerId]
                   ,[ConditionsId]
                   ,[ConditionsFixed]
                   ,[PrivacyPolicyId]
                   ,[PrivacyPolicyFixed]
                   ,[PasswordLinkExtension]
                   ,[PasswordDateOfExpiry]
                   ,[NewEmail]
                   ,[EmailLinkExtension]
                   ,[EmailDateOfExpiry]
                   )
             VALUES (
                    @ModifiedDate
                   ,@ModifiedUser
                   ,@TenantId
                   ,@Login
                   ,@Password
                   ,@PasswordSalt
                   ,@Email
                   ,@State
                   ,@FailedLoginCount
                   ,@LastLogin
                   ,@LastPasswordChange
                   ,@DomainLogin
                   ,@BusinessPartnerId
                   ,@ConditionsId
                   ,@ConditionsFixed
                   ,@PrivacyPolicyId
                   ,@PrivacyPolicyFixed
                   ,@PasswordLinkExtension
                   ,@PasswordDateOfExpiry
                   ,@NewEmail
                   ,@EmailLinkExtension
                   ,@EmailDateOfExpiry
                   )
                 SELECT CAST(scope_identity()  AS bigint)";
    }
    private string SaveUpdateSqlStatement()
    {
      return @"
              UPDATE [core].[User]
                 SET
                    [ModifiedDate] = @ModifiedDate
                   ,[ModifiedUser] = @ModifiedUser
                   ,[TenantId] = @TenantId
                   ,[Login] = @Login
                   ,[Password] = @Password
                   ,[PasswordSalt] = @PasswordSalt
                   ,[Email] = @Email
                   ,[State] = @State
                   ,[FailedLoginCount] = @FailedLoginCount
                   ,[LastLogin] = @LastLogin
                   ,[LastPasswordChange] = @LastPasswordChange
                   ,[DomainLogin] = @DomainLogin
                   ,[BusinessPartnerId] = @BusinessPartnerId
                   ,[ConditionsId] = @ConditionsId
                   ,[ConditionsFixed] = @ConditionsFixed
                   ,[PrivacyPolicyId] = @PrivacyPolicyId
                   ,[PrivacyPolicyFixed] = @PrivacyPolicyFixed
                   ,[PasswordLinkExtension] = @PasswordLinkExtension
                   ,[PasswordDateOfExpiry] = @PasswordDateOfExpiry
                   ,[NewEmail] = @NewEmail
                   ,[EmailLinkExtension] = @EmailLinkExtension
                   ,[EmailDateOfExpiry] = @EmailDateOfExpiry
            WHERE [Id] = @Id";
    }
    private string MergeSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[User] ON;
          MERGE INTO [core].[User] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @TenantId, @Login, @Password, @PasswordSalt, @Email, @State, @FailedLoginCount, @LastLogin, @LastPasswordChange, @DomainLogin, @BusinessPartnerId, @ConditionsId, @ConditionsFixed, @PrivacyPolicyId, @PrivacyPolicyFixed, @PasswordLinkExtension, @PasswordDateOfExpiry, @NewEmail, @EmailLinkExtension, @EmailDateOfExpiry)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[TenantId],[Login],[Password],[PasswordSalt],[Email],[State],[FailedLoginCount],[LastLogin],[LastPasswordChange],[DomainLogin],[BusinessPartnerId],[ConditionsId],[ConditionsFixed],[PrivacyPolicyId],[PrivacyPolicyFixed],[PasswordLinkExtension],[PasswordDateOfExpiry],[NewEmail],[EmailLinkExtension],[EmailDateOfExpiry])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[TenantId]
                  ,[Login]
                  ,[Password]
                  ,[PasswordSalt]
                  ,[Email]
                  ,[State]
                  ,[FailedLoginCount]
                  ,[LastLogin]
                  ,[LastPasswordChange]
                  ,[DomainLogin]
                  ,[BusinessPartnerId]
                  ,[ConditionsId]
                  ,[ConditionsFixed]
                  ,[PrivacyPolicyId]
                  ,[PrivacyPolicyFixed]
                  ,[PasswordLinkExtension]
                  ,[PasswordDateOfExpiry]
                  ,[NewEmail]
                  ,[EmailLinkExtension]
                  ,[EmailDateOfExpiry]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[TenantId]
                 ,Source.[Login]
                 ,Source.[Password]
                 ,Source.[PasswordSalt]
                 ,Source.[Email]
                 ,Source.[State]
                 ,Source.[FailedLoginCount]
                 ,Source.[LastLogin]
                 ,Source.[LastPasswordChange]
                 ,Source.[DomainLogin]
                 ,Source.[BusinessPartnerId]
                 ,Source.[ConditionsId]
                 ,Source.[ConditionsFixed]
                 ,Source.[PrivacyPolicyId]
                 ,Source.[PrivacyPolicyFixed]
                 ,Source.[PasswordLinkExtension]
                 ,Source.[PasswordDateOfExpiry]
                 ,Source.[NewEmail]
                 ,Source.[EmailLinkExtension]
                 ,Source.[EmailDateOfExpiry]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[TenantId] = Source.[TenantId]
                ,[Login] = Source.[Login]
                ,[Password] = Source.[Password]
                ,[PasswordSalt] = Source.[PasswordSalt]
                ,[Email] = Source.[Email]
                ,[State] = Source.[State]
                ,[FailedLoginCount] = Source.[FailedLoginCount]
                ,[LastLogin] = Source.[LastLogin]
                ,[LastPasswordChange] = Source.[LastPasswordChange]
                ,[DomainLogin] = Source.[DomainLogin]
                ,[BusinessPartnerId] = Source.[BusinessPartnerId]
                ,[ConditionsId] = Source.[ConditionsId]
                ,[ConditionsFixed] = Source.[ConditionsFixed]
                ,[PrivacyPolicyId] = Source.[PrivacyPolicyId]
                ,[PrivacyPolicyFixed] = Source.[PrivacyPolicyFixed]
                ,[PasswordLinkExtension] = Source.[PasswordLinkExtension]
                ,[PasswordDateOfExpiry] = Source.[PasswordDateOfExpiry]
                ,[NewEmail] = Source.[NewEmail]
                ,[EmailLinkExtension] = Source.[EmailLinkExtension]
                ,[EmailDateOfExpiry] = Source.[EmailDateOfExpiry]
          ;
          SET IDENTITY_INSERT [core].[User] OFF;
      ";
    }
    #endregion
    #region Delete
    #region async
    public async Task UserDeleteAsync(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserDeleteAsync(con, cmd, id).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserDeleteAsync(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          await UserDeleteAsync(con, cmd, whereClause).ConfigureAwait(false);
          con.Close();
        }
      }
    }
    public async Task UserDeleteAsync(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserDeleteAsync)}");
        throw;
      }
    }
    public async Task UserDeleteAsync(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserDeleteAsync)}");
        throw;
      }
    }
    #endregion
    #region sync
    public void UserDelete(long id)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserDelete(con, cmd, id);
          con.Close();
        }
      }
    }
    public void UserDelete(WhereClause whereClause)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          UserDelete(con, cmd, whereClause);
          con.Close();
        }
      }
    }
    public void UserDelete(SqlConnection con, SqlCommand cmd, long id)
    {
      try
      {
        DeletePrepareCommand(cmd, id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserDelete)}");
        throw;
      }
    }
    public void UserDelete(SqlConnection con, SqlCommand cmd, WhereClause whereClause)
    {
      try
      {
        DeletePrepareCommand(cmd, whereClause);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        if (_logger != null) _logger?.LogError(ex, $@"{nameof(UserDao)}.{nameof(UserDelete)}");
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
              DELETE FROM [core].[User]
            WHERE [Id] = @Id";
    }
    private string DeleteSqlStatement(string where)
    {
      return $@"
              DELETE pt FROM [core].[User] AS pt
            {where}";
    }
    #endregion
    #region BulkOperations
    #region async
    public async Task UserBulkInsertAsync(ICollection<IUserDto> dtos)
    {
      await UserBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserBulkInsertAsync(ICollection<IUserDto> dtos, bool identityInsert)
    {
      await UserBulkInsertAsync("[core].[User]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task User_TempBulkInsertAsync(ICollection<IUserDto> dtos)
    {
      await User_TempBulkInsertAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task User_TempBulkInsertAsync(ICollection<IUserDto> dtos, bool identityInsert)
    {
      await UserBulkInsertAsync("[core].[User_Temp]", dtos, identityInsert).ConfigureAwait(false);
    }
    public async Task UserBulkMergeAsync(ICollection<IUserDto> dtos)
    {
      await UserBulkMergeAsync(dtos, false).ConfigureAwait(false);
    }
    public async Task UserBulkMergeAsync(ICollection<IUserDto> dtos, bool identityInsert)
    {
      await UserCreateTempTableAsync().ConfigureAwait(false);
      await User_TempBulkInsertAsync(dtos, identityInsert).ConfigureAwait(false);
      await UserMergeFromTempAsync().ConfigureAwait(false);
      await UserDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserBulkUpdateAsync(ICollection<IUserDto> dtos)
    {
      await UserCreateTempTableAsync().ConfigureAwait(false);
      await User_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserUpdateFromTempAsync().ConfigureAwait(false);
      await UserDropTempTableAsync().ConfigureAwait(false);
    }
    public async Task UserBulkDeleteAsync(ICollection<IUserDto> dtos)
    {
      await UserCreateTempTableAsync().ConfigureAwait(false);
      await User_TempBulkInsertAsync(dtos, true).ConfigureAwait(false);
      await UserDeleteFromTempAsync().ConfigureAwait(false);
      await UserDropTempTableAsync().ConfigureAwait(false);
    }
    private async Task UserBulkInsertAsync(string tableName, ICollection<IUserDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(UserGetListAsDataTable(tableName, dtos)).ConfigureAwait(false);
        };
    }
    private async Task UserMergeFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserMergeFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserUpdateFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserUpdateFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserDeleteFromTempAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserDeleteFromTempSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
        };
    }
    private async Task UserCreateTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserCreateTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    private async Task UserDropTempTableAsync()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserDropTempTableSqlStatement();
          await con.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          con.Close();
        }
      }
    }
    #endregion
    #region sync
    public void UserBulkInsert(ICollection<IUserDto> dtos)
    {
      UserBulkInsert(dtos, false);
    }
    public void UserBulkInsert(ICollection<IUserDto> dtos, bool identityInsert)
    {
      UserBulkInsert("[core].[User]", dtos, identityInsert);
    }
    public void User_TempBulkInsert(ICollection<IUserDto> dtos)
    {
      User_TempBulkInsert(dtos, false);
    }
    public void User_TempBulkInsert(ICollection<IUserDto> dtos, bool identityInsert)
    {
      UserBulkInsert("[core].[User_Temp]", dtos, identityInsert);
    }
    public void UserBulkMerge(ICollection<IUserDto> dtos)
    {
      UserBulkMerge(dtos, false);
    }
    public void UserBulkMerge(ICollection<IUserDto> dtos, bool identityInsert)
    {
      UserCreateTempTable();
      User_TempBulkInsert(dtos, identityInsert);
      UserMergeFromTemp();
      UserDropTempTable();
    }
    public void UserBulkUpdate(ICollection<IUserDto> dtos)
    {
      UserCreateTempTable();
      User_TempBulkInsert(dtos, true);
      UserUpdateFromTemp();
      UserDropTempTable();
    }
    public void UserBulkDelete(ICollection<IUserDto> dtos)
    {
      UserCreateTempTable();
      User_TempBulkInsert(dtos, true);
      UserDeleteFromTemp();
      UserDropTempTable();
    }
    private void UserBulkInsert(string tableName, ICollection<IUserDto> dtos, bool identityInsert)
    {
      SqlBulkCopyOptions options = identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default;
      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(DatabaseConnection.ConnectionString, options))
      {
        bulkCopy.BulkCopyTimeout = 3600; // in seconds
          bulkCopy.DestinationTableName = tableName;
        bulkCopy.WriteToServer(UserGetListAsDataTable(tableName, dtos));
        };
    }
    private void UserMergeFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserMergeFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserUpdateFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserUpdateFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserDeleteFromTemp()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserDeleteFromTempSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
        };
    }
    private void UserCreateTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserCreateTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    private void UserDropTempTable()
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = GetUserDropTempTableSqlStatement();
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }
    #endregion
    private string GetUserMergeFromTempSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[User] ON;
          MERGE INTO [core].[User] AS Target
          USING [core].[User_Temp] AS Source
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[TenantId]
                  ,[Login]
                  ,[Password]
                  ,[PasswordSalt]
                  ,[Email]
                  ,[State]
                  ,[FailedLoginCount]
                  ,[LastLogin]
                  ,[LastPasswordChange]
                  ,[DomainLogin]
                  ,[BusinessPartnerId]
                  ,[ConditionsId]
                  ,[ConditionsFixed]
                  ,[PrivacyPolicyId]
                  ,[PrivacyPolicyFixed]
                  ,[PasswordLinkExtension]
                  ,[PasswordDateOfExpiry]
                  ,[NewEmail]
                  ,[EmailLinkExtension]
                  ,[EmailDateOfExpiry]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[TenantId]
                 ,Source.[Login]
                 ,Source.[Password]
                 ,Source.[PasswordSalt]
                 ,Source.[Email]
                 ,Source.[State]
                 ,Source.[FailedLoginCount]
                 ,Source.[LastLogin]
                 ,Source.[LastPasswordChange]
                 ,Source.[DomainLogin]
                 ,Source.[BusinessPartnerId]
                 ,Source.[ConditionsId]
                 ,Source.[ConditionsFixed]
                 ,Source.[PrivacyPolicyId]
                 ,Source.[PrivacyPolicyFixed]
                 ,Source.[PasswordLinkExtension]
                 ,Source.[PasswordDateOfExpiry]
                 ,Source.[NewEmail]
                 ,Source.[EmailLinkExtension]
                 ,Source.[EmailDateOfExpiry]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[TenantId] = Source.[TenantId]
                ,[Login] = Source.[Login]
                ,[Password] = Source.[Password]
                ,[PasswordSalt] = Source.[PasswordSalt]
                ,[Email] = Source.[Email]
                ,[State] = Source.[State]
                ,[FailedLoginCount] = Source.[FailedLoginCount]
                ,[LastLogin] = Source.[LastLogin]
                ,[LastPasswordChange] = Source.[LastPasswordChange]
                ,[DomainLogin] = Source.[DomainLogin]
                ,[BusinessPartnerId] = Source.[BusinessPartnerId]
                ,[ConditionsId] = Source.[ConditionsId]
                ,[ConditionsFixed] = Source.[ConditionsFixed]
                ,[PrivacyPolicyId] = Source.[PrivacyPolicyId]
                ,[PrivacyPolicyFixed] = Source.[PrivacyPolicyFixed]
                ,[PasswordLinkExtension] = Source.[PasswordLinkExtension]
                ,[PasswordDateOfExpiry] = Source.[PasswordDateOfExpiry]
                ,[NewEmail] = Source.[NewEmail]
                ,[EmailLinkExtension] = Source.[EmailLinkExtension]
                ,[EmailDateOfExpiry] = Source.[EmailDateOfExpiry]
          ;
          SET IDENTITY_INSERT [core].[User] OFF;
      ";
    }
    private string GetUserUpdateFromTempSqlStatement()
    {
      return @"
          UPDATE Target
             SET Target.[ModifiedDate] = Source.[ModifiedDate]
                ,Target.[ModifiedUser] = Source.[ModifiedUser]
                ,Target.[TenantId] = Source.[TenantId]
                ,Target.[Login] = Source.[Login]
                ,Target.[Password] = Source.[Password]
                ,Target.[PasswordSalt] = Source.[PasswordSalt]
                ,Target.[Email] = Source.[Email]
                ,Target.[State] = Source.[State]
                ,Target.[FailedLoginCount] = Source.[FailedLoginCount]
                ,Target.[LastLogin] = Source.[LastLogin]
                ,Target.[LastPasswordChange] = Source.[LastPasswordChange]
                ,Target.[DomainLogin] = Source.[DomainLogin]
                ,Target.[BusinessPartnerId] = Source.[BusinessPartnerId]
                ,Target.[ConditionsId] = Source.[ConditionsId]
                ,Target.[ConditionsFixed] = Source.[ConditionsFixed]
                ,Target.[PrivacyPolicyId] = Source.[PrivacyPolicyId]
                ,Target.[PrivacyPolicyFixed] = Source.[PrivacyPolicyFixed]
                ,Target.[PasswordLinkExtension] = Source.[PasswordLinkExtension]
                ,Target.[PasswordDateOfExpiry] = Source.[PasswordDateOfExpiry]
                ,Target.[NewEmail] = Source.[NewEmail]
                ,Target.[EmailLinkExtension] = Source.[EmailLinkExtension]
                ,Target.[EmailDateOfExpiry] = Source.[EmailDateOfExpiry]
          FROM [core].[User] AS Target
          INNER JOIN [core].[User_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserDeleteFromTempSqlStatement()
    {
      return @"
          DELETE Target
          FROM [core].[User] AS Target
          INNER JOIN [core].[User_Temp] AS Source ON Source.[Id] = Target.[Id];
      ";
    }
    private string GetUserCreateTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[User_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[User_Temp];
        
                  CREATE TABLE [core].[User_Temp]
                  (
                     [Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkUser_Temp_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
                     ,[ModifiedDate]   datetime2   NULL
                     ,[ModifiedUser]   bigint   NULL
                     ,[TenantId]   bigint   NULL
                     ,[Login]   nvarchar(255)   NULL
                     ,[Password]   nvarchar(255)   NULL
                     ,[PasswordSalt]   nvarchar(255)   NULL
                     ,[Email]   nvarchar(800)   NULL
                     ,[State]   bigint   NULL
                     ,[FailedLoginCount]   bigint   NULL
                     ,[LastLogin]   datetime2   NULL
                     ,[LastPasswordChange]   datetime2   NULL
                     ,[DomainLogin]   nvarchar(60)   NULL
                     ,[BusinessPartnerId]   bigint   NULL
                     ,[ConditionsId]   bigint   NULL
                     ,[ConditionsFixed]   bigint   NULL
                     ,[PrivacyPolicyId]   bigint   NULL
                     ,[PrivacyPolicyFixed]   bigint   NULL
                     ,[PasswordLinkExtension]   uniqueidentifier   NULL
                     ,[PasswordDateOfExpiry]   datetime2   NULL
                     ,[NewEmail]   nvarchar(800)   NULL
                     ,[EmailLinkExtension]   uniqueidentifier   NULL
                     ,[EmailDateOfExpiry]   datetime2   NULL
                  );
      ";
    }
    private string GetUserDropTempTableSqlStatement()
    {
      return @"
                  IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[core].[User_Temp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                     DROP TABLE [core].[User_Temp];
                ";
    }
    private DataTable UserGetListAsDataTable(string tableName, ICollection<IUserDto> dtos)
    {
      DataTable table = new DataTable(tableName.Split('.').Last());
      
      DataColumn dtcId = new DataColumn("Id", typeof(long));
      DataColumn dtcModifiedDate = new DataColumn("ModifiedDate", typeof(DateTime));
      DataColumn dtcModifiedUser = new DataColumn("ModifiedUser", typeof(long));
      DataColumn dtcTenantId = new DataColumn("TenantId", typeof(long));
      DataColumn dtcLogin = new DataColumn("Login", typeof(string));
      DataColumn dtcPassword = new DataColumn("Password", typeof(string));
      DataColumn dtcPasswordSalt = new DataColumn("PasswordSalt", typeof(string));
      DataColumn dtcEmail = new DataColumn("Email", typeof(string));
      DataColumn dtcState = new DataColumn("State", typeof(long));
      DataColumn dtcFailedLoginCount = new DataColumn("FailedLoginCount", typeof(long));
      DataColumn dtcLastLogin = new DataColumn("LastLogin", typeof(DateTime));
      DataColumn dtcLastPasswordChange = new DataColumn("LastPasswordChange", typeof(DateTime));
      DataColumn dtcDomainLogin = new DataColumn("DomainLogin", typeof(string));
      DataColumn dtcBusinessPartnerId = new DataColumn("BusinessPartnerId", typeof(long));
      DataColumn dtcConditionsId = new DataColumn("ConditionsId", typeof(long));
      DataColumn dtcConditionsFixed = new DataColumn("ConditionsFixed", typeof(long));
      DataColumn dtcPrivacyPolicyId = new DataColumn("PrivacyPolicyId", typeof(long));
      DataColumn dtcPrivacyPolicyFixed = new DataColumn("PrivacyPolicyFixed", typeof(long));
      DataColumn dtcPasswordLinkExtension = new DataColumn("PasswordLinkExtension", typeof(Guid));
      DataColumn dtcPasswordDateOfExpiry = new DataColumn("PasswordDateOfExpiry", typeof(DateTime));
      DataColumn dtcNewEmail = new DataColumn("NewEmail", typeof(string));
      DataColumn dtcEmailLinkExtension = new DataColumn("EmailLinkExtension", typeof(Guid));
      DataColumn dtcEmailDateOfExpiry = new DataColumn("EmailDateOfExpiry", typeof(DateTime));
      
      dtcId.AllowDBNull = false;
      dtcModifiedDate.AllowDBNull = false;
      dtcModifiedUser.AllowDBNull = false;
      dtcTenantId.AllowDBNull = false;
      dtcLogin.AllowDBNull = false;
      dtcPassword.AllowDBNull = false;
      dtcPasswordSalt.AllowDBNull = false;
      dtcEmail.AllowDBNull = false;
      dtcState.AllowDBNull = false;
      dtcFailedLoginCount.AllowDBNull = false;
      dtcLastLogin.AllowDBNull = true;
      dtcLastPasswordChange.AllowDBNull = true;
      dtcDomainLogin.AllowDBNull = false;
      dtcBusinessPartnerId.AllowDBNull = false;
      dtcConditionsId.AllowDBNull = false;
      dtcConditionsFixed.AllowDBNull = false;
      dtcPrivacyPolicyId.AllowDBNull = false;
      dtcPrivacyPolicyFixed.AllowDBNull = false;
      dtcPasswordLinkExtension.AllowDBNull = true;
      dtcPasswordDateOfExpiry.AllowDBNull = true;
      dtcNewEmail.AllowDBNull = true;
      dtcEmailLinkExtension.AllowDBNull = true;
      dtcEmailDateOfExpiry.AllowDBNull = true;
      
      table.Columns.Add(dtcId);
      table.Columns.Add(dtcModifiedDate);
      table.Columns.Add(dtcModifiedUser);
      table.Columns.Add(dtcTenantId);
      table.Columns.Add(dtcLogin);
      table.Columns.Add(dtcPassword);
      table.Columns.Add(dtcPasswordSalt);
      table.Columns.Add(dtcEmail);
      table.Columns.Add(dtcState);
      table.Columns.Add(dtcFailedLoginCount);
      table.Columns.Add(dtcLastLogin);
      table.Columns.Add(dtcLastPasswordChange);
      table.Columns.Add(dtcDomainLogin);
      table.Columns.Add(dtcBusinessPartnerId);
      table.Columns.Add(dtcConditionsId);
      table.Columns.Add(dtcConditionsFixed);
      table.Columns.Add(dtcPrivacyPolicyId);
      table.Columns.Add(dtcPrivacyPolicyFixed);
      table.Columns.Add(dtcPasswordLinkExtension);
      table.Columns.Add(dtcPasswordDateOfExpiry);
      table.Columns.Add(dtcNewEmail);
      table.Columns.Add(dtcEmailLinkExtension);
      table.Columns.Add(dtcEmailDateOfExpiry);
      
      foreach (UserDto row in dtos)
      {
        table.Rows.Add(
          row.Id
          ,row.ModifiedDate
          ,row.ModifiedUser
          ,row.TenantId
          ,row.Login
          ,row.Password
          ,row.PasswordSalt
          ,row.Email
          ,row.State
          ,row.FailedLoginCount
          ,row.LastLogin
          ,row.LastPasswordChange
          ,row.DomainLogin
          ,row.BusinessPartnerId
          ,row.ConditionsId
          ,row.ConditionsFixed
          ,row.PrivacyPolicyId
          ,row.PrivacyPolicyFixed
          ,row.PasswordLinkExtension
          ,row.PasswordDateOfExpiry
          ,row.NewEmail
          ,row.EmailLinkExtension
          ,row.EmailDateOfExpiry
          );
      }
      return table;
    }
    #endregion
    #region HasChanged
    public async Task<bool> UserHasChangedAsync(IUserDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          await con.OpenAsync().ConfigureAwait(false);
          var ret = await UserHasChangedAsync(con, cmd, dto).ConfigureAwait(false);
          con.Close();
          return ret;
        }
      }
    }
    public async Task<bool> UserHasChangedAsync(SqlConnection con, SqlCommand cmd, IUserDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserDto dtoDb = await UserGetAsync(con, cmd, dto.Id).ConfigureAwait(false);
      return HasChangedWork(dto, dtoDb);
    }
    public bool UserHasChanged(IUserDto dto)
    {
      using (SqlConnection con = new SqlConnection(DatabaseConnection.ConnectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          con.Open();
          var ret = UserHasChanged(con, cmd, dto);
          con.Close();
          return ret;
        }
      }
    }
    public bool UserHasChanged(SqlConnection con, SqlCommand cmd, IUserDto dto)
    {
      if (dto.Id <= 0)
        return true;
      IUserDto dtoDb = UserGet(con, cmd, dto.Id);
      return HasChangedWork(dto, dtoDb);
    }
    private bool HasChangedWork(IUserDto dto, IUserDto dtoDb)
    {
      if (dtoDb == null)
        return true;
      bool ret = true;
      ret = ret && dto.Id == dtoDb.Id;
      ret = ret && dto.ModifiedDate == dtoDb.ModifiedDate;
      ret = ret && dto.ModifiedUser == dtoDb.ModifiedUser;
      ret = ret && dto.TenantId == dtoDb.TenantId;
      ret = ret && dto.Login == dtoDb.Login;
      ret = ret && dto.Password == dtoDb.Password;
      ret = ret && dto.PasswordSalt == dtoDb.PasswordSalt;
      ret = ret && dto.Email == dtoDb.Email;
      ret = ret && dto.State == dtoDb.State;
      ret = ret && dto.FailedLoginCount == dtoDb.FailedLoginCount;
      ret = ret && dto.LastLogin == dtoDb.LastLogin;
      ret = ret && dto.LastPasswordChange == dtoDb.LastPasswordChange;
      ret = ret && dto.DomainLogin == dtoDb.DomainLogin;
      ret = ret && dto.BusinessPartnerId == dtoDb.BusinessPartnerId;
      ret = ret && dto.ConditionsId == dtoDb.ConditionsId;
      ret = ret && dto.ConditionsFixed == dtoDb.ConditionsFixed;
      ret = ret && dto.PrivacyPolicyId == dtoDb.PrivacyPolicyId;
      ret = ret && dto.PrivacyPolicyFixed == dtoDb.PrivacyPolicyFixed;
      ret = ret && dto.PasswordLinkExtension == dtoDb.PasswordLinkExtension;
      ret = ret && dto.PasswordDateOfExpiry == dtoDb.PasswordDateOfExpiry;
      ret = ret && dto.NewEmail == dtoDb.NewEmail;
      ret = ret && dto.EmailLinkExtension == dtoDb.EmailLinkExtension;
      ret = ret && dto.EmailDateOfExpiry == dtoDb.EmailDateOfExpiry;
      return !ret;
    }
    #endregion
  }
}


