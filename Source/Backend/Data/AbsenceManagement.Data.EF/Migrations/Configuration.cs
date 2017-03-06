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
                PersonFactory.Create("App", "Admin", "App", default(Guid).ToString(), default(Guid))
            );
        }
    }
}
