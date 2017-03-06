namespace AbsenceManagement.Domain.People
{
    public static class PersonFactory
    {
        public static Person Create(string firstName, string lastName, string dataSource, string dataSourceId) {
            return new Person(firstName, lastName, dataSource, dataSourceId);
        }
    }
}