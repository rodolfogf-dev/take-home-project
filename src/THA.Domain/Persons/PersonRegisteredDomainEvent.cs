using THA.Common;

namespace Domain.Persons;

public sealed record PersonRegisteredDomainEvent(Guid UserId) : IDomainEvent;
