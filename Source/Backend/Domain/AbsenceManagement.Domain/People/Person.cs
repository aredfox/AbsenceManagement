using AbsenceManagement.Domain.App;
using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.Infrastructure.Formatting;
using AbsenceManagement.Domain.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbsenceManagement.Domain.People
{
    public class Person : DomainEntity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }        

        [Required(AllowEmptyStrings = false)]
        public string DataSource { get; private set; }
        [Required(AllowEmptyStrings = false)]
        public string DataSourceId { get; private set; }

        public List<Request> Requests { get; private set; }

        private Person() { }
        internal Person(string firstName, string lastName, string dataSource, string dataSourceId)
            : base() {
            FirstName = firstName;
            LastName = lastName;
            DataSource = dataSource;
            DataSourceId = dataSourceId;
            Requests = new List<Request>();
        }

        public override string ToString() {
            return ToStringFormatter.Format(
                subject: this,
                stringParts: StringPartBuilder<Person>
                    .StartWith(p => p.Id.ToString())
                    .And(p => $"{p.FirstName} {p.LastName}")
                    .Build()
            );
        }
    }
}
