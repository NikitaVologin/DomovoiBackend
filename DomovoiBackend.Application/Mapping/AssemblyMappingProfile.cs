using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Mapping.Interfaces;

namespace DomovoiBackend.Application.Mapping;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingsFromAssembly(assembly);

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = (IMapTo)Activator.CreateInstance(type)!;
            instance.Mapping(this);
        }
    }
}