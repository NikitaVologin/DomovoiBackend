using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings.ValueTypes;

public class Bathroom
{
    [Key]
    public Guid Id { get; set; }
    public string? Type { get; set; }
}