using THA.API.Extensions;
using THA.API.Infrastructure;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.AddPerson;
using THA.Common;
using THA.Domain.Persons;

namespace THA.API.Endpoints.Persons;

internal sealed class AddPerson : IEndpoint
{
    public sealed class Request
    {
        public Guid Id { get; set; }
        public PersonFullName PersonFullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public DateTime? DeathDate { get; set; }
        public string DeathLocation { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("persons", async (
            Request request,
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
