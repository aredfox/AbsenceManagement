namespace AbsenceManagement.Domain.Infrastructure
{
    public abstract class DomainEntity<TKey>
    {
        public TKey Id { get; private set; }
    }
}
