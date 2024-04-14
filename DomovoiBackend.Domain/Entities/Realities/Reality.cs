using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.Realities;

/// <summary>
/// Недвижимость.
/// </summary>
public class Reality
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
}