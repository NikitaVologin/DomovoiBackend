using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Domain.Entities.Deals;

namespace DomovoiBackend.Application.Services.MappingServices.Interfaces;

/// <summary>
/// Интерфейс сервиса сопоставления типов сделок.
/// </summary>
public interface IDealMappingService
{
    /// <summary>
    /// Создать сделку. из информации.
    /// </summary>
    /// <param name="information">Информация о сделке.</param>
    /// <returns>Сделка.</returns>
    Deal MapEntityFromInformation(DealInformation information);
    
    /// <summary>
    /// Создать информацию из сделки.
    /// </summary>
    /// <param name="deal">Сделка.</param>
    /// <returns>Информация о сделке.</returns>
    DealInformation MapInformationFromEntity(Deal deal);
}