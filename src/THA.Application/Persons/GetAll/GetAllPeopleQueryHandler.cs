using Microsoft.EntityFrameworkCore;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.GetById;
using THA.Common;
using THA.Domain.Persons;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Repositories.Interfaces;
using THA.Infra.Database;

namespace THA.Application.Persons.GetAll
{
    class GetAllPeopleQueryHandler(IPersonRepository _personRepository)
    : IQueryHandler<GetAllPeopleQuery, List<PersonResponse>>
    {
        public async Task<Result<List<PersonResponse>>> Handle(GetAllPeopleQuery query, CancellationToken cancellationToken)
        {
            List<Person> persons = await _personRepository.GetAllAsync();
            List<PersonResponse> response = persons
                .Select(u => new PersonResponse
                {
                    Id = u.Id,
                    PersonFullName = u.PersonFullName,
                    BirthDate = u.BirthDate,
                    BirthLocation = u.BirthLocation,
                    DeathDate = u.DeathDate,
                    DeathLocation = u.DeathLocation,
                    Gender = u.Gender
                })
                .ToList();

            return response;
        }
    }
}
