using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class Product
    {
        public Product()
        {
            Stocks = new HashSet<Stock>();
        }

        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
