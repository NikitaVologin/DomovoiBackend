using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.Deals;

/// <summary>
/// Сделка.
/// </summary>
public class Deal
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
}