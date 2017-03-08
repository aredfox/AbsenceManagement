using AbsenceManagement.Domain.People;
using System.Collections.Generic;

namespace AbsenceManagement.Domain.Tests
{
    public static class TestData
    {
        public static IEnumerable<object[]> GetPeopleTestData() {
            yield return new object[] {
                PersonBuilder
                .CreatePerson("Yves", "Schelpe")
                .WithDataSource("HR", "11101985")
                .Build()
            };
        }
    }
}
