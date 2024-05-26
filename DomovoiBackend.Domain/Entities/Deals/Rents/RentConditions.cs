using DomovoiBackend.Domain.Abstraction;

namespace DomovoiBackend.Domain.Entities.Deals.Rents;

/// <summary>
/// Условия сдачи в аренду.
/// </summary>
public class RentConditions : UpdatableEntity<RentConditions>
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Период оплаты.
    /// </summary>
    public string? Period { get; set; }
    
    /// <summary>
    /// Депозит.
    /// </summary>
    public double Deposit { get; set; }
    
    /// <summary>
    /// Коммунальные платежи.
    /// </summary>
    public double CommunalPays { get; set; }
    
    /// <summary>
    /// Предоплата.
    /// </summary>
    public double Prepay { get; set; }
    
    /// <summary>
    /// Удобства.
    /// </summary>
    public string? Facilities { get; set; }
    
    /// <summary>
    /// С детьми.
    /// </summary>
    public bool WithKids { get; set; }
    
    /// <summary>
    /// С животными.
    /// </summary>
    public bool WithAnimals { get; set; }
    
    /// <summary>
    /// Можно курить.
    /// </summary>
    public bool CanSmoke { get; set; }

    public override void Update(RentConditions entity)
    {
        Period = entity.Period;
        Deposit = entity.Deposit;
        CommunalPays = entity.CommunalPays;
        Prepay = entity.Prepay;
        Facilities = entity.Facilities;
        WithKids = entity.WithKids;
        WithAnimals = entity.WithAnimals;
        CanSmoke = entity.CanSmoke;
    }
}