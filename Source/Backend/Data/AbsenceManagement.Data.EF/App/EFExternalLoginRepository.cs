using AbsenceManagement.Data.App;
using AbsenceManagement.Data.EF.Infrastructure;
using AbsenceManagement.Domain.App;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.EF.App
{
    public sealed class EFExternalLoginRepository
        : EFAppRepository<AbsenceManagementContext, ExternalLogin, Guid>, IExternalLoginRepository
    {
        public EFExternalLoginRepository(AbsenceManagementContext dataContext)
            : base(dataContext) { }

        public ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            return Set.FirstOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);
        }
    }
}
