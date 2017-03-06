using AbsenceManagement.Domain.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.People
{
    public class Relation : DomainEntity<Guid>
    {
        [Required]
        public Person Master { get; private set; }
        [Required]
        public Person Slave { get; private set; }
        public RelationType Type { get; private set; }

        private Relation() { }
    }
}
