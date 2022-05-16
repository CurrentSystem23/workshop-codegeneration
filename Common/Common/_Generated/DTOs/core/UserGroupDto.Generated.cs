using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderUserGroup
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    Group_Asc,
    Group_Desc,
    Description_Asc,
    Description_Desc,
  }
  public interface IUserGroupDto : IDtoBase
  {
    string Group { get; set; }
    string Description { get; set; }
  }
  public interface IUserGroupViewModel : IUserGroupDto
  {
  }
  public class UserGroupDto : DtoBase, IUserGroupDto, IUserGroupViewModel
  {
    public string Group { get; set; }
    public string Description { get; set; } = string.Empty;
  }
  public class UserGroupViewModel : UserGroupDto, IUserGroupDto, IUserGroupViewModel
  {
  }
  public interface IUserGroupHistDto : IUserGroupDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IUserGroupHistViewModel : IUserGroupHistDto
  {
  }
  public class UserGroupHistDto : UserGroupDto, IUserGroupHistDto, IUserGroupHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class UserGroupHistViewModel : UserGroupHistDto, IUserGroupDto, IUserGroupHistViewModel
  {
  }
}


