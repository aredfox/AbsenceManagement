using AbsenceManagement.Data.EF;
using AbsenceManagement.Data.EF.People;
using AbsenceManagement.Data.People;
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
            InsertRelation();
            UpdateDisconnectedPeople();
            RemoveRelationships();
            RemovePeople();

            Console.WriteLine("-- END --");
            Console.ReadKey();
        }

        private static IEnumerable<Person> GetPeople() {
            yield return PersonBuilder
                .CreatePerson("John", "Doe")
                .WithDataSource("hr", "154785")
                .Build();
            yield return PersonBuilder
                .CreatePerson("Jane", "Doe")
                .WithDataSource("hr", "154954")
                .Build();
        }

        private static void InsertPeople() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;                
                var repo = new EFDisconnectedPersonRepository(db);
                foreach (var person in GetPeople()) { repo.Add(person); }
            }
        }

        private static void ListAllPeople() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                var repo = new EFDisconnectedPersonRepository(db);
                PrintPerson(repo.GetAll().ToArray());
            }
        }
        private static void PrintPerson(params Person[] people) {
            foreach (var person in people) {
                Console.WriteLine(person.ToString());
            }
        }

        private static void InsertRelation() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                var pplRepo = new EFDisconnectedPersonRepository(db);
                var relRepo = new EFDisconnectedRelationRepository(db);

                var janeDoe = pplRepo.GetAll()
                    .FirstOrDefault(p => p.FirstName == "Jane");
                var johnDoe = pplRepo.GetAll()
                    .FirstOrDefault(p => p.FirstName == "John");
                var relation = RelationBuilder
                    .CreateRelation(RelationType.ManagerToSubordinate)
                    .ForMaster(janeDoe)
                    .WithSlave(johnDoe)
                    .Build();
                relRepo.Add(relation);
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

        private static void RemoveRelationships() {
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                db.Relations.RemoveRange(db.Relations.ToList());
                db.SaveChanges();
            }
        }

        private static void RemovePeople() {
            IList<Person> peopleToDelete;
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                var pplRepo = new EFDisconnectedPersonRepository(db);
                var peopleToDeleteIds = GetPeople().Select(p => p.DataSourceId);
                peopleToDelete = pplRepo.GetAll().Where(p => peopleToDeleteIds.Contains(p.DataSourceId)).ToList();
            }

            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                var pplRepo = new EFDisconnectedPersonRepository(db);
                foreach (var personToDelete in peopleToDelete) {
                    pplRepo.Delete(personToDelete);
                }                
            }

            // NOTE: deleting could very well be done by going off to a stored procedure,
            // because retrieving and then doing another query for deletion
            // seems a bit much
            // Depends on the scenario
        }
    }
}
