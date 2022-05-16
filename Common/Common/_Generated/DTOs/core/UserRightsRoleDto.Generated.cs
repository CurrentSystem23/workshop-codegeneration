using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderUserRightsRole
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    Role_Asc,
    Role_Desc,
    Description_Asc,
    Description_Desc,
  }
  public interface IUserRightsRoleDto : IDtoBase
  {
    string Role { get; set; }
    string Description { get; set; }
  }
  public interface IUserRightsRoleViewModel : IUserRightsRoleDto
  {
  }
  public class UserRightsRoleDto : DtoBase, IUserRightsRoleDto, IUserRightsRoleViewModel
  {
    public string Role { get; set; }
    public string Description { get; set; } = string.Empty;
  }
  public class UserRightsRoleViewModel : UserRightsRoleDto, IUserRightsRoleDto, IUserRightsRoleViewModel
  {
  }
  public interface IUserRightsRoleHistDto : IUserRightsRoleDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IUserRightsRoleHistViewModel : IUserRightsRoleHistDto
  {
  }
  public class UserRightsRoleHistDto : UserRightsRoleDto, IUserRightsRoleHistDto, IUserRightsRoleHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class UserRightsRoleHistViewModel : UserRightsRoleHistDto, IUserRightsRoleDto, IUserRightsRoleHistViewModel
  {
  }
}


