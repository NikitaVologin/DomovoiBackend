using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Requests.Chats;
using DomovoiBackend.Application.Services.ChatServices.Interfaces;
using DomovoiBackend.Domain.Entities.ChatEntities;

namespace DomovoiBackend.Application.Services.ChatServices
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository) =>
            _chatRepository = chatRepository;

        public async Task<Guid> AddMessageAsync(AddMessageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var message = new Message {
                    IdSender = request.IdSender,
                    IdReceiver = request.IdReceiver,
                    Text = request.Text,
                    Status = MessageStatus.NotSend,
                };
                return await this._chatRepository.AddMessageAsync(message, cancellationToken);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public async Task<IList<Guid>> GetDialogsAsync(Guid userId, CancellationToken cancellationToken)
        {
            try
            {
                return await this._chatRepository.GetDialogsAsync(userId, cancellationToken);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public async Task<IList<Message>> GetDiaologMessagesAsync(Guid userId, Guid idCompanion, CancellationToken cancellationToken)
        {
            try
            {
                return await this._chatRepository.GetDiaologMessagesAsync(userId, idCompanion, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Message> GetMessageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await this._chatRepository.GetMessageByIdAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveMessageAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await this._chatRepository.RemoveMessageAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateMessageAsync(UpdateMessageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var message = new Message
                {
                    Id = request.Id,
                    Text = request.Text,
                };
                await this._chatRepository.UpdateMessageAsync(message, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}