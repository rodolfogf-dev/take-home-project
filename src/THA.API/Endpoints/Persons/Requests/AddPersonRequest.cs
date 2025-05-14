using THA.Domain.Persons;

namespace THA.API.Endpoints.Persons.Requests
{
    public sealed class AddPersonRequest
    {
        public Guid Id { get; set; }
        public required PersonFullName PersonFullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public required string BirthLocation { get; set; }
        public DateTime? DeathDate { get; set; }
        public required string DeathLocation { get; set; }
    }
}
