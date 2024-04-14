using System.ComponentModel.DataAnnotations;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Realities;

namespace DomovoiBackend.Domain.Entities.Announcements;

/// <summary>
/// Объявление.
/// </summary>
public class Announcement
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Тип связи.
    /// </summary>
    public string? ConnectionType { get; set; }
    
    /// <summary>
    /// Недвижимость.
    /// </summary>
    public virtual Reality? Reality { get; set; }
    
    /// <summary>
    /// Сделка.
    /// </summary>
    public virtual Deal? Deal { get; set; }
    
    /// <summary>
    /// Контр-агент.
    /// </summary>
    public virtual CounterAgent? CounterAgent { get; set; }
}