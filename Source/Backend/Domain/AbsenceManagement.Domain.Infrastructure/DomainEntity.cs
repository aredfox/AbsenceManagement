using AbsenceManagement.Domain.Infrastructure.Formatting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbsenceManagement.Domain.Infrastructure
{
    public abstract class DomainEntity<TKey>
    {
        [NotMapped]
        public IStringFormatter ToStringFormatter { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; private set; }

        protected DomainEntity() : this(null) { }
        protected DomainEntity(IStringFormatter toStringFormatter) {
            ToStringFormatter = toStringFormatter ?? new DefaultStringFormatter();
        }

        public override string ToString() {
            return ToStringFormatter.Format(
                subject: this,
                stringParts: new Func<DomainEntity<TKey>, string>[] {
                    de => de.Id.ToString()
                }
            );
        }
    }
}
