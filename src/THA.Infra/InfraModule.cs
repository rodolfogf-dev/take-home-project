using Microsoft.Extensions.DependencyInjection;
using System.Text;
using THA.Infra.DomainEvents;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using THA.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;

namespace THA.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration) =>
       services
           .AddServices()
           .AddDatabase(configuration)
           .AddHealthChecks(configuration)
           .AddAuthenticationInternal(configuration)
           .AddAuthorizationInternal();

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<DomainEventsDispatcher>();

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbpath = System.IO.Path.Join(path, "takehomeassignment.db");

            services.AddDbContext<TakeHomeDbContext>(opt => opt.UseSqlite($"Data Source={dbpath}"));

            services.AddScoped<ITakeHomeDbContext>(sp => sp.GetRequiredService<TakeHomeDbContext>());

            return services;
        }

        private static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            //services
            //    .AddHealthChecks()
            //    .AddNpgSql(configuration.GetConnectionString("Database")!);

            return services;
        }

        private static IServiceCollection AddAuthenticationInternal(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)),
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        private static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
        {
            //services.AddAuthorization();

            //services.AddScoped<PermissionProvider>();

            //services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();

            //services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

            return services;
        }
    }
}
