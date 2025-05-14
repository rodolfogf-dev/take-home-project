using Microsoft.Extensions.DependencyInjection;
using System.Text;
using THA.Infra.DomainEvents;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using THA.Infra.Database;
using Microsoft.EntityFrameworkCore;
using THA.Infra.Repositories;
using THA.Domain.Persons.Repositories.Interfaces;

namespace THA.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration) =>
       services
           .AddDatabase(configuration)
           .AddAuthenticationInternal(configuration);

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TakeHomeDbContext>(opt => opt.UseSqlServer("data source=SEVERINO;initial catalog=development;Integrated Security=True;TrustServerCertificate=True"));
            services.AddScoped<ITakeHomeDbContext, TakeHomeDbContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();
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
    }
}
