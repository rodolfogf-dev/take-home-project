using THA.API.Endpoints.Common;

namespace THA.API
{
    public static class WebApiModule
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // REMARK: If you want to use Controllers, you'll need this.
            services.AddControllers();

            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
