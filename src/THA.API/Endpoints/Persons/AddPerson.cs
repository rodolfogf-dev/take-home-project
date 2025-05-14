using THA.API.Endpoints.Common;
using THA.API.Endpoints.Persons.Requests;
using THA.API.Extensions;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.AddPerson;
using THA.Common;

namespace THA.API.Endpoints.Persons;

internal sealed class AddPerson : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("persons", async (
            AddPersonRequest request,
            ICommandHandler<AddPersonCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
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
