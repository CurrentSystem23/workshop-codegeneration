using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Countries = new HashSet<Country>();
        }

        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public string Iso { get; set; }
        public string Currency1 { get; set; }
        public string CurrencyParts { get; set; }
        public string Region { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
