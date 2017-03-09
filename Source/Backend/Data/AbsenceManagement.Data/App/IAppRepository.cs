using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.App
{
    public interface IAppRepository<TEntity, TKey>
        where TEntity : class
    {
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        List<TEntity> PageAll(int skip, int take);
        Task<List<TEntity>> PageAllAsync(int skip, int take);
        Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take);

        TEntity FindById(TKey id);
        Task<TEntity> FindByIdAsync(TKey id);
        Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, TKey id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
