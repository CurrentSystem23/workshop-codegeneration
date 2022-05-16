using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderProduct
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    ProductName_Asc,
    ProductName_Desc,
    Price_Asc,
    Price_Desc,
  }
  public interface IProductDto : IDtoBase
  {
    string ProductName { get; set; }
    double Price { get; set; }
  }
  public interface IProductViewModel : IProductDto
  {
  }
  public class ProductDto : DtoBase, IProductDto, IProductViewModel
  {
    public string ProductName { get; set; }
    public double Price { get; set; }
  }
  public class ProductViewModel : ProductDto, IProductDto, IProductViewModel
  {
  }
  public interface IProductHistDto : IProductDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IProductHistViewModel : IProductHistDto
  {
  }
  public class ProductHistDto : ProductDto, IProductHistDto, IProductHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class ProductHistViewModel : ProductHistDto, IProductDto, IProductHistViewModel
  {
  }
}


