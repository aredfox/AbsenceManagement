using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Requests;
using System.Data.Entity;

namespace AbsenceManagement.Data.EF
{
    public class AbsenceManagementContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Request> Requests { get; set; }

        public AbsenceManagementContext(string connectionString)
            : base(connectionString) {
        }
        public AbsenceManagementContext() {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Requestor)
                .WithMany(p => p.Requests)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Requestee)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
