namespace DomovoiBackend.Domain.Entities.CounterAgents.Types;

/// <summary>
/// Физический контр-агент.
/// </summary>
public class PhysicalCounterAgent : CounterAgent
{
    /// <summary>
    /// ФИО.
    /// </summary>
    public string? FIO { get; set; }
    
    /// <summary>
    /// Пасспортные данные.
    /// </summary>
    public string? PassportData { get; set; }

    public override void Update(CounterAgent entity)
    {
        if (entity is not PhysicalCounterAgent physicalEntity) return;
        Email = entity.Email;
        Password = entity.Password;
        ContactNumber = entity.ContactNumber;
        PassportData = physicalEntity.PassportData;
        FIO = physicalEntity.FIO;
    }
}