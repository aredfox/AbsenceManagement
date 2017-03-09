namespace AbsenceManagement.Data.EF.Migrations
{
    using Domain.People;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AbsenceManagementContext>
    {
        public Configuration() {
            AutomaticMigrationsEnabled = false;            
        }

        protected override void Seed(AbsenceManagementContext context) {
            var systemUser =
                context.People
                    .FirstOrDefault(p => p.DataSource == "SYSTEM" && p.DataSourceId == "0");
            if (systemUser == null) {
                context.People.AddOrUpdate(
                    PersonBuilder
                    .CreatePerson("System", "User")
                    .WithDataSource("SYSTEM", "0")
                    .Build()
                );
            }
        }
    }
}
