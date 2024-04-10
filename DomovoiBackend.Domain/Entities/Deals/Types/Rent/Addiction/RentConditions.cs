namespace DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction;

public class RentConditions
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string? Period { get; set; }
    public double Deposit { get; set; }
    public double CommunalPays { get; set; }
    public double Prepay { get; set; }
}