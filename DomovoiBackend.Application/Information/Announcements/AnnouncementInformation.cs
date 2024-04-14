using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Information.Realities;

namespace DomovoiBackend.Application.Information.Announcements;

/// <summary>
/// Информация об объявлении для запроса/ответа.
/// </summary>
public class AnnouncementInformation
{
    /// <summary>
    /// GUID Объявления.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Описание объявления.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Тип связи в объявлении.
    /// </summary>
    public string ConnectionType { get; set; } = null!;
    
    /// <summary>
    /// Информация о типе сделки.
    /// </summary>
    public DealInformation DealInfo { get; set; }
    
    /// <summary>
    /// Информация о типе недвижимости.
    /// </summary>
    public RealityInformation RealityInfo { get; set; }
    
    /// <summary>
    /// Информация о контр-агенте.
    /// </summary>
    public CounterAgentInformation CounterAgentInfo { get; set; }
}