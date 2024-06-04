using DomovoiBackend.API.Exceptions;
using DomovoiBackend.Application.Requests.Chats;
using DomovoiBackend.Application.Services.ChatServices.Interfaces;
using DomovoiBackend.Domain.Entities.ChatEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DomovoiBackend.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService) =>
            _chatService = chatService;

        [Authorize]
        public async Task Send(string message, string idReceiver)
        {
            var idSender = Context.User!.FindFirst("CounterAgentId")!.Value;
            if (Clients.User(idReceiver) == null)
            {
                await Clients.Caller.SendAsync("NotifySendMethod", "-1", MessageStatus.NotSend);
                throw new UnknownUser($"User with id \"{idReceiver}\" does not exist in the system");
            }
            var request = new AddMessageRequest
            {
                IdSender = Guid.Parse(idSender),
                IdReceiver = Guid.Parse(idReceiver),
                Text = message,
            };
            var messageId = await _chatService.AddMessageAsync(request, CancellationToken.None);
            await Clients.User(idReceiver).SendAsync("Receive", message, idSender, messageId, MessageStatus.Recieve);
            await Clients.Caller.SendAsync("NotifySendMethod", messageId, MessageStatus.Recieve);
        }

        [Authorize]
        public async Task NotifyUserStatus(string idUser, string status)
        {
            var ids = await this._chatService.GetDialogsAsync(Guid.Parse(idUser), CancellationToken.None);
            var idsList = (IReadOnlyList<string>)ids;
            await Clients.Users(idsList).SendAsync("NotifyUserStatus", idUser, status);
        }

        [Authorize]
        public async Task NotifyReadDialog(string idCompanion)
        {
            var idUser = Context.User!.FindFirst("CounterAgentId")!.Value;
            await Clients.User(idCompanion.ToString()).SendAsync("NotifyReadDialog", idUser);
        }

        [Authorize]
        public async Task NotifyRemoveMessage(string idMessage)
        {
            var idUser = Context.User!.FindFirst("CounterAgentId")!.Value;
            await this._chatService.RemoveMessageAsync(Guid.Parse(idMessage), CancellationToken.None);
            var message = await this._chatService.GetMessageByIdAsync(Guid.Parse(idMessage), CancellationToken.None);
            var idCompanion = idUser == message.IdReceiver.ToString() ? message.IdSender : message.IdSender;
            await Clients.User(idCompanion.ToString()).SendAsync("NotifyMessageStatus", idMessage, "", MessageStatus.Remove);
        }

        [Authorize]
        public async Task NotifyChangeMessage(string idMessage, string newText)
        {
            var idUser = Context.User!.FindFirst("CounterAgentId")!.Value;
            var request = new UpdateMessageRequest
            {
                Id = Guid.Parse(idMessage),
                Text = newText,
            };
            await this._chatService.UpdateMessageAsync(request, CancellationToken.None);
            var message = await this._chatService.GetMessageByIdAsync(Guid.Parse(idMessage), CancellationToken.None);
            var idCompanion = idUser == message.IdReceiver.ToString() ? message.IdSender : message.IdSender;
            await Clients.User(idCompanion.ToString()).SendAsync("NotifyMessageStatus", idMessage, newText, MessageStatus.Change);
        }
    }
}