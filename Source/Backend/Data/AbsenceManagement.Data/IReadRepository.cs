using System.Collections.Generic;

namespace AbsenceManagement.Data
{
    public interface IReadRepository<TEntity, TKey>
    {
        TEntity GetById(TKey key);
        IEnumerable<TEntity> GetAll();
    }
}
