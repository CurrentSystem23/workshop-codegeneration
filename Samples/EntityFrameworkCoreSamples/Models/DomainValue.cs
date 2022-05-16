using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class DomainValue
    {
        public DomainValue()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public long TypeId { get; set; }
        public string ValueC { get; set; }
        public long? ValueN { get; set; }
        public DateTime? ValueD { get; set; }
        public double? ValueF { get; set; }
        public string DivId { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public long TenantId { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual DomainType Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
