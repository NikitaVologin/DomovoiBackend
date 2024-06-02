namespace DomovoiBackend.Application.Requests.Reviews;

public class UpdateReviewRequest
{
    public int Rate { get; set; }
    public string Header { get; set; } = null!;
    public string Text { get; set; } = null!;
}