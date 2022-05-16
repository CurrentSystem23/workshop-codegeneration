using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSamples.Models
{
    public partial class User
    {
        public User()
        {
            Countries = new HashSet<Country>();
            Currencies = new HashSet<Currency>();
            DomainTypes = new HashSet<DomainType>();
            DomainValues = new HashSet<DomainValue>();
            InverseModifiedUserNavigation = new HashSet<User>();
            Products = new HashSet<Product>();
            Stocks = new HashSet<Stock>();
            Tenants = new HashSet<Tenant>();
            UserGroups = new HashSet<UserGroup>();
            UserRights = new HashSet<UserRight>();
            UserRightsRoles = new HashSet<UserRightsRole>();
        }

        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedUser { get; set; }
        public long TenantId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public long State { get; set; }
        public long FailedLoginCount { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public string DomainLogin { get; set; }
        public long BusinessPartnerId { get; set; }
        public long ConditionsId { get; set; }
        public long ConditionsFixed { get; set; }
        public long PrivacyPolicyId { get; set; }
        public long PrivacyPolicyFixed { get; set; }
        public Guid? PasswordLinkExtension { get; set; }
        public DateTime? PasswordDateOfExpiry { get; set; }
        public string NewEmail { get; set; }
        public Guid? EmailLinkExtension { get; set; }
        public DateTime? EmailDateOfExpiry { get; set; }

        public virtual User ModifiedUserNavigation { get; set; }
        public virtual DomainValue StateNavigation { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Currency> Currencies { get; set; }
        public virtual ICollection<DomainType> DomainTypes { get; set; }
        public virtual ICollection<DomainValue> DomainValues { get; set; }
        public virtual ICollection<User> InverseModifiedUserNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<UserRight> UserRights { get; set; }
        public virtual ICollection<UserRightsRole> UserRightsRoles { get; set; }
    }
}
