using THA.Common;

namespace THA.Domain.Persons.Repositories.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IList<T>> GetAllAsync();
    }
}
