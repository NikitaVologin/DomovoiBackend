using System.Net;
using DomovoiBackend.API.Tests.Abstractions;

namespace DomovoiBackend.API.Tests.CounterAgent;

public class CounterAgentRemoveTests : BaseEndToEndTest
{
    public CounterAgentRemoveTests(EndToEndWebAppFactory factory) : base(factory) { }

    [Fact]
    public async Task Api_CounterAgentEndPoint_Delete()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");

        var response = await HttpClient.DeleteAsync($"CounterAgent/{id}");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_CounterAgentEndPoint_DeleteWithIncorrectId()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac255");

        var response = await HttpClient.DeleteAsync($"CounterAgent/{id}");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}