using AbsenceManagement.Domain.People;
using System;

namespace AbsenceManagement.Data.People
{
    public interface IReadPersonRepository
        : IReadRepository<Person, Guid> { }    
}
