using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Requests;
using System;
using System.Data.Entity;
using System.Linq;

namespace AbsenceManagement.Data.EF
{
    public class AbsenceManagementContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Request> Requests { get; set; }

        public AbsenceManagementContext(string connectionString)
            : base(connectionString) {
            Configuration.LazyLoadingEnabled = false;
        }
        public AbsenceManagementContext() {
            Configuration.LazyLoadingEnabled = false;
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

        public override int SaveChanges() {
            var history = ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory
                            && e.State == EntityState.Modified)
                .Select(e => e.Entity as IModificationHistory)
                .ToList();

            foreach (var modified in history) {
                history.GetType()
                    .GetProperty(nameof(IModificationHistory.DateModified))
                    .SetValue(modified, DateTime.UtcNow);
            }

            return base.SaveChanges();
        }
    }
}
