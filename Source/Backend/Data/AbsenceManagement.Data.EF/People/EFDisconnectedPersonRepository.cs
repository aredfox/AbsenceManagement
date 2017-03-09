using AbsenceManagement.Data.EF.Infrastructure;
using AbsenceManagement.Data.People;
using AbsenceManagement.Domain.People;
using System;

namespace AbsenceManagement.Data.EF.People
{
    public sealed class EFDisconnectedPersonRepository
        : EFDisconnectedRepository<AbsenceManagementContext, Person, Guid>,
        IPersonRepository
    {
        public EFDisconnectedPersonRepository(AbsenceManagementContext dataContext)
            : base(dataContext) { }
    }
}