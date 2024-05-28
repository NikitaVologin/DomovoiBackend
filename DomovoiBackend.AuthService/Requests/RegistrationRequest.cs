namespace DomovoiBackend.AuthService.Requests;

public class RegistrationRequest
{
    public Guid CounterAgentId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}