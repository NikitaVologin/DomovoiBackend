using DomovoiBackend.Domain.Abstraction;
using DomovoiBackend.Domain.Entities.CounterAgents;

namespace DomovoiBackend.Domain.Entities.Common;

public class Review : UpdatableEntity<Review>
{
    public Guid Id { get; set; }
    public Guid DestinationId { get; set; }
    public CounterAgent Author { get; set; } = null!;
    public int Rate { get; set; }
    public string Header { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime ReviewDate { get; set; }
    
    public override void Update(Review entity)
    {
        Rate = entity.Rate;
        Header = entity.Header;
        Text = entity.Text;
    }
}