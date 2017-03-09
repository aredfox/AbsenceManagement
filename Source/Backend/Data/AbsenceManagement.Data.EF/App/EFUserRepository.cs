using AbsenceManagement.Data.App;
using AbsenceManagement.Data.EF.Infrastructure;
using AbsenceManagement.Domain.App;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace AbsenceManagement.Data.EF.App
{
    public sealed class EFUserRepository
        : EFAppRepository<AbsenceManagementContext, User, Guid>, IUserRepository
    {
        public EFUserRepository(AbsenceManagementContext dataContext) 
            : base(dataContext) { }

        public User FindByEmail(string email)
        {
            return Set.FirstOrDefault(x => x.Email == email);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
