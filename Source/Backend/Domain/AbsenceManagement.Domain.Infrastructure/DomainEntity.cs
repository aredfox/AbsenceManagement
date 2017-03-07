using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbsenceManagement.Domain.Infrastructure
{
    public abstract class DomainEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; private set; }

        protected DomainEntity() { }
    }
}
