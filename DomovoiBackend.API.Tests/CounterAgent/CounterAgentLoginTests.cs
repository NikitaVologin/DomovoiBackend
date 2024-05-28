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
    public async Task Api_CounterAgentEndPoint_LoginCounterAgentTest()
    {
        var loginRequest = new AuthorizationRequest
        {
            Email = "123@mail.ru",
            Password = "123456"
        };
        
        var response =  await HttpClient.PostAsJsonAsync("CounterAgent/Login", loginRequest);

        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_CounterAgentEndPoint_LoginCounterAgentWithIncorrectPasswordTest()
    {
        var loginRequest = new AuthorizationRequest
        {
            Email = "123@mail.ru",
            Password = "123215"
        };
        
        var response =  await HttpClient.PostAsJsonAsync("CounterAgent/Login", loginRequest);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_CounterAgentEndPoint_LoginCounterAgentWithNotExistTest()
    {
        var loginRequest = new AuthorizationRequest
        {
            Email = "11321321323@mail.ru",
            Password = "123215"
        };
        
        var response =  await HttpClient.PostAsJsonAsync("CounterAgent/Login", loginRequest);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}