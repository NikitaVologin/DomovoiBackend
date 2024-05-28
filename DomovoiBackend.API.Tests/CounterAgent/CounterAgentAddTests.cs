using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.Tests.Abstractions;

namespace DomovoiBackend.API.Tests.CounterAgent;

public class CounterAgentAddTests : BaseEndToEndTest
{
    public CounterAgentAddTests(EndToEndWebAppFactory factory) : base(factory) { }

    [Fact]
    public async Task Api_CounterAgentEndPoint_CorrectCounterAgentAddTest()
    {
        var request = new
        {
            Email = "1234321356@mail.ru",
            Password = "12321",
            Type = CounterAgentStringLiteral.Legal
        };

        var response = await HttpClient.PostAsJsonAsync("CounterAgent", request);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_CounterAgentEndpoint_ExistedCounterAgentAddTest()
    {
        var request = new
        {
            Email = "123@mail.ru",
            Password = "12321",
            Type = CounterAgentStringLiteral.Legal
        };

        await HttpClient.PostAsJsonAsync("CounterAgent", request); 
        var response = await HttpClient.PostAsJsonAsync("CounterAgent", request);

        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}