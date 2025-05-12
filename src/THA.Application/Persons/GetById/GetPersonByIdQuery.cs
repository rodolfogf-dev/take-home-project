using THA.Application.Abstractions.Messaging;

namespace THA.Application.Persons.GetById;

public sealed record GetPersonByIdQuery(Guid PersonId) : IQuery<PersonResponse>;
