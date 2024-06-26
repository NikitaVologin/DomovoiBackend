using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings;

public abstract class LivingBuilding : Reality
{
    /// <summary>
    /// Этаж.
    /// </summary>
    public int Floor { get; set; }
    
    /// <summary>
    /// Количество этажей.
    /// </summary>
    public int FloorsCount { get; set; }
}