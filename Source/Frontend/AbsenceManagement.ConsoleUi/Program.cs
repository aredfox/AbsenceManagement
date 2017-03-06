using AbsenceManagement.Data.EF;
using AbsenceManagement.Domain.People;
using System;

namespace AbsenceManagement.ConsoleUi
{
    class Program
    {
        static void Main(string[] args) {
            InsertPerson();
            Console.ReadKey();
        }

        private static void InsertPerson() {
            var johnDoe = PersonFactory.Create("John", "Doe", "hr", "154785");
            var janeDoe = PersonFactory.Create("Jane", "Doe", "hr", "154954");
            using (var db = new AbsenceManagementContext()) {
                db.Database.Log = Console.WriteLine;
                db.People.Add(johnDoe);
                db.People.Add(janeDoe);
                db.SaveChanges();
            }
        }
    }
}
