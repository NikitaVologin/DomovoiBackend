namespace DomovoiBackend.Application.Parameters;

public class FilterParameters
{
    public string? DealType { get; set; }
    public double? PriceStart { get; set; }
    public double? PriceEnd { get; set; }
    public string? RealityType { get; set; }
    public string? RealitySubtype { get; set; }
}