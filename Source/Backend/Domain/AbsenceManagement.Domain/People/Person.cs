using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.Requests;
using System;
using System.Collections.Generic;

namespace AbsenceManagement.Domain.People
{
    public class Person : DomainEntity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public List<Request> Requests { get; private set; }

        private Person() { }
        internal Person(string firstName, string lastName, Guid id = default(Guid))
            : base(id) {
            FirstName = firstName;
            LastName = lastName;
            Requests = new List<Request>();
        }
    }
}
