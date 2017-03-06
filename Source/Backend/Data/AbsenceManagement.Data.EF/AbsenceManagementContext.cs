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
    }
}
