using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading;
using static System.Environment;

namespace AbsenceManagement.Data.EF.Tests
{
    public static class EFTestData
    {
        private static Random _random = new Random();

        public static AbsenceManagementContext GetTransientAbsenceManagementContext(
            IEnumerable<Person> people = null,
            IEnumerable<Relation> relations = null
        )
        {
            var dbConnection = Effort.DbConnectionFactory.CreateTransient();
            var dbContext = new AbsenceManagementContext(dbConnection);
            dbContext.People.AddRange(people ?? new List<Person>());
            dbContext.Relations.AddRange(relations ?? new List<Relation>());
            dbContext.SaveChanges();
            return dbContext;
        }

        private static AbsenceManagementContext SetupPersistentAbsenceManagementContext(
            string id = "_",
            IEnumerable<Person> people = null,
            IEnumerable<Relation> relations = null
        )
        {
            var dbConnection = Effort.DbConnectionFactory.CreatePersistent(id);
            var dbContext = new AbsenceManagementContext(dbConnection);
            dbContext.People.AddRange(people ?? new List<Person>());
            dbContext.Relations.AddRange(relations ?? new List<Relation>());
            dbContext.SaveChanges();
            return dbContext;
        }

        public static AbsenceManagementContext GetPersistentAbsenceManagentContext(
            IEnumerable<Person> people = null,
            IEnumerable<Relation> relations = null
        )
        {
            string id = $"{DateTime.Now.Ticks.ToString()}-{_random.Next(int.MinValue, int.MaxValue)}";
            Thread.Sleep(1);

            using (var ctx = SetupPersistentAbsenceManagementContext(
                    id: id,
                    people: people ?? new Person[] { PersonBuilder.CreatePerson("John", "Doe").Build() },
                    relations: relations ?? TestData.GetRelationTestData().Select(o => (Relation)o[0])
            )) { }

            return SetupPersistentAbsenceManagementContext(id: id);
        }
    }
}
