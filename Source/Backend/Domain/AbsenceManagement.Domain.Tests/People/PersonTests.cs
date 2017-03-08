using AbsenceManagement.Domain.People;
using Xunit;

namespace AbsenceManagement.Domain.Tests.People
{
    public class PersonTests
    {
        [Theory]
        [MemberData(nameof(TestData.GetPeopleTestData), MemberType = typeof(TestData))]
        public void ToString_Format(Person sut) {
            // Arrange
            var expected = $"{sut.Id} | {sut.FirstName} {sut.LastName}";
            // Act
            var actual = sut.ToString();
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
