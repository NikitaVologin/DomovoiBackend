using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.CounterAgents;

/// <summary>
/// Контр-агент (базовая сущность).
/// </summary>
public class CounterAgent
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Контактный номер.
    /// </summary>
    public string? ContactNumber { get; set; }
    
    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string? Password { get; set; }
}