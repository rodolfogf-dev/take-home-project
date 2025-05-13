namespace THA.API.Endpoints.Persons.Requests
{
    public sealed class RecordBirthRequest
    {
        public Guid PersonId { get; set; }
        public DateTime DeathDate { get; set; }
        public DateTime DeathLocation { get; set; }
    }
}
