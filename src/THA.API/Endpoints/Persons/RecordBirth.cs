using THA.API.Extensions;
using THA.API.Infrastructure;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.RecordBirth;
using THA.Common;

namespace THA.API.Endpoints.Persons
{
    internal sealed class RecordBirth : IEndpoint
    {
        public sealed class Request
        {
            public Guid UserId { get; set; }
            public DateTime DeathDate { get; set; }
            public DateTime DeathLocation { get; set; }
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("persons/{id:guid}/record-birth/", async (
                Guid id,
                Request request,
                ICommandHandler<RecordBirthCommand, Guid> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new RecordBirthCommand
                {
                    PersonId = id
                };

                Result<Guid> result = await handler.Handle(command, cancellationToken);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Persons);
            //.RequireAuthorization();
        }
    }
}
