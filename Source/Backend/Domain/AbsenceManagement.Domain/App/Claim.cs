using AbsenceManagement.Domain.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.App
{    
    public class Claim : DomainEntity<int>
    {
        [Required]
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
