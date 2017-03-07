using System;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.Infrastructure
{
    public abstract class DomainEntityWithModificationHistory<TKey>
        : DomainEntity<TKey>, IModificationHistory
    {
        [Required]
        public DateTime Created { get; private set; }
        [Required]
        public DateTime Modified { get; private set; }

        protected DomainEntityWithModificationHistory()
            : base() { }
    }
}
