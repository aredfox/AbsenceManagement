using AbsenceManagement.Data.EF.Infrastructure;
using AbsenceManagement.Domain.People;
using System;

namespace AbsenceManagement.Data.EF.People
{
    public sealed class EFDisconnectedPersonRepository
        : EFDisconnectedRepository<AbsenceManagementContext, Person, Guid>
    {
        public EFDisconnectedPersonRepository(AbsenceManagementContext dataContext)
            : base(dataContext) { }
    }
}