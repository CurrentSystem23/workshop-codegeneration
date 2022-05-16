using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderCurrency
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    Iso_Asc,
    Iso_Desc,
    Currency_Asc,
    Currency_Desc,
    CurrencyParts_Asc,
    CurrencyParts_Desc,
    Region_Asc,
    Region_Desc,
  }
  public interface ICurrencyDto : IDtoBase
  {
    string Iso { get; set; }
    string Currency { get; set; }
    string CurrencyParts { get; set; }
    string Region { get; set; }
  }
  public interface ICurrencyViewModel : ICurrencyDto
  {
  }
  public class CurrencyDto : DtoBase, ICurrencyDto, ICurrencyViewModel
  {
    public string Iso { get; set; }
    public string Currency { get; set; }
    public string CurrencyParts { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
  }
  public class CurrencyViewModel : CurrencyDto, ICurrencyDto, ICurrencyViewModel
  {
  }
  public interface ICurrencyHistDto : ICurrencyDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface ICurrencyHistViewModel : ICurrencyHistDto
  {
  }
  public class CurrencyHistDto : CurrencyDto, ICurrencyHistDto, ICurrencyHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class CurrencyHistViewModel : CurrencyHistDto, ICurrencyDto, ICurrencyHistViewModel
  {
  }
}


