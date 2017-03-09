using AbsenceManagement.Data.EF.People;
using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Tests;
using System.Linq;

using Xunit;

namespace AbsenceManagement.Data.EF.Tests.Infrastructure
{
    public class EFDisconnectedRepositoryTests
    {
        [Fact]
        public void Can_Add()
        {
            // Arrange            
            var sut = new EFDisconnectedPersonRepository(
                EFTestData.GetTransientAbsenceManagementContext()
            );
            var user = PersonBuilder.CreatePerson("John", "Doe").Build();
            // Act
            sut.Add(user);
            var actual = sut.GetAll().FirstOrDefault(p => p.FirstName.Equals("John"));
            // Assert
            Assert.Equal(1, sut.GetAll().Count());
            Assert.NotNull(actual);
            Assert.Equal(user.FirstName, actual.FirstName);
            Assert.Equal(user.LastName, actual.LastName);
        }

        [Fact]
        public void Can_Update()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedPersonRepository(ctx);
                var userId = sut.GetAll().FirstOrDefault().Id;

                // Act
                var actual = PersonBuilder.CreatePerson("Johnnie", "Doe").Build();
                TestData.SetPrivateProperty(actual, nameof(Person.Id), userId);
                sut.Update(actual);

                // Assert
                Assert.Equal(ctx.People.Count(), sut.GetAll().Count());
                Assert.NotNull(actual);
                Assert.Equal("Johnnie", actual.FirstName);
                Assert.Equal("Doe", actual.LastName);
            }
        }

        [Fact]
        public void Can_Delete_WithObject()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedPersonRepository(ctx);
                var user = sut.GetAll().FirstOrDefault();
                var userId = user.Id;

                // Act
                sut.Delete(user);
                var nullUser = ctx.People.FirstOrDefault(p => p.Id.Equals(userId));

                // Assert
                Assert.Null(nullUser);
            }
        }

        [Fact]
        public void Can_Delete_WithId()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedPersonRepository(ctx);
                var userId = sut.GetAll().FirstOrDefault().Id;

                // Act
                sut.Delete(userId);
                var user = ctx.People.FirstOrDefault(p => p.Id.Equals(userId));

                // Assert
                Assert.Null(user);
            }
        }

        [Fact]
        public void Can_GetById()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedPersonRepository(ctx);
                var userId = sut.GetAll().FirstOrDefault().Id;

                // Act
                var user = sut.GetById(userId);

                // Assert
                Assert.NotNull(user);
                Assert.Equal(userId, user.Id);
            }
        }
    }
}
