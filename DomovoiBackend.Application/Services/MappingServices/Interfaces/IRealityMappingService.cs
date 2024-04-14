using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Information.Realities;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Realities;

namespace DomovoiBackend.Application.Services.MappingServices.Interfaces;

/// <summary>
/// Интерфейс сервиса сопоставления типов недвижимостей.
/// </summary>
public interface IRealityMappingService
{
    /// <summary>
    /// Создать недвижимость из информации.
    /// </summary>
    /// <param name="information">Информация о недвижимости.</param>
    /// <returns>Недвижимость.</returns>
    Reality MapEntityFromInformation(RealityInformation information);
    
    /// <summary>
    /// Создать информацию из недвижимости.
    /// </summary>
    /// <param name="reality">Недвижимость.</param>
    /// <returns>Информация о недвижимости.</returns>
    RealityInformation MapInformationFromEntity(Reality reality);
}