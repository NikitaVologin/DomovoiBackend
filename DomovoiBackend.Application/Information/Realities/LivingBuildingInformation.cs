namespace DomovoiBackend.Application.Information.Realities;

public class LivingBuildingInformation : RealityInformation
{
    /// <summary>
    /// Этаж.
    /// </summary>
    public int Floor { get; set; }
    
    /// <summary>
    /// Количество этажей.
    /// </summary>
    public int FloorsCount { get; set; }
}