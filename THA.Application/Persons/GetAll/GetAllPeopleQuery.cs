using THA.Application.Abstractions.Messaging;

namespace THA.Application.Persons.GetAll
{
    public sealed record GetAllPeopleQuery() : IQuery<List<GetAllPeopleResponse>>;
}
