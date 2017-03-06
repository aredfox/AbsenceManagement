using System;

namespace AbsenceManagement.Domain.People
{
    public static class PersonFactory
    {
        public static Person Create(string firstName, string lastName, Guid id = default(Guid)) {
            return new Person(firstName, lastName, id);
        }
    }
}