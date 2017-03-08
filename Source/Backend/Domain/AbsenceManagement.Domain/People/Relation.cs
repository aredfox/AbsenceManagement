using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.Infrastructure.Formatting;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.People
{
    public class Relation : DomainEntityWithModificationHistory<Guid>
    {
        [Required]
        public Person Master { get; private set; }
        public Guid MasterId { get; private set; }
        [Required]
        public Person Slave { get; private set; }
        public Guid SlaveId { get; private set; }
        public RelationType Type { get; private set; }

        private Relation() { }
        internal Relation(RelationType type, Person master, Person slave)
            : base() {
            Type = type;
            Master = master;
            MasterId = master.Id;
            Slave = slave;
            SlaveId = slave.Id;
        }

        public override string ToString() {            
            return ToStringFormatter.Format(
                subject: this,
                stringParts: StringPartBuilder<Relation>
                    .StartWith(r => r.Id.ToString())
                    .And(r => r.Type.ToString())
                    .And(r => $"M: {r.MasterId.ToString()}")
                    .And(r => $"S: {r.SlaveId.ToString()}")
                    .Build()
            );
        }
    }
}
