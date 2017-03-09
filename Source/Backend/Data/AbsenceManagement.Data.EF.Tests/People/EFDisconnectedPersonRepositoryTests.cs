using AbsenceManagement.Data.EF.People;
using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Tests;
using Moq;
using System;
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
            var sut = new EFDisconnectedPersonRepository(
                EFTestData.GetTransientAbsenceManagementContext()
            );
            var expected = PersonBuilder.CreatePerson("John", "Doe").Build();
            // Act
            sut.Add(expected);
            var actual = sut.GetAll().FirstOrDefault(p => p.FirstName.Equals("John"));
            // Assert
            Assert.Equal(1, sut.GetAll().Count());
            Assert.NotNull(actual);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
        }

        [Fact]
        public void Can_Update()
        {
            using(var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedPersonRepository(ctx);
                var johnId = sut.GetAll().FirstOrDefault().Id;

                // Act
                var actual = PersonBuilder.CreatePerson("Johnnie", "Doe").Build();
                TestData.SetPrivateProperty(actual, nameof(Person.Id), johnId);
                sut.Update(actual);

                // Assert
                Assert.Equal(1, sut.GetAll().Count());
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
                var john = sut.GetAll().FirstOrDefault();

                // Act
                sut.Delete(john);

                // Assert
                Assert.Equal(0, sut.GetAll().Count());
            }
        }

        [Fact]
        public void Can_Delete_WithId()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedPersonRepository(ctx);
                var johnId = sut.GetAll().FirstOrDefault().Id;

                // Act
                sut.Delete(johnId);

                // Assert
                Assert.Equal(0, sut.GetAll().Count());                
            }
        }
    }
}
