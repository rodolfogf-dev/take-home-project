using THA.Domain.Persons;
using THA.Domain.Persons.Entities;

namespace THA.Fakes.Persons
{
    public static class PersonFakes
    {
        public static Person GetPersonSample()
            => new()
            {
                PersonFullName = new PersonFullName("Rodolfo", "Gomes"),
                Gender = Gender.Female,
                BirthDate = DateTime.Now,
                BirthLocation = "Recife",
                DeathDate = DateTime.Now,
                DeathLocation = "Recife 2"
            };

        public static Person GetPersonWithoutFullName()
            => new()
            {
                PersonFullName = null,
                Gender = Gender.Female,
                BirthDate = DateTime.Now,
                BirthLocation = "Recife",
                DeathDate = DateTime.Now,
                DeathLocation = "Recife 2"
            };


    }
}
