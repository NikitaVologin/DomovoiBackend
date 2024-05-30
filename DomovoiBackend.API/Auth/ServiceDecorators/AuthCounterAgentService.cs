using System.Security.Claims;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DomovoiBackend.API.Auth.ServiceDecorators;

public class AuthCounterAgentService : ICounterAgentService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICounterAgentService _service;

    public AuthCounterAgentService(IHttpContextAccessor httpContextAccessor, ICounterAgentService service) =>
        (_httpContextAccessor, _service) = (httpContextAccessor, service);

    private async Task SetAuthenticatedCounterAgentId(Guid counterAgentId)
    {
        var response = _httpContextAccessor.HttpContext!.Response;
        response.Cookies.Append("CounterAgentId", counterAgentId.ToString(), new CookieOptions()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        });

        var user = _httpContextAccessor.HttpContext.User;
        var identity = new ClaimsIdentity(new[]
        {
            new Claim("CounterAgentId", counterAgentId.ToString(), "Cookies"),
            new Claim(ClaimTypes.Authentication, "true")
        }, CookieAuthenticationDefaults.AuthenticationScheme);
        user.AddIdentity(identity);
        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));
    }
    
    public async Task<CounterAgentInformation> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken)
    {
        var information = await _service.AddAsync(request, cancellationToken);
        await SetAuthenticatedCounterAgentId(information.Id);
        return information;
    }

    public async Task<CounterAgentInformation> LoginAsync(AuthorizationRequest request, CancellationToken cancellationToken)
    {
        var information = await _service.LoginAsync(request, cancellationToken);
        await SetAuthenticatedCounterAgentId(information.Id);
        return information;
    }

    public async Task UpdateAsync(Guid id, CounterAgentUpdateRequest information,
        CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext ?? throw new NullReferenceException();
        
        if(!context.Request.Cookies.TryGetValue("CounterAgentId",
               out var cookieCounterAgentId) ||
           Guid.Parse(cookieCounterAgentId) != id) throw new ArgumentException("ID пользователя не равен ID в COOKIE");
        
        await _service.UpdateAsync(id, information, cancellationToken);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext ?? throw new NullReferenceException();
        
        if(!context.Request.Cookies.TryGetValue("CounterAgentId",
               out var cookieCounterAgentId) ||
           Guid.Parse(cookieCounterAgentId) != id) throw new ArgumentException("ID пользователя не равен ID в COOKIE");
        
        await _service.RemoveAsync(id, cancellationToken);
    }

    public async Task<CounterAgentInformation> GetCounterAgentInfoAsync(Guid id, CancellationToken cancellationToken) =>
        await _service.GetCounterAgentInfoAsync(id, cancellationToken);
}