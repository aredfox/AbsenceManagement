using System;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.Infrastructure
{
    public abstract class DomainEntityWithModificationHistory<TKey>
        : DomainEntity<TKey>, IModificationHistory
    {
        [Required]
        public DateTime DateCreated { get; private set; }
        [Required]
        public DateTime DateModified { get; private set; }

        protected DomainEntityWithModificationHistory()
            : this(DateTime.UtcNow) { }
        protected DomainEntityWithModificationHistory(DateTime dateCreated, DateTime? dateModified = null) {
            DateCreated = dateCreated;
            DateModified = dateModified ?? DateCreated;
        }
    }
}
