using System;
using System.Collections.Generic;

namespace AbsenceManagement.Domain.Infrastructure.Formatting
{
    public sealed class StringPartBuilder<TSubject>
    {
        private readonly List<Func<TSubject, string>> _stringParts;

        private StringPartBuilder(Func<TSubject, string> firstPart) {
            _stringParts = new List<Func<TSubject, string>>();
            _stringParts.Add(firstPart);
        }

        public static StringPartBuilder<TSubject> StartWith(Func<TSubject, string> stringPart) {
            return new StringPartBuilder<TSubject>(stringPart);
        }        

        public StringPartBuilder<TSubject> And(Func<TSubject, string> stringPart) {
            _stringParts.Add(stringPart);
            return this;
        }

        public Func<TSubject, string>[] Build() {
            return _stringParts.ToArray();
        }
    }
}
