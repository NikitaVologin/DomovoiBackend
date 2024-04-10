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
                          (i.GetGenericTypeDefinition() == typeof(IMapTo<>) ||
                           i.GetGenericTypeDefinition() == typeof(IMapFrom<>))))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type)!;
            (instance as IMapTo)?.Mapping(this);
            (instance as IMapFrom)?.Mapping(this);
        }
    }
}