using AbsenceManagement.Data.App;
using AbsenceManagement.Data.EF.Infrastructure;
using AbsenceManagement.Domain.App;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.EF.App
{
    public sealed class EFRoleRepository
        : EFAppRepository<AbsenceManagementContext, Role, int>, IRoleRepository
    {
        public EFRoleRepository(AbsenceManagementContext dataContext)
            : base(dataContext)
        {
        }

        public Role FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
