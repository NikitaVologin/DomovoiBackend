using Microsoft.AspNetCore.SignalR;

namespace DomovoiBackend.API.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst("CounterAgentId")?.Value;
        }
    }
}
