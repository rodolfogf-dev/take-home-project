using Microsoft.AspNetCore.Mvc;
using THA.API.Endpoints.Common;
using THA.API.Endpoints.Persons.Requests;
using THA.API.Extensions;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.AddPerson;
using THA.Common;
using THA.Domain.Persons;

namespace THA.API.Endpoints.Persons;

internal sealed class AddPerson : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("persons", async (
            [FromHeader(Name = "x-client-id")] string customHeader,
            AddPersonRequest request,
            ICommandHandler<AddPersonCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            //if (customHeader is null)
            //    return 
            //if (customHeader == "1111")
            //    return Result.Failure<Guid>(PersonErrors.Unauthorized()).Match(Results.Ok, CustomResults.Problem);

            var command = new AddPersonCommand
            {
                PersonFullName = request.PersonFullName,
                Gender = request.Gender,
                BirthDate = request.BirthDate,
                BirthLocation = request.BirthLocation
            };

            Result<Guid> result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Persons);
        //.RequireAuthorization();
    }
}
