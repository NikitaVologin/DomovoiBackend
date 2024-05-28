namespace DomovoiBackend.Domain.Entities.CounterAgents.Types;

/// <summary>
/// Юридический  контр-агент.
/// </summary>
public class LegalCounterAgent : CounterAgent
{
    /// <summary>
    /// Название.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// ИНН.
    /// </summary>
    public string? Tin { get; set; }

    public override void Update(CounterAgent entity)
    {
        if (entity is not LegalCounterAgent legalEntity) return;
        Email = entity.Email;
        if(entity.Password != null) Password = entity.Password;
        ContactNumber = entity.ContactNumber;
        Tin = legalEntity.Tin;
        Name = legalEntity.Name;
    }
}