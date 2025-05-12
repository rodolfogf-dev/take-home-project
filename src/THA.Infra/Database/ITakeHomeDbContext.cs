using Microsoft.EntityFrameworkCore;
using THA.Domain.Persons.Entities;

namespace THA.Infra.Database;

public interface ITakeHomeDbContext
{
    DbSet<Person> Persons { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
