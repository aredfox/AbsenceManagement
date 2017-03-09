using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsenceManagement.Data.People
{
    public interface IWritePersonRepository
        : IWriteRepository<Person, Guid> { }
}
