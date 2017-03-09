using AbsenceManagement.Domain.Infrastructure;
using EntityFramework.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AbsenceManagement.Data.EF.Infrastructure
{
    public abstract class EFDisconnectedRepository<TDataContext, TEntity, TKey>
        : IDisconnectedRepository<TDataContext>, IRepository<TEntity, TKey>
        where TDataContext : DbContext
        where TEntity : DomainEntity<TKey>
    {
        protected TDataContext Database { get; }
        protected DbSet<TEntity> Set => Database.Set<TEntity>();

        public EFDisconnectedRepository(TDataContext dataContext) {
            Database = dataContext;
        }

        public virtual void Add(TEntity entity) {
            Set.Add(entity);
            Database.SaveChanges();
        }

        public virtual void Delete(TKey entityId) {
            var entity = Set.Find(entityId);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity) {
            if(entity != null) {
                Database.Entry(entity).State = EntityState.Deleted;
                Database.SaveChanges();
            }
        }

        public virtual IEnumerable<TEntity> GetAll() {
            return Set.AsNoTracking().AsEnumerable();
        }

        public virtual TEntity GetById(TKey key) {
            return Set.Find(key);
        }

        public virtual void Update(TEntity entity, TKey entityId = default(TKey)) {            
            Database.Entry(entity).State = EntityState.Modified;            
            Database.SaveChanges();
        }
    }
}
