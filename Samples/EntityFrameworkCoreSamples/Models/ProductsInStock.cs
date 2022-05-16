using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class ProductsInStock
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
    }
}
