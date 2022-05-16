using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderTenant
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    TenantName_Asc,
    TenantName_Desc,
    Description_Asc,
    Description_Desc,
  }
  public interface ITenantDto : IDtoBase
  {
    string TenantName { get; set; }
    string Description { get; set; }
  }
  public interface ITenantViewModel : ITenantDto
  {
  }
  public class TenantDto : DtoBase, ITenantDto, ITenantViewModel
  {
    public string TenantName { get; set; }
    public string Description { get; set; } = string.Empty;
  }
  public class TenantViewModel : TenantDto, ITenantDto, ITenantViewModel
  {
  }
  public interface ITenantHistDto : ITenantDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface ITenantHistViewModel : ITenantHistDto
  {
  }
  public class TenantHistDto : TenantDto, ITenantHistDto, ITenantHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class TenantHistViewModel : TenantHistDto, ITenantDto, ITenantHistViewModel
  {
  }
}


