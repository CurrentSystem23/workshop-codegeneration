using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class DomainValueHist
    {
        public long HistId { get; set; }
        public string HistAction { get; set; }
        public DateTime HistDate { get; set; }
        public long? Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedUser { get; set; }
        public long? TypeId { get; set; }
        public string ValueC { get; set; }
        public long? ValueN { get; set; }
        public DateTime? ValueD { get; set; }
        public double? ValueF { get; set; }
        public string DivId { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public long? TenantId { get; set; }
    }
}
