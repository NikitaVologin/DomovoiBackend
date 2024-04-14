using System.Reflection;
using DomovoiBackend.Application.Mapping;
using DomovoiBackend.Application.Services.AnnouncementServices;
using DomovoiBackend.Application.Services.AnnouncementServices.CreationServices;
using DomovoiBackend.Application.Services.AnnouncementServices.CreationServices.Interfaces;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DomovoiBackend.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(config => config.AddProfile(
            new AssemblyMappingProfile(Assembly.GetExecutingAssembly())));
        services.AddScoped<IAnnouncementService, AnnouncementService>();
        services.AddScoped<CounterAgentCreationService>();
        services.AddScoped<ICounterAgentService, CounterAgentService>();
        services.AddScoped<IDealCreationService, DealCreationService>();
        services.AddScoped<IRealityCreationService, RealityCreationService>();
        return services;
    }
}