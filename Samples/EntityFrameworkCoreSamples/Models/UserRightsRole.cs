using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class UserRightsRole
    {
        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
    }
}
