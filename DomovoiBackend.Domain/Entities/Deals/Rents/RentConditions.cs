namespace DomovoiBackend.Domain.Entities.Deals.Rents;

/// <summary>
/// Условия сдачи в аренду.
/// </summary>
public class RentConditions
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Сумма.
    /// </summary>
    public double Price { get; set; }
    
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
}