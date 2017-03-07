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

        public sealed class RelationBuilderWithType
        {
            internal Person _master;
            internal RelationType _type;            
            internal RelationBuilderWithType(RelationBuilder relationBuilder) {
                _type = relationBuilder._type;
            }

            public RelationBuilderWithMaster ForMaster(Person master) {
                _master = master;
                return new RelationBuilderWithMaster(this);
            }
        }
        public sealed class RelationBuilderWithMaster
        {            
            internal Person _slave;
            internal Person _master;
            internal RelationType _type;            

            internal RelationBuilderWithMaster(RelationBuilderWithType relationBuilder) {
                _type = relationBuilder._type;
                _master = relationBuilder._master;
            }

            public RelationBuilderWithSlave WithSlave(Person slave) {
                _slave = slave;
                return new RelationBuilderWithSlave(this);
            }
        }

        public sealed class RelationBuilderWithSlave
        {                        
            internal RelationBuilderWithMaster _relationBuilder;

            internal RelationBuilderWithSlave(RelationBuilderWithMaster relationBuilder) {
                _relationBuilder = relationBuilder;
            }

            public Relation Build() {
                return new Relation(
                    type: _relationBuilder._type,
                    master: _relationBuilder._master,
                    slave: _relationBuilder._slave
                );
            }
        }
    }
}
