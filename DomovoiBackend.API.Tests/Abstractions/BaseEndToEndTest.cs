namespace DomovoiBackend.API.Tests.Abstractions;

public class BaseEndToEndTest : IClassFixture<EndToEndWebAppFactory>
{
    protected HttpClient HttpClient { get; init; }

    protected BaseEndToEndTest(EndToEndWebAppFactory factory)
    {
        HttpClient = factory.CreateClient();
    }
}