using DomovoiBackend.Application.Requests.Chats;
using DomovoiBackend.Domain.Entities.ChatEntities;

namespace DomovoiBackend.Application.Services.ChatServices.Interfaces
{
    public interface IChatService
    {
        /// <summary>
        /// Получить сообщения диалога пользователей с указанными айди.
        /// </summary>
        /// <param name="userId">Id пользователя, который открывает диалог</param>
        /// <param name="idCompanion">Id пользователя, с которым открывают диалог</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        Task<IList<Message>> GetDiaologMessagesAsync(Guid userId, Guid idCompanion, CancellationToken cancellationToken);

        /// <summary>
        /// Получить Id пользователей, с которыми у пользователя начаты диалоги.
        /// </summary>
        /// <param name="userId">Id пользователя, для которого отбираются пользователи</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        Task<IList<Guid>> GetDialogsAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить сообщение
        /// </summary>
        /// <param name="request">Сообщение, которое нужно добавить</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        Task<Guid> AddMessageAsync(AddMessageRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить сообщениие.
        /// </summary>
        /// <param name="request">Сообщение, которое нужно изменить</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        Task UpdateMessageAsync(UpdateMessageRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить сообщение.
        /// </summary>
        /// <param name="id">Id сообщения, которое нужно удалить</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        Task RemoveMessageAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить сообщение.
        /// </summary>
        /// <param name="id">Id сообщения, которое нужно получить</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        Task<Message> GetMessageByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}