namespace DomovoiBackend.Application.Parameters;

public class OrderParameters
{
    public OrderValue? AreaOrder { get; set; }
    public OrderValue? PriceOrder { get; set; }
}

public enum OrderValue
{
    Descending = -1,
    Ascending = 1
};