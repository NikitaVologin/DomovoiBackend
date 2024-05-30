using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace DomovoiBackend.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public async Task Send(string message, string idSender, string idReceiver)
        {
            var name = Context.User?.Identity?.Name;
            

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            foreach (var connectionId in _connections.GetConnections(idReceiver))
            {
                await Clients.Client(connectionId).SendAsync("Receive", message, idSender);
            }
            await Clients.Caller.SendAsync("Message is received", "Ok");
        }

        public override async Task OnConnectedAsync()
        {
            var name = Context.User?.Identity?.Name;
            if (name != null)
                _connections.Add(name, Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var name = Context.User?.Identity?.Name;
            if (name != null)
                _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
