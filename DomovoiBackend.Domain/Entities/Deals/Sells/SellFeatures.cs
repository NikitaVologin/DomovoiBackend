namespace DomovoiBackend.Domain.Entities.Deals.Sells;

public class SellFeatures
{
    public Guid Id { get; set; }
    public int YearInOwn { get; set; }
    public int OwnersCount { get; set; }
    public int PrescribersCount { get; set; }
    public bool HaveChildOwners { get; set; }
    public bool HaveChildPrescribers { get; set; }
}