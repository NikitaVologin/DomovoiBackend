using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Persistence.EfSettings;
using DomovoiBackend.Persistence.Repositories.EfRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomovoiBackend.Persistence;

/// <summary>
/// DI для Persistence слоя.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить Persistence слой.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <param name="configuration">Конфигурация.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        services.AddDbContext<DomovoiContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IAnnouncementRepository, EfAnnouncementRepository>();
        services.AddScoped<ICounterAgentRepository, EfCounterAgentRepository>();
        return services;
    }

    /// <summary>
    /// Пересоздать БД.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection CreateDatabase(this IServiceCollection services)
    {
        var dbContext = services.BuildServiceProvider()
            .GetRequiredService<DomovoiContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        return services;
    }
}