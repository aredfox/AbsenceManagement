using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.People;
using System;

namespace AbsenceManagement.Domain.Requests
{
    public class Request : DomainEntity<Guid>
    {
        public DateTime? RequestedAt { get; private set; }
        public Status Status { get; private set; }

        public Person Requestor { get; private set; }
        public Person Requestee { get; private set; }
    }
}