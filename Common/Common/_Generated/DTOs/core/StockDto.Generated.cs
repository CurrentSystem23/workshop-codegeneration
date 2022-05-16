using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;

namespace WorkshopTestProject.Common.DTOs.core
{
  public enum OrderStock
  {
    Id_Asc,
    Id_Desc,
    ModifiedDate_Asc,
    ModifiedDate_Desc,
    ModifiedUser_Asc,
    ModifiedUser_Desc,
    ProductId_Asc,
    ProductId_Desc,
    Quantity_Asc,
    Quantity_Desc,
  }
  public interface IStockDto : IDtoBase
  {
    long ProductId { get; set; }
    long Quantity { get; set; }
  }
  public interface IStockViewModel : IStockDto
  {
  }
  public class StockDto : DtoBase, IStockDto, IStockViewModel
  {
    public long ProductId { get; set; }
    public long Quantity { get; set; }
  }
  public class StockViewModel : StockDto, IStockDto, IStockViewModel
  {
  }
  public interface IStockHistDto : IStockDto
  {
    long Hist_Id { get; set; }
    string Hist_Action { get; set; }
    DateTime Hist_Date { get; set; }
  }
  public interface IStockHistViewModel : IStockHistDto
  {
  }
  public class StockHistDto : StockDto, IStockHistDto, IStockHistViewModel
  {
    public long Hist_Id { get; set; }
    public string Hist_Action { get; set; }
    public DateTime Hist_Date { get; set; }
  }
  public partial class StockHistViewModel : StockHistDto, IStockDto, IStockHistViewModel
  {
  }
}


