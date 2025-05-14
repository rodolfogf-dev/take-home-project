using THA.Application.Persons.AddPerson;
using THA.Domain.Persons;

namespace THA.Fakes.Persons.Commands
{
    public static class AddPersonCommandFakes
    {
        public static AddPersonCommand GetAddPersonCommandSampleFake()
            => new()
            {
                PersonFullName = new PersonFullName("Rodolfo", "Gomes"),
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                BirthLocation = "Recife"
            };
    }
}
