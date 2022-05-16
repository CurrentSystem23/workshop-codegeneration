using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderUserRight
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    Right_Asc,
    Right_Desc,
    Description_Asc,
    Description_Desc,
  }
  public interface IUserRightDto : IDtoBase
  {
    string Right { get; set; }
    string Description { get; set; }
  }
  public interface IUserRightViewModel : IUserRightDto
  {
  }
  public class UserRightDto : DtoBase, IUserRightDto, IUserRightViewModel
  {
    public string Right { get; set; }
    public string Description { get; set; } = string.Empty;
  }
  public class UserRightViewModel : UserRightDto, IUserRightDto, IUserRightViewModel
  {
  }
  public interface IUserRightHistDto : IUserRightDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IUserRightHistViewModel : IUserRightHistDto
  {
  }
  public class UserRightHistDto : UserRightDto, IUserRightHistDto, IUserRightHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class UserRightHistViewModel : UserRightHistDto, IUserRightDto, IUserRightHistViewModel
  {
  }
}


