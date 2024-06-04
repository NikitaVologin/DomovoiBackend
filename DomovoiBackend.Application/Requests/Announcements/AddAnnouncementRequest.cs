using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Information.Realities;

namespace DomovoiBackend.Application.Requests.Announcements;

/// <summary>
/// Запрос создания объявления.
/// </summary>
public class AddAnnouncementRequest
{
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Тип связи.
    /// </summary>
    public string ConnectionType { get; set; }
    
    /// <summary>
    /// Информация о сделке.
    /// </summary>
    public DealInformation DealInfo { get; set; }
    
    /// <summary>
    /// Информация о недвижимости.
    /// </summary>
    public RealityInformation RealityInfo { get; set; }
    
    /// <summary>
    /// Id Контр-агента.
    /// </summary>
    public Guid CounterAgentId { get; set; }
}