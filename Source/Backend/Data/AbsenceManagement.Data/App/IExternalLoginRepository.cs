using AbsenceManagement.Domain.App;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.App
{
    public interface IExternalLoginRepository : IAppRepository<ExternalLogin, Guid>
    {
        ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey);
    }
}
