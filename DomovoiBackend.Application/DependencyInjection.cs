using System.Reflection;
using DomovoiBackend.Application.Mapping;
using DomovoiBackend.Application.Services.AnnouncementServices;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using DomovoiBackend.Application.Services.MappingServices;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;
using DomovoiBackend.Application.Services.ReviewServices;
using DomovoiBackend.Application.Services.ReviewServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DomovoiBackend.Application;

/// <summary>
/// DI Application-слоя.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить основные сервисы слоя Application.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IAnnouncementService, AnnouncementService>();
        services.AddScoped<ICounterAgentService, CounterAgentService>();
        services.AddScoped<IReviewService, ReviewService>();
        return services;
    }

    /// <summary>
    /// Добавить подслой отображений слоя Application.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(config => config.AddProfile(
            new AssemblyMappingProfile(Assembly.GetExecutingAssembly())));
        services.AddScoped<IReviewMappingService, ReviewMappingService>();
        services.AddScoped<ICounterAgentMappingService, CounterAgentMappingService>();
        services.AddScoped<IDealMappingService, DealMappingService>();
        services.AddScoped<IRealityMappingService, RealityMappingService>();
        return services;
    }
}