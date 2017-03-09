using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            yield return new object[] {
                PersonBuilder
                .CreatePerson("Ramiro", "Solomon")
                .WithDataSource("HR", "15051945")
                .Build()
            };

            yield return new object[] {
                PersonBuilder
                .CreatePerson("Sonya", "Sharpe")
                .WithDataSource("HR", "29101966")
                .Build()
            };
        }

        public static IEnumerable<object[]> GetRelationTestData() {
            var master = PersonBuilder
                .CreatePerson("Harley", "Powell")
                .WithDataSource("HR", "30031984")
                .Build();

            return GetPeopleTestData()
                .Select(o => o[0])
                .Cast<Person>()                
                .Select(p => RelationBuilder
                    .CreateRelation(RelationType.ManagerToSubordinate)
                    .ForMaster(master)
                    .WithSlave(p)
                    .Build()
                )
                .Select(r => new object[] { r });
        }

        public static void SetPrivateProperty<TSubject, TProperty>(
            TSubject subject, string propertyName, TProperty newValue)
        {
            var fieldInfos =
                subject.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .ToList();
            var derivedFieldInfos = subject.GetType().BaseType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .ToList();
            fieldInfos.AddRange(derivedFieldInfos);
            fieldInfos = fieldInfos
                .Where(f => f.FieldType == typeof(TProperty))
                .ToList();

            foreach (var fieldInfo in fieldInfos) {                
                    if (fieldInfo.Name.ToLower().Contains(propertyName.ToLower())) {
                        fieldInfo.SetValue(subject, newValue);
                        break;
                    }
            }            
        }
    }
}
