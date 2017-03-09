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
        public static AbsenceManagementContext GetNewInMemoryAbsenceManagementContext(
            IEnumerable<Person> people = null,
            bool isTransient = true
        )
        {
            var dbConnection = isTransient
                ? Effort.DbConnectionFactory.CreateTransient()
                : Effort.DbConnectionFactory.CreatePersistent("_");
            var dbContext = new AbsenceManagementContext(dbConnection);
            dbContext.People.AddRange(people ?? new List<Person>());
            dbContext.SaveChanges();
            return dbContext;
        }        
    }
}
