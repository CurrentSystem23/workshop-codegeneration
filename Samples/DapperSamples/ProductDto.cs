using System;

namespace DapperSamples
{
  internal class ProductDto
  {
    public long Id { get; set; }
    public DateTime ModifiedDate { get; set; }
    public long ModifiedUser { get; set; }
    public string ModifiedInformation { get; set; }

    public string ProductName { get; set; }
    public double Price { get; set; }
  }
}
