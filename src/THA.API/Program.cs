using System.Reflection;
using THA.API.Extensions;
using THA.Application;
using THA.Infra;
using Serilog;

namespace THA.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddSwaggerGenWithAuth();

            builder.Services
                .AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

            
            builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

            WebApplication app = builder.Build();

            app.MapEndpoints();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerWithUi();

                app.ApplyMigrations();
            }

            app.UseRequestContextLogging();

            app.UseSerilogRequestLogging();

            app.UseExceptionHandler();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
