using Microsoft.EntityFrameworkCore;
using THA.Application.Abstractions.Messaging;
using THA.Common;
using THA.Domain.Persons;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Repositories.Interfaces;
using THA.Infra.Database;

namespace THA.Application.Persons.GetById;

internal sealed class GetPersonByIdQueryHandler(IPersonRepository _personRepository)
    : IQueryHandler<GetPersonByIdQuery, PersonResponse>
{
    public async Task<Result<PersonResponse>> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken)
    {
        PersonResponse response = new PersonResponse();
        Person person = await _personRepository.GetByIdAsync(query.PersonId);

        if (person is null)
            return Result.Failure<PersonResponse>(PersonErrors.NotFound(query.PersonId));

        response.Id = person.Id;
        response.PersonFullName = new PersonFullName(person.PersonFullName.GivenName, person.PersonFullName.Surname);
        response.BirthDate = person.BirthDate;
        response.BirthLocation = person.BirthLocation;
        response.DeathDate = person.DeathDate;
        response.DeathLocation = person.DeathLocation;
        response.Gender = person.Gender;

        return response;
    }
}
