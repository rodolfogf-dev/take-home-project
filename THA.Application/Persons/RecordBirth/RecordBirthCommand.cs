using THA.Application.Abstractions.Messaging;

namespace THA.Application.Persons.RecordBirth
{
    public sealed class RecordBirthCommand : ICommand<Guid>
    {
        public string BirthLocation { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
