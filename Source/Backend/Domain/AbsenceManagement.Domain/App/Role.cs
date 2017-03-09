using AbsenceManagement.Domain.Infrastructure;
using System.Collections.Generic;

namespace AbsenceManagement.Domain.App
{
    public class Role : DomainEntity<int>
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public Role() {
            Users = new List<User>();
        }
    }
}
