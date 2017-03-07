namespace AbsenceManagement.Data.EF.Migrations
{
    using Domain.People;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AbsenceManagementContext>
    {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AbsenceManagementContext context) {
            context.People.AddOrUpdate(
                new PersonBuilder()
                .CreatePerson("App", "Admin")
                .WithDataSource("SYSTEM", "0")
                .Build()
            );
        }
    }
}
