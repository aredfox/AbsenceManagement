using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.People;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.Requests
{
    public class Request : DomainEntityWithModificationHistory<Guid>
    {
        public DateTime? RequestedAt { get; private set; }
        public Status Status { get; private set; }

        [Required]
        public Person Requestor { get; private set; }
        [Required]
        public Person Requestee { get; private set; }

        private Request() { }
    }
}