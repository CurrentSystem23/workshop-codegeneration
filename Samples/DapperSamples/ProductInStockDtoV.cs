using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSamples
{
  internal class ProductInStockDtoV
  {
    public long Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double Price { get; set; }
    public long Quantity { get; set; }
  }
}
