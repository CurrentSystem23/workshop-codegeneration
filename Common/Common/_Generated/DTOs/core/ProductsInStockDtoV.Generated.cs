using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderProductsInStock
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
  public interface IProductsInStockDtoV
  {
    long Id { get; set; }
    string ProductName { get; set; }
    double Price { get; set; }
    long Quantity { get; set; }
  }
  public interface IProductsInStockViewModel : IProductsInStockDtoV
  {
  }
  public class ProductsInStockDtoV : IProductsInStockDtoV, IProductsInStockViewModel
  {
    public long Id { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public long Quantity { get; set; }
  }
  public class ProductsInStockViewModel : ProductsInStockDtoV, IProductsInStockDtoV, IProductsInStockViewModel
  {
  }
}


