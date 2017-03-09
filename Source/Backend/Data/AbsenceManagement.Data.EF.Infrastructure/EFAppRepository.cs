using AbsenceManagement.Data.App;
using AbsenceManagement.Domain.Infrastructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AbsenceManagement.Data.EF.Infrastructure
{
    public abstract class EFAppRepository<TDataContext, TEntity, TKey> : 
        IAppRepository<TEntity, TKey>         
        where TDataContext : DbContext
        where TEntity : DomainEntity<TKey>
    {
        protected TDataContext Database { get; }
        protected DbSet<TEntity> Set => Database.Set<TEntity>();

        public EFAppRepository(TDataContext dataContext)
        {
            Database = dataContext;
        }        

        public List<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Set.ToListAsync(cancellationToken);
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public TEntity FindById(TKey id)
        {
            return Set.Find(id);
        }

        public Task<TEntity> FindByIdAsync(TKey id)
        {
            return Set.FindAsync(id);
        }

        public Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, TKey id)
        {
            return Set.FindAsync(cancellationToken, id);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = Database.Entry(entity);
            if (entry.State == EntityState.Detached) {
                Set.Attach(entity);
                entry = Database.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            Set.Remove(entity);
        }
    }
}
