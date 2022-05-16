using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class DomainType
    {
        public DomainType()
        {
            DomainValues = new HashSet<DomainValue>();
        }

        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public long? StandardId { get; set; }
        public long Editable { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
        public virtual ICollection<DomainValue> DomainValues { get; set; }
    }
}
