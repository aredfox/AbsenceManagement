using System;

namespace AbsenceManagement.Data.People
{
    public interface IPersonRepository
        : IReadPersonRepository, IWritePersonRepository { }
}
