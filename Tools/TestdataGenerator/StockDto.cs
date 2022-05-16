using System;

namespace TestdataGenerator
{
  public class StockDto
  {
    public string ModifiedInformation { get; set; }
    public long Id { get; set; } = -1;
    public DateTime ModifiedDate { get; set; }
    public long ModifiedUser { get; set; } = 1;
    public long ProductId { get; set; }
    public long Quantity { get; set; }
  }
}
