namespace AbsenceManagement.Data
{
    public interface IWriteRepository<TEntity, TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity, TKey entityId = default(TKey));
        void Delete(TEntity entity);
        void Delete(TKey entityId);
    }
}