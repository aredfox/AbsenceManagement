using AbsenceManagement.Data.EF.Infrastructure;
using AbsenceManagement.Domain.Requests;
using System;

namespace AbsenceManagement.Data.EF.Requests
{
    public sealed class EFDisconnectedRequestRepository
        : EFDisconnectedRepository<AbsenceManagementContext, Request, Guid>
    {
        public EFDisconnectedRequestRepository(AbsenceManagementContext dataContext)
            : base(dataContext) { }
    }
}
