using System.ComponentModel.DataAnnotations;
using DomovoiBackend.Domain.Abstraction;

namespace DomovoiBackend.Domain.Entities.Realities;

/// <summary>
/// Недвижимость.
/// </summary>
public abstract class Reality : UpdatableEntity<Reality>
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Площадь.
    /// </summary>
    public double Area { get; set; }
    
    /// <summary>
    /// Тип.
    /// </summary>
    public string? Type { get; set; }
    
    /// <summary>
    /// Адрес.
    /// </summary>
    public string? Address { get; set; }
}