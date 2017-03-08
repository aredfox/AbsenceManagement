using System;
using System.Linq;

namespace AbsenceManagement.Domain.Infrastructure.Formatting
{
    public class DefaultStringFormatter : IStringFormatter
    {
        public string Format<TSubject>(TSubject subject, string separator = " | ",
            params Func<TSubject, string>[] stringParts) {
            var subjectType = subject.GetType();
            if (stringParts == null || stringParts?.Length == 0) {
                return subject.ToString();
            }
            else {
                return String.Join(
                    separator: separator,
                    value: stringParts.Select(sp => sp(subject)).ToArray()
                );
            }
        }
    }
}