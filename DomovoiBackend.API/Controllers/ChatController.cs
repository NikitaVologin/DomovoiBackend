using DomovoiBackend.Application.Services.ChatServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DomovoiBackend.API.Controllers
{
    /// <summary>
    /// Контроллер чата.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService) =>
            _chatService = chatService;

        /// <summary>
        /// Получить сообщения диалога пользователей с указанными айди.
        /// </summary>
        /// <param name="userId">Id пользователя, который открывает диалог</param>
        /// <param name="idCompanion">Id пользователя, с которым открывают диалог</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        [HttpGet("Take/{userId:guid}/{idCompanion:guid}")]
        public async Task<IActionResult> GetDiaologMessagesAsync(Guid userId, Guid idCompanion,
            CancellationToken cancellationToken)
        {
            try
            {
                var messages = await this._chatService.GetDiaologMessagesAsync(userId, idCompanion, cancellationToken);
                return Ok(messages);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Получить Id пользователей, с которыми у пользователя начаты диалоги.
        /// </summary>
        /// <param name="userId">Id пользователя, для которого отбираются пользователи</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ответ.</returns>
        [HttpGet("Take/${userId:guid}")]
        public async Task<IActionResult> GetDialogsAsync(Guid userId, CancellationToken cancellationToken)
        {
            try
            {
                var ids = await this._chatService.GetDialogsAsync(userId, cancellationToken);
                return Ok(ids);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}