using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.Infrastructure.Formatting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace AbsenceManagement.Domain.Tests.Infrastructure.Formatting
{
    public class DefaultStringFormatterTests
    {
        [Theory]
        [MemberData(nameof(DefaultStringFormatterTestData))]
        public void Returns_String(Foo subject, Func<Foo, string>[] stringParts, string expected) {
            // Arrange
            var sut = new DefaultStringFormatter();
            // Act
            var actual = sut.Format(subject, stringParts: stringParts);
            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> DefaultStringFormatterTestData() {
            yield return new object[] {
                new Foo(),
                null,                
                Guid.Empty.ToString()
            };
            yield return new object[] {
                new Foo(),
                new Func<Foo, string>[] { },                
                Guid.Empty.ToString()
            };
            yield return new object[] {
                new Foo(),
                new Func<Foo, string>[] {
                    f => f.PublicInt.ToString(),
                    f => f.PublicText
                },                
                "1 | PublicText"
            };
        }

        public class Foo : DomainEntity<Guid>
        {
            private string PrivateText => "PrivateText";
            public string PublicText => "PublicText";
            private int PrivateInt => -1;
            public int PublicInt => 1;            
        }
    }
}
