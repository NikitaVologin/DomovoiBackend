using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.Tests.Abstractions;

namespace DomovoiBackend.API.Tests.CounterAgent;

public class CounterAgentUpdateTests : BaseEndToEndTest
{
    public CounterAgentUpdateTests(EndToEndWebAppFactory factory) : base(factory) { }

    [Fact]
    public async void Api_CounterAgentEndPoint_Update()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");

        var updateRequest = new
        {
            Email = "123@mail.ru",
            Password = "123456",
            Tin = "1222",
            ContactNumber = "+7 (228) 228 22-88",
            Type = CounterAgentStringLiteral.Legal
        };

        var response = await HttpClient.PutAsJsonAsync($"CounterAgent/{id}", updateRequest);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void Api_CounterAgentEndPoint_UpdateWithIncorrectId()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac424");

        var updateRequest = new
        {
            Email = "123@mail.ru",
            Password = "123456",
            Tin = "1222",
            ContactNumber = "+7 (228) 228 22-88",
            Type = CounterAgentStringLiteral.Legal
        };

        var response = await HttpClient.PutAsJsonAsync($"CounterAgent/{id}", updateRequest);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}