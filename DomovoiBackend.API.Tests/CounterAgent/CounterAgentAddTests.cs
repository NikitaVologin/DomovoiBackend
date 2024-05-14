using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Tests.Abstractions;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests;

namespace DomovoiBackend.API.Tests.CounterAgent;

public class CounterAgentAddTests : BaseEndToEndTest
{
    public CounterAgentAddTests(EndToEndWebAppFactory factory) : base(factory) { }

    [Fact]
    public async Task Api_CorrectCounterAgentAddTest()
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
    public async Task Api_ExistedCounterAgentAddTest()
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
}