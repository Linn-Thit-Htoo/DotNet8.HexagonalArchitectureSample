using DotNet8.HexagonalArchitectureSample.Adapters.Blog;
using DotNet8.HexagonalArchitectureSample.DbService.Entities;
using DotNet8.HexagonalArchitectureSample.Features.Blog;
using DotNet8.HexagonalArchitectureSample.Ports.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.HexagonalArchitectureSample;

public static class ModularService
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContextService(builder)
            .AddDataAccessServices()
            .AddBusinessLogicServices()
            .AddRepositoriesService()
            .AddJsonServices(builder);
        return services;
    }

    #region Add Business Logic Services

    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Blog>();
        return services;
    }

    #endregion

    #region Add Data Access Services

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Blog>();
        return services;
    }

    #endregion

    #region Add Json Services

    public static IServiceCollection AddJsonServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
        return services;
    }

    #endregion

    #region Add Db Context Service

    public static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        });
        return services;
    }

    #endregion

    public static IServiceCollection AddRepositoriesService(this IServiceCollection services)
    {
        services.AddScoped<IBlogRepository, BlogRepository>();
        return services;
    }
}