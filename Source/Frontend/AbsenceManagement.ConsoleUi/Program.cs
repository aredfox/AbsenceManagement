using AbsenceManagement.Data.EF;
using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AbsenceManagement.ConsoleUi
{
    class Program
    {
        static void Main(string[] args) {
            Database.SetInitializer(new NullDatabaseInitializer<AbsenceManagementContext>()); // stops from db initialization routine
            InsertPeople();
            ListAllPeople();
            UpdateDisconnectedPeople();
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

        private static void ListAllPeople() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                PrintPerson(db.People.ToList().ToArray());
            }
        }
        private static void PrintPerson(params Person[] people) {
            foreach (var person in people) {
                Console.WriteLine(person.ToString());
            }
        }

        private static void UpdateDisconnectedPeople() {
            Person janeDoe;
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                janeDoe = db.People
                    .Where(p => p.FirstName == "Jane")
                    .FirstOrDefault();
                PrintPerson(janeDoe);
            }

            janeDoe.GetType().GetProperty("FirstName").SetValue(janeDoe, "Jean");

            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                db.Entry(janeDoe).State = EntityState.Modified;
                db.SaveChanges();
                PrintPerson(janeDoe);
            }

            janeDoe.GetType().GetProperty("FirstName").SetValue(janeDoe, "Jane");

            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                db.Entry(janeDoe).State = EntityState.Modified;
                db.SaveChanges();
                PrintPerson(janeDoe);
            }
        }

        private static void RemovePeople() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                var peopleToDeleteIds = GetPeople().Select(p => p.DataSourceId);
                var peopleToDelete = db.People.Where(p => peopleToDeleteIds.Contains(p.DataSourceId)).ToList();
                db.People.RemoveRange(peopleToDelete);
                db.SaveChanges();
            }
        }
    }
}
