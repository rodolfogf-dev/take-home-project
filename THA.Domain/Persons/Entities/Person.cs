using THA.Common;

namespace THA.Domain.Persons.Entities
{
    public sealed class Person : Entity
    {
        public Guid Id { get; set; }
        public PersonFullName PersonFullName { get; set; }
        public Gender Gender{ get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public DateTime? DeathDate { get; set; }
        public string DeathLocation { get; set; }
    }
}
