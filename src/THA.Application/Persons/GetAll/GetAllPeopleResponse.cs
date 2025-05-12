using THA.Domain.Persons;

namespace THA.Application.Persons.GetAll
{
    public sealed record GetAllPeopleResponse
    {
        public Guid Id { get; init; }
        public PersonFullName PersonFullName { get; init; }
        public Gender Gender { get; init; }
        public DateTime BirthDate { get; init; }
        public string BirthLocation { get; init; }
        public DateTime? DeathDate { get; init; }
        public string DeathLocation { get; init; }
    }
}
