namespace DomovoiBackend.Application.Parameters;

public class FilterParameters
{
    public string? DealType { get; set; }
    public double? PriceStart { get; set; }
    public double? PriceEnd { get; set; }
    public string? RealityType { get; set; }
    public FloorSelectMode FloorFilter { get; set; }
}

public enum FloorSelectMode
{
    Pohuy = 0,
    NotFirst = 1,
    NotLast = 2,
    Both = 3,
}