using AbsenceManagement.Domain.App;
using System.Threading;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.App
{
    public interface IRoleRepository : IAppRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
