using THA.Application.Abstractions.Messaging;
using THA.Domain.Persons;

namespace THA.Application.Persons.AddPerson;

public sealed class AddPersonCommand : ICommand<Guid>
{
    public PersonFullName PersonFullName { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string BirthLocation { get; set; }
    public DateTime? DeathDate { get; set; }
    public string DeathLocation { get; set; }
}





