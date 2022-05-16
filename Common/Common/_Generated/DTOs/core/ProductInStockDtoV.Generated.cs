using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderProductInStock
  {
    Id_Asc,
    Id_Desc,
    ProductName_Asc,
    ProductName_Desc,
    Price_Asc,
    Price_Desc,
    Quantity_Asc,
    Quantity_Desc,
  }
  public interface IProductInStockDtoV
  {
    long Id { get; set; }
    string ProductName { get; set; }
    double Price { get; set; }
    long Quantity { get; set; }
  }
  public interface IProductInStockViewModel : IProductInStockDtoV
  {
  }
  public class ProductInStockDtoV : IProductInStockDtoV, IProductInStockViewModel
  {
    public long Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double Price { get; set; }
    public long Quantity { get; set; }
  }
  public class ProductInStockViewModel : ProductInStockDtoV, IProductInStockDtoV, IProductInStockViewModel
  {
  }
}


