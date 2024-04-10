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
    public async Task<Guid> Post(string counterAgentType,
        [FromBody] AddCounterAgentRequest request,
        CancellationToken cancellationToken)
    {
        return await _service.AddAsync(request, cancellationToken);
    }
}