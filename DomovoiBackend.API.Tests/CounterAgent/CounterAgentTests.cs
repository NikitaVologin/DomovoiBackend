using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Tests.Abstractions;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;

namespace DomovoiBackend.API.Tests.CounterAgent;

public class CounterAgentTests : BaseEndToEndTest
{
    public CounterAgentTests(EndToEndWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Api_CorrectCounterAgentAdd()
    {
        var request = new AddPhysicalCounterAgentRequest()
        {
            Email = "123@mail.ru",
            Password = "12321"
        };

        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_ExistedCounterAgentAdd()
    {
        var request = new AddPhysicalCounterAgentRequest
        {
            Email = "123@mail.ru",
            Password = "12321"
        };

        await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request); 
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request);

        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_LoginCounterAgent()
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
}