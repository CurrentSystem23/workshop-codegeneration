using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderDomainValue
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    TypeId_Asc,
    TypeId_Desc,
    ValueC_Asc,
    ValueC_Desc,
    ValueN_Asc,
    ValueN_Desc,
    ValueD_Asc,
    ValueD_Desc,
    ValueF_Asc,
    ValueF_Desc,
    DivId_Asc,
    DivId_Desc,
    Description_Asc,
    Description_Desc,
    Unit_Asc,
    Unit_Desc,
    TenantId_Asc,
    TenantId_Desc,
  }
  public interface IDomainValueDto : IDtoBaseTenant
  {
    long TypeId { get; set; }
    string ValueC { get; set; }
    long? ValueN { get; set; }
    DateTime? ValueD { get; set; }
    double? ValueF { get; set; }
    string DivId { get; set; }
    string Description { get; set; }
    string Unit { get; set; }
  }
  public interface IDomainValueViewModel : IDomainValueDto
  {
  }
  public class DomainValueDto : DtoBaseTenant, IDomainValueDto, IDomainValueViewModel
  {
    public long TypeId { get; set; }
    public string ValueC { get; set; }
    public long? ValueN { get; set; }
    public DateTime? ValueD { get; set; }
    public double? ValueF { get; set; }
    public string DivId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Unit { get; set; }
  }
  public class DomainValueViewModel : DomainValueDto, IDomainValueDto, IDomainValueViewModel
  {
  }
  public interface IDomainValueHistDto : IDomainValueDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IDomainValueHistViewModel : IDomainValueHistDto
  {
  }
  public class DomainValueHistDto : DomainValueDto, IDomainValueHistDto, IDomainValueHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class DomainValueHistViewModel : DomainValueHistDto, IDomainValueDto, IDomainValueHistViewModel
  {
  }
}


