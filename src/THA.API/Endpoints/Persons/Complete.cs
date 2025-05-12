using THA.Application.Abstractions.Messaging;

namespace THA.API.Endpoints.Persons;

internal sealed class Complete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        //app.MapPut("persons/{id:guid}/complete", async (
        //    Guid id,
        //    ICommandHandler<CompletePersonCommand> handler,
        //    CancellationToken cancellationToken) =>
        //{
        //    var command = new CompleteTodoCommand(id);

        //    Result result = await handler.Handle(command, cancellationToken);

        //    return result.Match(Results.NoContent, CustomResults.Problem);
        //})
        //.WithTags(Tags.Todos)
        //.RequireAuthorization();
    }
}
