namespace PeopleBase.Entities
{
    internal class PersonForm
    {
        public bool IsFilled { get; set; }
        public Person NewPerson { get; set; }

        public PersonForm()
        {
            NewPerson = new Person();
        }
    }
}
