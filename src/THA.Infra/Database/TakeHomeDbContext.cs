using Microsoft.EntityFrameworkCore;
using THA.Common;
using THA.Domain.Persons.Entities;
namespace THA.Infra.Database;

public class TakeHomeDbContext: DbContext, ITakeHomeDbContext
{
    public TakeHomeDbContext(DbContextOptions<TakeHomeDbContext> options) : base(options)
    {

    }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TakeHomeDbContext).Assembly);
        modelBuilder.Entity<Person>().ComplexProperty(p => p.PersonFullName);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        int result = await base.SaveChangesAsync(cancellationToken);
        await PublishDomainEventsAsync();
        return result;
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                List<IDomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        //await domainEventsDispatcher.DispatchAsync(domainEvents);
    }
}
