using AbsenceManagement.Domain.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.App
{
    public class ExternalLogin : DomainEntity<Guid>
    {
        [Required]
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }

    }
}