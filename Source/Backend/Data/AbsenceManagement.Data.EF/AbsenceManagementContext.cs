using AbsenceManagement.Domain.App;
using AbsenceManagement.Domain.Infrastructure;
using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Requests;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace AbsenceManagement.Data.EF
{
    public class AbsenceManagementContext : DbContext
    {
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<ExternalLogin> ExternalLogins { get; set; }

        public AbsenceManagementContext(string connectionString)
            : base(connectionString) {
            Configuration.LazyLoadingEnabled = false;
        }
        public AbsenceManagementContext(DbConnection connection) 
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public AbsenceManagementContext() {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("app");

            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Requestor)
                .WithMany(p => p.Requests)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Requestee)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Map(m => m.ToTable("identity.Users"));
            modelBuilder.Entity<ExternalLogin>()
                .Map(m => m.ToTable("identity.ExternalLogins"));
            modelBuilder.Entity<Claim>()
                .Map(m => m.ToTable("identity.Claims"));
            modelBuilder.Entity<Role>()
                .Map(m => m.ToTable("identity.Roles"));
        }

        public override int SaveChanges() {
            var history = ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory
                            && e.State == EntityState.Modified
                            && e.State != EntityState.Deleted)
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
