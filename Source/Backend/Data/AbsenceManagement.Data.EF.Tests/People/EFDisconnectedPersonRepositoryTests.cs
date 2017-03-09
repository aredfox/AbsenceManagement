using AbsenceManagement.Data.EF.People;
using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Tests;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace AbsenceManagement.Data.EF.Tests.People
{
    public class EFDisconnectedPersonRepositoryTests
    {
        [Fact]
        public void Can_Add() {
            // Arrange
            var dbConnection = Effort.DbConnectionFactory.CreateTransient();
            var dbContext = new AbsenceManagementContext(dbConnection);
            var sut = new EFDisconnectedPersonRepository(dbContext);
            var expected = PersonBuilder.CreatePerson("John", "Doe").Build();
            // Act
            sut.Add(expected);
            var actual = sut.GetAll().FirstOrDefault(p => p.FirstName.Equals("John"));
            // Assert
            Assert.Equal(1, dbContext.People.Count());
            Assert.NotNull(actual);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
        }
    }
}
