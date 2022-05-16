using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderDomainType
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    Type_Asc,
    Type_Desc,
    Description_Asc,
    Description_Desc,
    Mode_Asc,
    Mode_Desc,
    StandardId_Asc,
    StandardId_Desc,
    Editable_Asc,
    Editable_Desc,
  }
  public interface IDomainTypeDto : IDtoBase
  {
    string Type { get; set; }
    string Description { get; set; }
    char Mode { get; set; }
    long? StandardId { get; set; }
    long Editable { get; set; }
  }
  public interface IDomainTypeViewModel : IDomainTypeDto
  {
  }
  public class DomainTypeDto : DtoBase, IDomainTypeDto, IDomainTypeViewModel
  {
    public string Type { get; set; }
    public string Description { get; set; } = string.Empty;
    public char Mode { get; set; } = 'C';
    public long? StandardId { get; set; }
    public long Editable { get; set; } = 0;
  }
  public class DomainTypeViewModel : DomainTypeDto, IDomainTypeDto, IDomainTypeViewModel
  {
  }
  public interface IDomainTypeHistDto : IDomainTypeDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IDomainTypeHistViewModel : IDomainTypeHistDto
  {
  }
  public class DomainTypeHistDto : DomainTypeDto, IDomainTypeHistDto, IDomainTypeHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class DomainTypeHistViewModel : DomainTypeHistDto, IDomainTypeDto, IDomainTypeHistViewModel
  {
  }
}


