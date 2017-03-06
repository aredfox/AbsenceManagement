namespace AbsenceManagement.Domain.Infrastructure
{
    public abstract class DomainEntity<TKey>
    {
        public TKey Id { get; private set; }

        protected DomainEntity() :
            this(default(TKey)) { }
        protected DomainEntity(TKey id) {
            Id = id != null
               ? id
               : default(TKey);
        }
    }
}
