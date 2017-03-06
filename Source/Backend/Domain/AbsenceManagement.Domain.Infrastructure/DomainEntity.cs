using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.Infrastructure
{
    public abstract class DomainEntity<TKey>
    {
        [Key]
        public TKey Id { get; private set; }

        protected DomainEntity() { }
    }
}
