using System;

namespace AbsenceManagement.Domain.Infrastructure
{
    public interface IModificationHistory
    {
        DateTime Modified { get; }
        DateTime Created { get; }        
    }
}
