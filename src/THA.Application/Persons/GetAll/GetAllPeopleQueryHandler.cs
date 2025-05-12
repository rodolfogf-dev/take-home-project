using Microsoft.EntityFrameworkCore;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.GetById;
using THA.Common;
using THA.Domain.Persons;
using THA.Infra.Data;

namespace THA.Application.Persons.GetAll
{
    class GetAllPeopleQueryHandler(ITakeHomeDbContext context)
    : IQueryHandler<GetAllPeopleQuery, List<GetAllPeopleResponse>>
    {
        public async Task<Result<List<GetAllPeopleResponse>>> Handle(GetAllPeopleQuery query, CancellationToken cancellationToken)
        {
            List<GetAllPeopleResponse> persons = await context.Persons
                .Select(u => new GetAllPeopleResponse
                    {
                    Id = u.Id,
                    PersonFullName = u.PersonFullName,
                    BirthDate = u.BirthDate,
                    BirthLocation = u.BirthLocation,
                    DeathDate = u.DeathDate,
                    DeathLocation = u.DeathLocation,
                    Gender = u.Gender
                })
                .ToListAsync(cancellationToken);

            return persons;
        }
    }
}
