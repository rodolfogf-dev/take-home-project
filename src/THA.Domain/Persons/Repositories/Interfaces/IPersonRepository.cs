using THA.Domain.Persons.Entities;

namespace THA.Domain.Persons.Repositories.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> RecordBirth(Guid personId, DateTime birthDate, string birthLocation);
    }
}
