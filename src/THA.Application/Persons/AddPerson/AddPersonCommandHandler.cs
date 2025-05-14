using THA.Common;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Events;
using THA.Application.Abstractions.Messaging;
using THA.Domain.Persons.Repositories.Interfaces;

namespace THA.Application.Persons.AddPerson;

public sealed class AddPersonCommandHandler(
        IPersonRepository _personRepository)
: ICommandHandler<AddPersonCommand, Guid>
{
    public async Task<Result<Guid>> Handle(AddPersonCommand command, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            PersonFullName = command.PersonFullName,
            Gender = command.Gender,
            BirthDate = command.BirthDate,
            BirthLocation = command.BirthLocation,
            DeathDate = command.DeathDate,
            DeathLocation = command.DeathLocation
        };

        var id = await _personRepository.AddAsync(person);

        person.Raise(new PersonAddedDomainEvent(person.Id));

        return id;
    }
}

