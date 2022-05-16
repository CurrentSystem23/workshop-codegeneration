using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderCountry
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    Country_Asc,
    Country_Desc,
    CountryKey_Asc,
    CountryKey_Desc,
    CurrencyId_Asc,
    CurrencyId_Desc,
  }
  public interface ICountryDto : IDtoBase
  {
    string Country { get; set; }
    string CountryKey { get; set; }
    long? CurrencyId { get; set; }
  }
  public interface ICountryViewModel : ICountryDto
  {
  }
  public class CountryDto : DtoBase, ICountryDto, ICountryViewModel
  {
    public string Country { get; set; } = string.Empty;
    public string CountryKey { get; set; }
    public long? CurrencyId { get; set; }
  }
  public class CountryViewModel : CountryDto, ICountryDto, ICountryViewModel
  {
  }
  public interface ICountryHistDto : ICountryDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface ICountryHistViewModel : ICountryHistDto
  {
  }
  public class CountryHistDto : CountryDto, ICountryHistDto, ICountryHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class CountryHistViewModel : CountryHistDto, ICountryDto, ICountryHistViewModel
  {
  }
}


