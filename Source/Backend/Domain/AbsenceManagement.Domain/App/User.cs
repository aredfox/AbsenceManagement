using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.App
{
    public class User : DomainEntityWithModificationHistory<Guid>
    {        
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public Person Person { get; set; }
        public Guid PersonId { get; set; }

        public List<Claim> Claims { get; set; }
        public List<ExternalLogin> Logins { get; set; }
        public List<Role> Roles { get; set; }

        public User() {
            Claims = new List<Claim>();
            Logins = new List<ExternalLogin>();
            Roles = new List<Role>();
        }
    }
}
