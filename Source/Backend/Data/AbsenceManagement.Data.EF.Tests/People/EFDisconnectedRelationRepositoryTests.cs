using AbsenceManagement.Data.EF.People;
using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Tests;
using System.Linq;
using Xunit;

namespace AbsenceManagement.Data.EF.Tests.People
{
    public class EFDisconnectedRelationRepositoryTests
    {
        [Fact]
        public void Can_GetForSlave_WithObject()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedRelationRepository(ctx);
                var slave = ctx.People.FirstOrDefault(p => p.DataSourceId.Equals("11101985"));

                // Act
                var relations = sut.GetForSlave(slave);

                // Assert
                Assert.Equal(1, relations.Count());
            }
        }

        [Fact]
        public void Can_GetForSlave_WithId()
        {            
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedRelationRepository(ctx);
                var slave = ctx.People.FirstOrDefault(p => p.DataSourceId.Equals("11101985"));

                // Act
                var relations = sut.GetForSlave(slave.Id);

                // Assert
                Assert.Equal(1, relations.Count());
            }
        }

        [Fact]
        public void Can_GetForMaster_WithObject()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedRelationRepository(ctx);
                var master = ctx.People.FirstOrDefault(p => p.DataSourceId.Equals("30031984"));

                // Act
                var relations = sut.GetForMaster(master);

                // Assert
                Assert.Equal(ctx.Relations.Count(), relations.Count());
            }
        }

        [Fact]
        public void Can_GetForMaster_WithId()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedRelationRepository(ctx);
                var master = ctx.People.FirstOrDefault(p => p.DataSourceId.Equals("30031984"));

                // Act
                var relations = sut.GetForMaster(master.Id);

                // Assert
                Assert.Equal(ctx.Relations.Count(), relations.Count());
            }
        }

        [Fact]
        public void Can_GetTypesForMaster_WithObject()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedRelationRepository(ctx);
                var master = ctx.People.FirstOrDefault(p => p.DataSourceId.Equals("30031984"));

                // Act
                var relations = sut.GetTypesForMaster(master);

                // Assert
                Assert.Equal(1, relations.Count());
                Assert.Equal(RelationType.ManagerToSubordinate, relations.First());
            }
        }

        [Fact]
        public void Can_GetTypesForMaster_WithId()
        {
            using (var ctx = EFTestData.GetPersistentAbsenceManagentContext()) {
                // Arrange
                var sut = new EFDisconnectedRelationRepository(ctx);
                var master = ctx.People.FirstOrDefault(p => p.DataSourceId.Equals("30031984"));

                // Act
                var relations = sut.GetTypesForMaster(master.Id);

                // Assert
                Assert.Equal(1, relations.Count());
                Assert.Equal(RelationType.ManagerToSubordinate, relations.First());
            }
        }
    }
}
