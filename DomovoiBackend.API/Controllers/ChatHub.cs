using DomovoiBackend.API.Exceptions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DomovoiBackend.API.Controllers
{
    [Authorize]
    public class ChatHub : Hub
    {
        [Authorize]
        public async Task Send(string message, string idReceiver)
        {
            var nameSender = Context.User?.FindFirst("CounterAgentId")?.Value;
            if (Clients.User(idReceiver) == null)
                throw new UnknownUser($"User with id \"{idReceiver}\" does not exist in the system");
            await Clients.User(idReceiver).SendAsync("Receive", message, nameSender);
            await Clients.Caller.SendAsync("NotifySendMethod", "Ok");
        }
    }

    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst("CounterAgentId")?.Value;
        }
    }
}