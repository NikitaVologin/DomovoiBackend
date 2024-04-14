using DomovoiBackend.Application.Requests.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DomovoiBackend.API.Controllers;

/// <summary>
/// Контроллер контр-агентов.
/// </summary>
[Route("[controller]")]
[ApiController]
public class CounterAgentController : ControllerBase
{
    /// <summary>
    /// Сервис контр-агентов.
    /// </summary>
    private readonly ICounterAgentService _service;

    public CounterAgentController(ICounterAgentService service) => _service = service;
    
    /// <summary>
    /// Post - добавить контр-агента.
    /// </summary>
    /// <param name="counterAgentType">Тип контр-агента.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Ответ.</returns>
    [HttpPost("{counterAgentType}")]
    public async Task<IActionResult> Post(
        [FromRoute] string counterAgentType,
        [FromBody] AddCounterAgentRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var id = await _service.AddAsync(request, cancellationToken);
            return Ok(id);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }

    /// <summary>
    /// Post - логин.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Ответ.</returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login(AuthorizationRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var counterAgent = await _service.LoginAsync(request, cancellationToken);
            return Ok(counterAgent);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }
}