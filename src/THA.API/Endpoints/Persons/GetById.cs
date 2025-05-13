using THA.API.Extensions;
using THA.API.Infrastructure;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons;
using THA.Application.Persons.GetById;
using THA.Common;

namespace THA.API.Endpoints.Persons;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("persons/{id:guid}", async (
            Guid id,
            IQueryHandler<GetPersonByIdQuery, PersonResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new GetPersonByIdQuery(id);

            Result<PersonResponse> result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Persons);
        //.RequireAuthorization();
    }
}
