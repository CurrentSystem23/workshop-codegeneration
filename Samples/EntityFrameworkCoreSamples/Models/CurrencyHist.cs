using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class CurrencyHist
    {
        public long HistId { get; set; }
        public string HistAction { get; set; }
        public DateTime HistDate { get; set; }
        public long? Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedUser { get; set; }
        public string Iso { get; set; }
        public string Currency { get; set; }
        public string CurrencyParts { get; set; }
        public string Region { get; set; }
    }
}
