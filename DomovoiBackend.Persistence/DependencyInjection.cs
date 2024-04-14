using DomovoiBackend.Application.Persistence;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Persistence.EfSettings;
using DomovoiBackend.Persistence.Repositories.EfRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomovoiBackend.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        services.AddDbContext<DomovoiContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IUnitOfWork, DomovoiContext>();
        services.AddScoped<IAnnouncementRepository, EfAnnouncementRepository>();
        services.AddScoped<ICounterAgentRepository, EfCounterAgentRepository>();
        return services;
    }

    public static IServiceCollection CreateDatabase(this IServiceCollection services)
    {
        var dbContext = services.BuildServiceProvider()
            .GetRequiredService<DomovoiContext>();
        dbContext.Database.EnsureCreated();
        return services;
    }
}