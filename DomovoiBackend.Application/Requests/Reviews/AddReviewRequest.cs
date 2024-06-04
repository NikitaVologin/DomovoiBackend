namespace DomovoiBackend.Application.Requests.Reviews;

public class AddReviewRequest
{
    public Guid DestinationId { get; set; }
    public Guid AuthorId { get; set; }
    public int Rate { get; set; }
    public string Header { get; set; } = null!;
    public string Text { get; set; } = null!;
}