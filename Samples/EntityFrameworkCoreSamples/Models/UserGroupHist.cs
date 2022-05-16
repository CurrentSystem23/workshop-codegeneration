using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class UserGroupHist
    {
        public long HistId { get; set; }
        public string HistAction { get; set; }
        public DateTime HistDate { get; set; }
        public long? Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedUser { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
