using AbsenceManagement.Data.EF.Infrastructure;
using AbsenceManagement.Data.People;
using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AbsenceManagement.Data.EF.People
{
    public sealed class EFDisconnectedRelationRepository
        : EFDisconnectedRepository<AbsenceManagementContext, Relation, Guid>,
          IRelationRepository
    {
        public EFDisconnectedRelationRepository(AbsenceManagementContext dataContext)
            : base(dataContext) { }

        public IEnumerable<Relation> GetForMaster(Guid masterId) {
            return Set
                .AsNoTracking()
                .Include(r => r.Master)
                .Include(r => r.Slave)
                .Where(r => r.Master.Id.Equals(masterId));
        }

        public IEnumerable<Relation> GetForMaster(Person master) {
            return GetForMaster(master.Id);
        }

        public IEnumerable<Relation> GetForSlave(Guid slaveId) {
            return Set
                .AsNoTracking()
                .Include(r => r.Master)
                .Include(r => r.Slave)
                .Where(r => r.Slave.Id.Equals(slaveId));
        }

        public IEnumerable<Relation> GetForSlave(Person slave) {
            return GetForSlave(slave.Id);
        }

        public IEnumerable<RelationType> GetTypesForMaster(Guid masterId) {
            return Set
                .AsNoTracking()
                .Where(r => r.Master.Id.Equals(masterId))
                .Select(r => r.Type)
                .Distinct()
                .AsEnumerable();
        }

        public IEnumerable<RelationType> GetTypesForMaster(Person master) {
            return GetTypesForMaster(master.Id);
        }
    }
}
