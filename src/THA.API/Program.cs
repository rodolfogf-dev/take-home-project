using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using THA.API;
using THA.API.Extensions;
using THA.Application;
using THA.Infra;
using THA.Infra.Database;

namespace TakeHomeAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            //builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddSwaggerGenWithAuth();

            builder.Services
                .AddApplication()
                .AddPresentation()
                .AddInfrastructure(builder.Configuration);

            builder.Services.AddDbContext<TakeHomeDbContext>(opt => opt.UseSqlServer("data source=SEVERINO;initial catalog=development;Integrated Security=True;TrustServerCertificate=True"));

            builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

            WebApplication app = builder.Build();

            app.MapEndpoints();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerWithUi();

                app.ApplyMigrations();
            }

            //app.MapHealthChecks("health", new HealthCheckOptions
            //{
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});

            app.UseRequestContextLogging();

            //app.UseSerilogRequestLogging();

            app.UseExceptionHandler();

            app.UseAuthentication();

            app.UseAuthorization();

            // REMARK: If you want to use Controllers, you'll need this.
            app.MapControllers();

            app.Run();
        }
    }
}
