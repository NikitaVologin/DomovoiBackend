using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Common;

/// <summary>
/// Дом.
/// </summary>
public class ApartmentHouse
{
    [Key]
    public Guid Id { get; set; }
    public int BuildingYear { get; set; }
    public string? Type { get; set; }
    public double CeilingHeight { get; set; }
    public bool IsGas { get; set; }
    public bool HaveGarbageChute { get; set; }
    public bool IsSecurity { get; set; }
    public bool HaveParking { get; set; }
    public List<string> Infrastructures { get; set; }
    public bool IsLandscaping { get; set; }

    public virtual IEnumerable<Elevator> Elevators { get; set; } = new List<Elevator>();
}