using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Mapping.Interfaces;

namespace DomovoiBackend.Application.Mapping;

/// <summary>
/// Профиль сборки.
/// </summary>
public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingsFromAssembly(assembly);

    /// <summary>
    /// Создать отображения для сборки.
    /// </summary>
    /// <param name="assembly">Сборка.</param>
    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(IMapTwoSide<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type)!;
            (instance as IMapTwoSide)?.Mapping(this);
        }
    }
}