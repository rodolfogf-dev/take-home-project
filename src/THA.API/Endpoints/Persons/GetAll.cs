using THA.API.Extensions;
using THA.API.Infrastructure;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons;
using THA.Application.Persons.GetAll;
using THA.Common;

namespace THA.API.Endpoints.Persons;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("persons", async (
            IQueryHandler<GetAllPeopleQuery, List<PersonResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetAllPeopleQuery();

            Result<List<PersonResponse>> result = await handler.Handle(query, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Persons);
        //.RequireAuthorization();
    }
}
