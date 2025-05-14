using THA.Common;

namespace THA.Domain.Persons.Entities
{
    public sealed class Person : Entity
    {
        public Guid Id { get; set; }
        public PersonFullName PersonFullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public DateTime? DeathDate { get; set; }
        public string DeathLocation { get; set; }

        public Person(Guid id, PersonFullName personFullName, Gender gender, DateTime birthDate, string birthLocation, DateTime? deathDate, string? deathLocation)
        {
            Id = id;
            PersonFullName = personFullName ?? throw new ArgumentException("Person Full Name must be specified");
            Gender = gender;
            BirthDate = birthDate;
            BirthLocation = birthLocation;
            DeathDate = deathDate;
            DeathLocation = deathLocation;
        }
        public Person() { }
    }
}
