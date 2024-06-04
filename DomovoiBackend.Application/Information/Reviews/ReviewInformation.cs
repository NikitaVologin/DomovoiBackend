using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Mapping.Interfaces;

namespace DomovoiBackend.Application.Information.Reviews;

public class ReviewInformation : IMapTwoSide<ReviewInformationWithoutAuthor>
{
    public Guid Id { get; set; }
    public Guid DestinationId { get; set; }
    public CounterAgentInformation Author { get; set; }
    public int Rate { get; set; }
    public string Header { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime ReviewDate { get; set; }
}