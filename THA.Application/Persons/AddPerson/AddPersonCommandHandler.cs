using THA.Infra.Data;
using THA.Common;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Events;
using THA.Application.Abstractions.Messaging;

namespace THA.Application.Persons.AddPerson;

internal sealed class AddPersonCommandHandler(
        ITakeHomeDbContext context)
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

        context.Persons.Add(person);

        await context.SaveChangesAsync(cancellationToken);

        person.Raise(new PersonAddedDomainEvent(person.Id));

        return person.Id;
    }
}

