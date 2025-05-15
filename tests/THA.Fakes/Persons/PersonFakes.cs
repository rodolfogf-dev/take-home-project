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
                BirthDate = GetDateTimeDefault(),
                BirthLocation = "Recife",
                DeathDate = GetDateTimeDefault(),
                DeathLocation = "Recife 2"
            };

        public static Person GetPersonWithoutFullName()
            => new()
            {
                PersonFullName = null,
                Gender = Gender.Female,
                BirthDate = GetDateTimeDefault(),
                BirthLocation = "Recife",
                DeathDate = GetDateTimeDefault(),
                DeathLocation = "Recife 2"
            };

        public static DateTime GetDateTimeDefault()
            => DateTime.ParseExact("2025-05-14 12:00:00,000", "yyyy-MM-dd HH:mm:ss,fff",
                       System.Globalization.CultureInfo.InvariantCulture);
    }
}
