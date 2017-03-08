using AbsenceManagement.Domain.People;
using Xunit;

namespace AbsenceManagement.Domain.Tests.People
{
    public class RelationTests
    {
        [Theory]
        [MemberData(nameof(TestData.GetRelationTestData), MemberType = typeof(TestData))]
        public void ToString_Format(Relation sut) {
            // Arrange
            var expected = $"{sut.Id} | {sut.Type} | M: {sut.MasterId} | S: {sut.SlaveId}";
            // Act
            var actual = sut.ToString();
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
