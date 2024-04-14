using DomovoiBackend.API.Middlewares;
using DomovoiBackend.Application;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Information.Deals.Rents;
using DomovoiBackend.Application.Information.Deals.Sells;
using DomovoiBackend.Application.Information.Realities;
using DomovoiBackend.Application.Information.Realities.Commercial;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Persistence;
using JsonSubTypes;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "DomovoiBackend.API",
            Version = "v1"
        });
    options.UseAllOfToExtendReferenceSchemas();
    options.UseAllOfForInheritance();
    options.UseOneOfForPolymorphism();
});


// TODO: Сделать нормальную конфигурацию сериализации подтипов.
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(AddCounterAgentRequest), "counterAgentType")
                .RegisterSubtype<AddPhysicalCounterAgentRequest>("Physical")
                .RegisterSubtype<AddLegalCounterAgentRequest>("Legal")
                .SerializeDiscriminatorProperty()
                .Build());
        
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(CounterAgentInformation), "counterAgentType")
                .RegisterSubtype<PhysicalCounterAgentInformation>("Physical")
                .RegisterSubtype<LegalCounterAgentInformation>("Legal")
                .SerializeDiscriminatorProperty()
                .Build());
        
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(RealityInformation), "realityType")
                .RegisterSubtype<OfficeInformation>("Office")
                .SerializeDiscriminatorProperty()
                .Build());
        
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(DealInformation), "dealType")
                .RegisterSubtype<RentInformation>("Rent")
                .RegisterSubtype<SellInformation>("Sell")
                .SerializeDiscriminatorProperty()
                .Build());
    });

// TODO: Доделать ApplicationLayer и PersistenceLayer (RUD);
builder.Services.AddApplicationLayer()
    .AddMappers()
    .AddPersistence(builder.Configuration)
    .CreateDatabase();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors",
        policy  =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("cors");

// TODO: Сделать одно middleware для каждого вида запросов с подтипами.
app.UseMiddleware<AnnouncementRouteTransformerMiddleware>();
app.UseMiddleware<CounterAgentRouteTransformerMiddleware>();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
