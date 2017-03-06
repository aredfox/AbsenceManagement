using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.Requests;
using System.Collections.Generic;

namespace AbsenceManagement.Domain.People
{
    public class Person : DomainEntity<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public List<Person> Subordinates { get; private set; }
        public List<Person> Managers { get; set; }
        public List<Request> Requests { get; private set; }

        internal Person(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;
            Subordinates = new List<Person>();
            Managers = new List<Person>();
            Requests = new List<Request>();
        }
    }
}
