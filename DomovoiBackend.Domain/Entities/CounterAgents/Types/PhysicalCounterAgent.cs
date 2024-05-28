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

    public override void Update(CounterAgent entity)
    {
        if (entity is not PhysicalCounterAgent physicalEntity) return;
        Email = entity.Email;
        if(entity.Password != null) Password = entity.Password;
        ContactNumber = entity.ContactNumber;
        FIO = physicalEntity.FIO;
    }
}