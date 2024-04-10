using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DomovoiBackend.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CounterAgentController : ControllerBase
{
    private readonly ICounterAgentService _service;

    public CounterAgentController(ICounterAgentService service) => _service = service;
    
    [HttpPost("{counterAgentType}")]
    public async Task<IActionResult> Post([FromRoute] string counterAgentType,
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

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AuthorizationRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var counterAgent = await _service.GetCounterAgentInfoByAuthorizationData(request, cancellationToken);
            return Ok(counterAgent);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }
}