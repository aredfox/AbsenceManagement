using AbsenceManagement.Domain.People;
using System;
using System.Collections.Generic;

namespace AbsenceManagement.Data.People
{
    public interface IReadRelationRepository
        : IReadRepository<Relation, Guid>
    {
        IEnumerable<Relation> GetForMaster(Person master);
        IEnumerable<Relation> GetForMaster(Guid masterId);
        IEnumerable<RelationType> GetTypesForMaster(Person master);
        IEnumerable<RelationType> GetTypesForMaster(Guid masterId);

        IEnumerable<Relation> GetForSlave(Person slave);
        IEnumerable<Relation> GetForSlave(Guid slaveId);
    }
}
