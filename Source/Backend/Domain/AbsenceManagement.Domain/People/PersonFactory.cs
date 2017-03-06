namespace AbsenceManagement.Domain.People
{
    public static class PersonFactory
    {
        public static Person Create(string firstName, string lastName) {
            return new Person(firstName, lastName);
        }
    }
}
