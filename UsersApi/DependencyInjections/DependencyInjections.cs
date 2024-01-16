using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersApi.Data;
using UsersApi.Data.Repositories;
using UsersApi.Data.Repositories.Interfaces;
using UsersApi.Services;
using UsersApi.Services.Interfaces;

namespace UsersApi.DependencyInjections;

public static class DependencyInjections
{
    public static IServiceCollection AddAppData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddScoped<IUsersRepository, UsersRepository>();
        
        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();
        return services;
    }
    
    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddSingleton<IMapper, ServiceMapper>();
        return services;
    }
}