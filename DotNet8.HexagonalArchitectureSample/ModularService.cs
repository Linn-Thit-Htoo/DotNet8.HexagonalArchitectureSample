using DotNet8.HexagonalArchitectureSample.DbService.Entities;
using DotNet8.HexagonalArchitectureSample.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.HexagonalArchitectureSample
{
    public static class ModularService
    {
        public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContextService(builder)
                .AddDataAccessServices()
                .AddBusinessLogicServices()
                .AddJsonServices(builder);
            return services;
        }

        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<BL_Blog>();
            return services;
        }

        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<DA_Blog>();
            return services;
        }

        public static IServiceCollection AddJsonServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return services;
        }

        public static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });
            return services;
        }
    }
}
