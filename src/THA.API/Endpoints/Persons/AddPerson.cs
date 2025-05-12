using THA.API.Extensions;
using THA.API.Infrastructure;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.AddPerson;
using THA.Common;

namespace THA.API.Endpoints.Persons;

internal sealed class AddPerson : IEndpoint
{
    public sealed class Request
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public List<string> Labels { get; set; } = [];
        public int Priority { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("todos", async (
            Request request,
            ICommandHandler<AddPersonCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new AddPersonCommand
            {
               
            };

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Todos)
        .RequireAuthorization();
    }
}
