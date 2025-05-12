using THA.Common;

namespace THA.Domain.Persons.Events
{
    public sealed record class PersonDeletedDomainEvent(Guid PersonId) : IDomainEvent;   
}
