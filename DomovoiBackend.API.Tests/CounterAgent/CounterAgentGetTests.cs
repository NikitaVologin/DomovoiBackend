using System.Net;
using DomovoiBackend.API.Tests.Abstractions;

namespace DomovoiBackend.API.Tests.CounterAgent;

public class CounterAgentGetTests : BaseEndToEndTest
{
    public CounterAgentGetTests(EndToEndWebAppFactory factory) : base(factory) { }

    [Fact]
    public async Task Api_CounterAgentEndPoint_GetById()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");

        var response = await HttpClient.GetAsync($"CounterAgent/{id}");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_CounterAgentEndPoint_GetByIncorrectId()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac255");

        var response = await HttpClient.GetAsync($"CounterAgent/{id}");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}