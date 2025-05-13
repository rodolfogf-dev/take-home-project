using THA.Common;

namespace THA.Domain.Persons.Repositories.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T GetById();
        IList<T> GetAll();
    }
}
