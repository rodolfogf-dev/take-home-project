using THA.Application.Abstractions.Messaging;
using THA.Common;
using THA.Domain.Persons.Events;
using THA.Domain.Persons.Repositories.Interfaces;

namespace THA.Application.Persons.RecordBirth
{
    public class RecordBirthCommandHandler(IPersonRepository _personRepository)
: ICommandHandler<RecordBirthCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(RecordBirthCommand command, CancellationToken cancellationToken)
        {
            var person = await _personRepository.RecordBirth(command.PersonId, command.BirthDate, command.BirthLocation);
            person.Raise(new PersonAddedDomainEvent(person.Id));
            return person.Id;
        }
    }
}
