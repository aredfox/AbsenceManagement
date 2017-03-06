using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Requests;
using System.Data.Entity;

namespace AbsenceManagement.Data.EF
{
    public class AbsenceManagementContext : DbContext
    {
        public IDbSet<Person> People { get; set; }
        public IDbSet<Request> Requests { get; set; }

        public AbsenceManagementContext(string connectionString)
            : base(connectionString) {
        }
        public AbsenceManagementContext() {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            // See course https://app.pluralsight.com/player?course=entity-framework-6-getting-started&author=julie-lerman&name=entity-framework-6-getting-started-m2&clip=5&mode=live
            base.OnModelCreating(modelBuilder);
        }
    }
}
