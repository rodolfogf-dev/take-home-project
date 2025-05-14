using Microsoft.EntityFrameworkCore;
using THA.Infra.Database;

namespace THA.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using TakeHomeDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<TakeHomeDbContext>();

        dbContext.Database.Migrate();
    }
}
