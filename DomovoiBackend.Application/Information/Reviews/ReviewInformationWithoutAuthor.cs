using AutoMapper;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Common;

namespace DomovoiBackend.Application.Information.Reviews;

public class ReviewInformationWithoutAuthor : IMapTwoSide<Review>
{
    public Guid Id { get; set; }
    public Guid DestinationId { get; set; }
    public int Rate { get; set; }
    public string Header { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime ReviewDate { get; set; }
}