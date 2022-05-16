using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            DomainValues = new HashSet<DomainValue>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public string TenantName { get; set; }
        public string Description { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
        public virtual ICollection<DomainValue> DomainValues { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
