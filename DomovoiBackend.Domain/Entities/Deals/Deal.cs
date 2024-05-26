using System.ComponentModel.DataAnnotations;
using DomovoiBackend.Domain.Abstraction;

namespace DomovoiBackend.Domain.Entities.Deals;

/// <summary>
/// Сделка.
/// </summary>
public abstract class Deal : UpdatableEntity<Deal>
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
        
    /// <summary>
    /// Цена.
    /// </summary>
    public double Price { get; set; }
}