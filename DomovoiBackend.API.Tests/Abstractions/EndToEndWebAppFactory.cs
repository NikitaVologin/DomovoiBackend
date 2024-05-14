using DomovoiBackend.Persistence;
using DomovoiBackend.Persistence.EfSettings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;

namespace DomovoiBackend.API.Tests.Abstractions;

public class EndToEndWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("domovoi-main")
        .WithUsername("postgres")
        .WithPassword("123")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DomovoiContext));
            services.AddDbContext<DomovoiContext>(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
            services.CreateDatabase();
        });
    }



    public Task InitializeAsync()
    {
        return _dbContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _dbContainer.StartAsync();
    }
}