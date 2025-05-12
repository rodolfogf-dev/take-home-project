using Microsoft.EntityFrameworkCore;
using THA.Application.Abstractions.Messaging;
using THA.Common;
using THA.Domain.Persons;
using THA.Infra.Data;

namespace THA.Application.Persons.GetById;

internal sealed class GetPersonByIdQueryHandler(ITakeHomeDbContext context)
    : IQueryHandler<GetPersonByIdQuery, GetPersonByIdResponse>
{
    public async Task<Result<GetPersonByIdResponse>> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken)
    {
        GetPersonByIdResponse? Person = await context.Persons
            .Where(u => u.Id == query.PersonId)
            .Select(u => new GetPersonByIdResponse
            {
                Id = u.Id,
                PersonFullName = u.PersonFullName,
                BirthDate = u.BirthDate,
                BirthLocation = u.BirthLocation,
                DeathDate = u.DeathDate,
                DeathLocation = u.DeathLocation,
                Gender = u.Gender
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (Person is null)       
            return Result.Failure<GetPersonByIdResponse>(PersonErrors.NotFound(query.PersonId));
        
        return Person;
    }
}
