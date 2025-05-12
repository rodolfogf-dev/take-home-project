using THA.Common;
using THA.Domain.Persons.Events;

namespace THA.Application.Persons.AddPerson
{
    class PersonAddedDomainEventHandler : IDomainEventHandler<PersonAddedDomainEvent>
    {
        public Task Handle(PersonAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Send an email verification link, etc.
            return Task.CompletedTask;
        }
    }
}
