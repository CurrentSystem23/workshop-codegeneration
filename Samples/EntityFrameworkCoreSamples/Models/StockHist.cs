using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class StockHist
    {
        public long HistId { get; set; }
        public string HistAction { get; set; }
        public DateTime HistDate { get; set; }
        public long? Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedUser { get; set; }
        public long? ProductId { get; set; }
        public long? Quantity { get; set; }
    }
}
