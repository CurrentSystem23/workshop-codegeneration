using System;

namespace TestdataGenerator
{
  public class ProductDto
  {
    public string ModifiedInformation { get; set; }
    public long Id { get; set; } = -1;
    public DateTime ModifiedDate { get; set; }
    public long ModifiedUser { get; set; } = 1;
    public string ProductName { get; set; }
    public double Price { get; set; }
  }
}
