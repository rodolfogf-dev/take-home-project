namespace THA.Domain.Persons
{
    public class PersonFullName
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public PersonFullName(string givenName, string surname)
        {
            GivenName = givenName;
            Surname = surname;
        }
    }
}
