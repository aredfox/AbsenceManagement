namespace AbsenceManagement.Domain.People
{
    public sealed class RelationBuilder
    {        
        private RelationType _type;

        public RelationBuilder() { }
        
        public RelationBuilderWithType CreateRelation(RelationType type) {
            _type = type;
            return new RelationBuilderWithType(this);
        }        

        public class RelationBuilderWithType
        {
            internal Person _master;
            internal RelationBuilder _relationBuilder;
            internal RelationBuilderWithType(RelationBuilder relationBuilder) {
                _relationBuilder = relationBuilder;
            }

            public RelationBuilderWithMaster ForMaster(Person master) {
                _master = master;
                return new RelationBuilderWithMaster(this);
            }
        }
        public class RelationBuilderWithMaster
        {            
            internal Person _slave;
            internal RelationBuilderWithType _relationBuilder;

            internal RelationBuilderWithMaster(RelationBuilderWithType relationBuilder) {
                _relationBuilder = relationBuilder;
            }

            public RelationBuilderWithSlave WithSlave(Person slave) {
                _slave = slave;
                return new RelationBuilderWithSlave(this);
            }
        }

        public class RelationBuilderWithSlave
        {                        
            internal RelationBuilderWithMaster _relationBuilder;

            internal RelationBuilderWithSlave(RelationBuilderWithMaster relationBuilder) {
                _relationBuilder = relationBuilder;
            }

            public Relation Build() {
                return new Relation(
                    type: _relationBuilder._relationBuilder._relationBuilder._type,
                    master: _relationBuilder._relationBuilder._master,
                    slave: _relationBuilder._slave
                );
            }
        }
    }
}
