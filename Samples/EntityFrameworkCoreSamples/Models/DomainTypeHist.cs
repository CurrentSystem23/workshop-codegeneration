using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class DomainTypeHist
    {
        public long HistId { get; set; }
        public string HistAction { get; set; }
        public DateTime HistDate { get; set; }
        public long? Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedUser { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public long? StandardId { get; set; }
        public long? Editable { get; set; }
    }
}
