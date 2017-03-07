namespace AbsenceManagement.Data
{
    public interface IRepository<TEntity, TKey>
        : IReadRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey>
    { }
}
