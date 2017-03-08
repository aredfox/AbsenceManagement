using AbsenceManagement.Data.EF.People;
using AbsenceManagement.Domain.People;
using Moq;
using System.Linq;
using Xunit;

namespace AbsenceManagement.Data.EF.Tests.People
{
    public class EFDisconnectedPersonRepositoryTests
    {
        [Fact]               
        public void Can_Add() {
            // Arrange
            var sut = new EFDisconnectedPersonRepository(
                MoqUtils.MockDbContext().DbContext.Object
            );
            var expected = PersonBuilder.CreatePerson("John", "Doe").Build();
            // Act
            sut.Add(expected);
            var actual = sut.GetAll().FirstOrDefault(p => p.FirstName.Equals("John"));
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
        }
    }
}
