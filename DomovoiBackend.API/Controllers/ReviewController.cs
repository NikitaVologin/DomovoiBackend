using DomovoiBackend.Application.Requests.Reviews;
using DomovoiBackend.Application.Services.ReviewServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DomovoiBackend.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewController(IReviewService service) => _service = service;
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> PostAsync(AddReviewRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var review = await _service.AddReviewAsync(request, cancellationToken);
            return Ok(review);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }
    
    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _service.RemoveReviewByIdAsync(id, cancellationToken);
            return Ok();
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var information = await _service.GetReviewByIdAsync(id, cancellationToken);
            return Ok(information);
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutAsync(Guid id, UpdateReviewRequest information, CancellationToken cancellationToken)
    {
        try
        {
            await _service.UpdateReviewByIdAsync(id, information, cancellationToken);
            return Ok();
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }
    
    
    [HttpGet("/OfUser/{id:guid}")]
    public async Task<IActionResult> GetByDestIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var information = await _service.GetReviewsByDestinationIdAsync(id, cancellationToken);
            return Ok(information);
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }
    
    [HttpGet("/ForUser/{id:guid}")]
    public async Task<IActionResult> GetByAuthorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var information = await _service.GetReviewsByAuthorIdAsync(id, cancellationToken);
            return Ok(information);
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }
}