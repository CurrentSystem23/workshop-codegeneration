using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderSpecialProducts
  {
    Id_Asc,
    Id_Desc,
    ProductName_Asc,
    ProductName_Desc,
    Price_Asc,
    Price_Desc,
  }
  public interface ISpecialProductsDtoV
  {
    long Id { get; set; }
    string ProductName { get; set; }
    double Price { get; set; }
  }
  public interface ISpecialProductsViewModel : ISpecialProductsDtoV
  {
  }
  public class SpecialProductsDtoV : ISpecialProductsDtoV, ISpecialProductsViewModel
  {
    public long Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double Price { get; set; }
  }
  public class SpecialProductsViewModel : SpecialProductsDtoV, ISpecialProductsDtoV, ISpecialProductsViewModel
  {
  }
}


