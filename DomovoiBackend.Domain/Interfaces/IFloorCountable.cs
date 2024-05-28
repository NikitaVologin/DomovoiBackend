namespace DomovoiBackend.Domain.Interfaces;

public interface IFloorCountable
{
    public int Floor { get ; set; }
    public int FloorsCount { get; set; }
}