using System.Threading;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.App
{
    public interface IUnitOfWork
    {
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
