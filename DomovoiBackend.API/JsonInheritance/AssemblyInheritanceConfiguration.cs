using System.Reflection;
using DomovoiBackend.API.JsonInheritance.Abstraction;
using Newtonsoft.Json;

namespace DomovoiBackend.API.JsonInheritance;

public class AssemblyInheritanceConfiguration
{
    public IEnumerable<JsonConverter> CreateAllConfigurations()
    {
        var configurationTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.BaseType is { IsGenericType: true } &&
                           type.BaseType.GetGenericTypeDefinition() == typeof(JsonInheritanceConfiguration<>));

        return configurationTypes.Select(Activator.CreateInstance)
            .Cast<JsonInheritanceConfiguration>()
            .Select(c => c.Create());
    }
}