namespace DomovoiBackend.AuthService.Models;

public class User
{
    public Guid Id { get; set; }
    public Guid CounterAgentId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}