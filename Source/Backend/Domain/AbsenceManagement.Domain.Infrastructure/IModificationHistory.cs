using System;

namespace AbsenceManagement.Domain.Infrastructure
{
    public interface IModificationHistory
    {
        DateTime DateModified { get; }
        DateTime DateCreated { get; }
    }
}
