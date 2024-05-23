using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Rents;

namespace DomovoiBackend.Application.Information.Deals.Rents;

/// <summary>
/// Информация о условиях аренды для запроса/ответа.
/// </summary>
public class RentConditionInformation : IMapTwoSide<RentConditions>
{
    /// <summary>
    /// Период платежа.
    /// </summary>
    public string? Period { get; set; }
    
    /// <summary>
    /// Сумма депозита.
    /// </summary>
    public double Deposit { get; set; }
    
    /// <summary>
    /// Сумма комунальных платежей.
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
    /// Разрешено с детьми.
    /// </summary>
    public bool WithKids { get; set; }
    
    /// <summary>
    /// Разрешено с животными.
    /// </summary>
    public bool WithAnimals { get; set; }
    
    /// <summary>
    /// Разрешено курить.
    /// </summary>
    public bool CanSmoke { get; set; }
}