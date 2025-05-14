using Microsoft.AspNetCore.Mvc;
using THA.API.Endpoints.Common;
using THA.API.Extensions;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons;
using THA.Application.Persons.GetAll;
using THA.Common;

namespace THA.API.Endpoints.Persons;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (
            [FromHeader(Name = "x-client-id")] string customHeader,
            IQueryHandler <GetAllPeopleQuery, List<PersonResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            if (customHeader is null)
                return Results.BadRequest();
            if (customHeader != HttpConstants.Validkey)
                return Results.Unauthorized();

            var query = new GetAllPeopleQuery();

            Result<List<PersonResponse>> result = await handler.Handle(query, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Persons);
    }
}
