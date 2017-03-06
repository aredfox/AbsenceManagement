namespace AbsenceManagement.Domain.Infrastructure
{
    public class DomainEntity<TKey>
    {
        TKey Id { get; private set; }
    }
}
