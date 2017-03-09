using System;
using System.Threading;
using System.Threading.Tasks;
using AbsenceManagement.Data.App;

namespace AbsenceManagement.Data.EF.App
{
    public sealed class EFUnitOfWork : IUnitOfWork
    {
        private AbsenceManagementContext Database { get; }
        public IExternalLoginRepository ExternalLoginRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }

        public EFUnitOfWork(
            AbsenceManagementContext dataContext,
            IExternalLoginRepository externalLoginRepository,
            IRoleRepository roleRepository,
            IUserRepository userRepository
        ) {
            Database = dataContext;
            ExternalLoginRepository = externalLoginRepository;
            RoleRepository = roleRepository;
            UserRepository = userRepository;
        }

        public int SaveChanges() {
            return Database.SaveChanges();
        }

        public Task<int> SaveChangesAsync() {
            return Database.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken) {
            return Database.SaveChangesAsync(cancellationToken);
        }
    }
}
