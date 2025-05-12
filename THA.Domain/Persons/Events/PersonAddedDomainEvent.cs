using THA.Common;

namespace THA.Domain.Persons.Events
{
    public sealed record class PersonAddedDomainEvent(Guid PersonId) : IDomainEvent;
}
