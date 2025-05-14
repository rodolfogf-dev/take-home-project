using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using THA.API.Endpoints;
using THA.API.Endpoints.Common;

namespace THA.API.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(
        this WebApplication app,
        RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;


        var groupBuilder = builder.MapGroup("/persons").AddEndpointFilter(
            async (context, next) =>
            {
                var headerKey = context.HttpContext.Request.Headers["x-client-id"];
                if (headerKey != HttpConstants.Validkey)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.HttpContext.Response.WriteAsync("Access denied!");
                    return Results.BadRequest();
                }
                return await next(context);
            });


        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(groupBuilder);
        }

        return app;
    }
}
