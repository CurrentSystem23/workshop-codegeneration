using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class UserHist
    {
        public long HistId { get; set; }
        public string HistAction { get; set; }
        public DateTime HistDate { get; set; }
        public long? Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedUser { get; set; }
        public long? TenantId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public long? State { get; set; }
        public long? FailedLoginCount { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public string DomainLogin { get; set; }
        public long? BusinessPartnerId { get; set; }
        public long? ConditionsId { get; set; }
        public long? ConditionsFixed { get; set; }
        public long? PrivacyPolicyId { get; set; }
        public long? PrivacyPolicyFixed { get; set; }
        public Guid? PasswordLinkExtension { get; set; }
        public DateTime? PasswordDateOfExpiry { get; set; }
        public string NewEmail { get; set; }
        public Guid? EmailLinkExtension { get; set; }
        public DateTime? EmailDateOfExpiry { get; set; }
    }
}
