using AbsenceManagement.Data.EF;
using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AbsenceManagement.ConsoleUi
{
    class Program
    {
        static void Main(string[] args) {
            Database.SetInitializer(new NullDatabaseInitializer<AbsenceManagementContext>()); // stops from db initialization routine
            InsertPeople();
            RemovePeople();
            Console.ReadKey();
        }

        private static IEnumerable<Person> GetPeople() {
            yield return PersonFactory.Create("John", "Doe", "hr", "154785");
            yield return PersonFactory.Create("Jane", "Doe", "hr", "154954");
        }

        private static void InsertPeople() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                db.People.AddRange(GetPeople());
                db.SaveChanges();
            }
        }

        private static void RemovePeople() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                foreach (var person in GetPeople()) {
                }
                db.SaveChanges();
            }
        }
    }
}
