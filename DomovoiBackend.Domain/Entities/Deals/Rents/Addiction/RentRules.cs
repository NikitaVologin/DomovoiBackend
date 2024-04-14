namespace DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction;

public class RentRules
{
    public Guid Id { get; set; }
    public string? Facilities { get; set; }
    public bool WithKids { get; set; }
    public bool WithAnimals { get; set; }
    public bool CanSmoke { get; set; }
}