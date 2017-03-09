using AbsenceManagement.Domain.App;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.App
{
    public interface IUserRepository : IAppRepository<User, Guid>
    {
        User FindByUserName(string username);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByUserNameAsync(CancellationToken cancellationToken, string username);

        User FindByEmail(string email);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email);
    }
}
