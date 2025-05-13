using THA.API.Endpoints.Persons.Requests;
using THA.API.Extensions;
using THA.API.Infrastructure;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.RecordBirth;
using THA.Common;

namespace THA.API.Endpoints.Persons
{
    internal sealed class RecordBirth : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("persons/{id:guid}/record-birth/", async (
                Guid id,
                RecordBirthRequest request,
                ICommandHandler<RecordBirthCommand, Guid> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new RecordBirthCommand
                {
                    PersonId = id,
                    BirthDate = request.DeathDate,
                };

                Result<Guid> result = await handler.Handle(command, cancellationToken);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Persons);
            //.RequireAuthorization();
        }
    }
}
