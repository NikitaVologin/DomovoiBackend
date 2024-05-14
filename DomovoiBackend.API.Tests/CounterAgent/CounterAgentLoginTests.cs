using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Tests.Abstractions;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;

namespace DomovoiBackend.API.Tests.CounterAgent;

public class CounterAgentLoginTests : BaseEndToEndTest
{
    public CounterAgentLoginTests(EndToEndWebAppFactory factory) : base(factory)
    {
    }
    
    
    [Fact]
    public async Task Api_LoginCounterAgentTest()
    {
        var request = new AddPhysicalCounterAgentRequest
        {
            Email = "123@mail.ru",
            Password = "12321"
        };

        await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request);

        var loginRequest = new AuthorizationRequest
        {
            Email = "123@mail.ru",
            Password = "12321"
        };
        
        HttpResponseMessage response =  await HttpClient.PostAsJsonAsync("CounterAgent/Login", loginRequest);

        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_LoginCounterAgentWithIncorrectPasswordTest()
    {
        var request = new AddPhysicalCounterAgentRequest
        {
            Email = "123@mail.ru",
            Password = "12321"
        };

        await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request);

        var loginRequest = new AuthorizationRequest
        {
            Email = "123@mail.ru",
            Password = "123215"
        };
        
        HttpResponseMessage response =  await HttpClient.PostAsJsonAsync("CounterAgent/Login", loginRequest);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_LoginCounterAgentWithNotExistTest()
    {
        var loginRequest = new AuthorizationRequest
        {
            Email = "123@mail.ru",
            Password = "123215"
        };
        
        HttpResponseMessage response =  await HttpClient.PostAsJsonAsync("CounterAgent/Login", loginRequest);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}