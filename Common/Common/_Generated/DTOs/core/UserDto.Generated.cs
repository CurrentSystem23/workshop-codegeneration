using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderUser
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    TenantId_Asc,
    TenantId_Desc,
    Login_Asc,
    Login_Desc,
    Password_Asc,
    Password_Desc,
    PasswordSalt_Asc,
    PasswordSalt_Desc,
    Email_Asc,
    Email_Desc,
    State_Asc,
    State_Desc,
    FailedLoginCount_Asc,
    FailedLoginCount_Desc,
    LastLogin_Asc,
    LastLogin_Desc,
    LastPasswordChange_Asc,
    LastPasswordChange_Desc,
    DomainLogin_Asc,
    DomainLogin_Desc,
    BusinessPartnerId_Asc,
    BusinessPartnerId_Desc,
    ConditionsId_Asc,
    ConditionsId_Desc,
    ConditionsFixed_Asc,
    ConditionsFixed_Desc,
    PrivacyPolicyId_Asc,
    PrivacyPolicyId_Desc,
    PrivacyPolicyFixed_Asc,
    PrivacyPolicyFixed_Desc,
    PasswordLinkExtension_Asc,
    PasswordLinkExtension_Desc,
    PasswordDateOfExpiry_Asc,
    PasswordDateOfExpiry_Desc,
    NewEmail_Asc,
    NewEmail_Desc,
    EmailLinkExtension_Asc,
    EmailLinkExtension_Desc,
    EmailDateOfExpiry_Asc,
    EmailDateOfExpiry_Desc,
  }
  public interface IUserDto : IDtoBaseTenant
  {
    string Login { get; set; }
    string Password { get; set; }
    string PasswordSalt { get; set; }
    string Email { get; set; }
    long State { get; set; }
    long FailedLoginCount { get; set; }
    DateTime? LastLogin { get; set; }
    DateTime? LastPasswordChange { get; set; }
    string DomainLogin { get; set; }
    long BusinessPartnerId { get; set; }
    long ConditionsId { get; set; }
    long ConditionsFixed { get; set; }
    long PrivacyPolicyId { get; set; }
    long PrivacyPolicyFixed { get; set; }
    Guid? PasswordLinkExtension { get; set; }
    DateTime? PasswordDateOfExpiry { get; set; }
    string NewEmail { get; set; }
    Guid? EmailLinkExtension { get; set; }
    DateTime? EmailDateOfExpiry { get; set; }
  }
  public interface IUserViewModel : IUserDto
  {
  }
  public class UserDto : DtoBaseTenant, IUserDto, IUserViewModel
  {
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
    public string Email { get; set; }
    public long State { get; set; } = 376;
    public long FailedLoginCount { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime? LastPasswordChange { get; set; }
    public string DomainLogin { get; set; } = string.Empty;
    public long BusinessPartnerId { get; set; }
    public long ConditionsId { get; set; } = 0;
    public long ConditionsFixed { get; set; } = 0;
    public long PrivacyPolicyId { get; set; } = 0;
    public long PrivacyPolicyFixed { get; set; } = 0;
    public Guid? PasswordLinkExtension { get; set; }
    public DateTime? PasswordDateOfExpiry { get; set; }
    public string NewEmail { get; set; }
    public Guid? EmailLinkExtension { get; set; }
    public DateTime? EmailDateOfExpiry { get; set; }
  }
  public class UserViewModel : UserDto, IUserDto, IUserViewModel
  {
  }
  public interface IUserHistDto : IUserDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IUserHistViewModel : IUserHistDto
  {
  }
  public class UserHistDto : UserDto, IUserHistDto, IUserHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class UserHistViewModel : UserHistDto, IUserDto, IUserHistViewModel
  {
  }
}


