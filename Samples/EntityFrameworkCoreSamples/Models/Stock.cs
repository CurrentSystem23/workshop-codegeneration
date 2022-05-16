using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class Stock
    {
        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
