using System;

namespace AbsenceManagement.Domain.Infrastructure.Formatting
{
    public interface IStringFormatter
    {
        string Format<TSubject>(TSubject subject, string separator = " | ", params Func<TSubject, string>[] stringParts);
    }
}
