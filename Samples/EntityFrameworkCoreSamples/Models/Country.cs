using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class Country
    {
        /// <summary>
        /// Id der Währung
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Datum der letzten Änderung
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Id des Benutzers der die letzte Änderung vorgenommen hat
        /// </summary>
        public long ModifiedUser { get; set; }
        public string Country1 { get; set; }
        public string CountryKey { get; set; }
        public long? CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual User ModifiedUserNavigation { get; set; }
    }
}
