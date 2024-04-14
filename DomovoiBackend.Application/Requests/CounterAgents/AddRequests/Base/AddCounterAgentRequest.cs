namespace DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;

public class AddCounterAgentRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}