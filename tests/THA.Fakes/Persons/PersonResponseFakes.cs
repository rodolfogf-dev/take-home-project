using THA.Application.Persons;
using THA.Domain.Persons;

namespace THA.Fakes.Persons
{
    public static class PersonResponseFakes
    {
        public static PersonResponse GetPersonResponseSample()
            => new()
            {
                PersonFullName = new PersonFullName("Rodolfo", "Gomes"),
                Gender = Gender.Female,
                BirthDate = PersonFakes.GetDateTimeDefault(),
                BirthLocation = "Recife",
                DeathDate = PersonFakes.GetDateTimeDefault(),
                DeathLocation = "Recife 2"
            };
    }
}
