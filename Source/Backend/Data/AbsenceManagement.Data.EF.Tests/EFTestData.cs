using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using static System.Environment;

namespace AbsenceManagement.Data.EF.Tests
{
    public static class EFTestData
    {
        public static AbsenceManagementContext GetTransientAbsenceManagementContext(
            IEnumerable<Person> people = null        
        )
        {
            var dbConnection = Effort.DbConnectionFactory.CreateTransient();
            var dbContext = new AbsenceManagementContext(dbConnection);
            dbContext.People.AddRange(people ?? new List<Person>());
            dbContext.SaveChanges();
            return dbContext;
        }

        private static AbsenceManagementContext SetupPersistentAbsenceManagementContext(
            string id = "_",
            IEnumerable<Person> people = null            
        )
        {
            var dbConnection = Effort.DbConnectionFactory.CreatePersistent(id);
            var dbContext = new AbsenceManagementContext(dbConnection);
            dbContext.People.AddRange(people ?? new List<Person>());
            dbContext.SaveChanges();
            return dbContext;
        }

        public static AbsenceManagementContext GetPersistentAbsenceManagentContext(
            IEnumerable<Person> people = null
        )
        {
            string id = DateTime.Now.Ticks.ToString();

            using (var ctx = SetupPersistentAbsenceManagementContext(
                id: id,
                people: people ?? new Person[] { PersonBuilder.CreatePerson("John", "Doe").Build() })
            ) { }

            return SetupPersistentAbsenceManagementContext(id: id);
        }
    }
}
