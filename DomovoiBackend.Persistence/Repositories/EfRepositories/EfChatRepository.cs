using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.ChatEntities;
using DomovoiBackend.Persistence.EfSettings;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Repositories.EfRepositories
{
    public class EfChatRepository : IChatRepository
    {
        private readonly DomovoiContext _context;

        public EfChatRepository(DomovoiContext context) =>
            _context = context;

        public async Task<Guid> AddMessageAsync(Message message, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Messages.AddAsync(message, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return message.Id;
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
                var ids = await _context.Messages
                    .Where(x => x.IdSender == userId || x.IdReceiver == userId)
                    .Select(x => x.IdSender == userId ? x.IdReceiver : x.IdSender )
                    .Distinct()
                    .ToListAsync(cancellationToken);
                return ids;
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
                var messages = await _context.Messages
                    .Where(x => (x.IdReceiver == userId && x.IdSender == idCompanion) || (x.IdReceiver == idCompanion && x.IdSender == userId))
                    .ToListAsync(cancellationToken);
                return messages;
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
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                if (message == null)
                    throw new DbNotFoundException(typeof(Message), id);
                return message;

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
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                if (message == null)
                    throw new DbNotFoundException(typeof(Message), id);
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateMessageAsync(Message newMessage, CancellationToken cancellationToken)
        {
            try
            {
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == newMessage.Id, cancellationToken);
                if (message == null)
                    throw new DbNotFoundException(typeof(Message), newMessage.Id);
                message.Update(newMessage);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}