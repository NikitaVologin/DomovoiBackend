using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Mapping.Interfaces;

namespace DomovoiBackend.Application.Mapping.Tools;

/// <summary>
/// Сборщик представлений.
/// </summary>
public static class MapCollector
{
    /// <summary>
    /// Тип основы Маппера.
    /// </summary>
    private static readonly Type MapperType = typeof(IMapperBase);
    
    /// <summary>
    /// Информация об Map метода.
    /// </summary>
    private static readonly MethodInfo MapMethodInfo = MapperType
        .GetRuntimeMethod("Map", [typeof(object), typeof(Type), typeof(Type)])!;
    
    /// <summary>
    /// Получить маппинги до.
    /// </summary>
    /// <param name="assembly">Сборка.</param>
    /// <typeparam name="TDestination">Назначение</typeparam>
    /// <returns></returns>
    public static Dictionary<Type, Func<IMapperBase, object, TDestination>> GetToMappingsFromAssembly<TDestination>(Assembly assembly)
    {
        var mapToInterfaceDefinition = typeof(IMapTo<>);

        var types = assembly.GetTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == mapToInterfaceDefinition));
        
        var resultDictionary = new Dictionary<Type, Func<IMapperBase, object, TDestination>>();
        
        foreach (var type in types)
        {
            var destinationMapType = type.GetInterfaces()
                .First(i => i.GetGenericTypeDefinition() == mapToInterfaceDefinition)
                .GetGenericArguments()[0];
            
            var mapperParameterExpression = Expression.Parameter(MapperType);
            
            var sourceTypeExpression = Expression.Constant(type);
            var destinationTypeExpression = Expression.Constant(destinationMapType);
            
            var sourceObjectParameter = Expression.Parameter(typeof(object));
            
            var mapCallExpression = Expression.Call(mapperParameterExpression, MapMethodInfo,
                sourceObjectParameter, sourceTypeExpression, destinationTypeExpression);
            
            var mapResultCastedExpression = Expression.Convert(mapCallExpression, typeof(TDestination));
            
            var compiled = Expression.Lambda<Func<IMapperBase, object, TDestination>>(mapResultCastedExpression,
                mapperParameterExpression,
                sourceObjectParameter)
                .Compile();
            
            resultDictionary.Add(type, compiled);
        }

        return resultDictionary;
    }
    
    /// <summary>
    /// Получить мапинги после.
    /// </summary>
    /// <param name="assembly">Сборка.</param>
    /// <typeparam name="TSource">Источник.</typeparam>
    /// <returns></returns>
    public static Dictionary<Type, Func<IMapperBase, object, TSource>> GetFromMappingsFromAssembly<TSource>(Assembly assembly)
    {
        var mapToInterfaceDefinition = typeof(IMapFrom<>);

        var types = assembly.GetTypes()
            .Where(type => type.IsSubclassOf(typeof(TSource)) &&
                type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == mapToInterfaceDefinition));
        
        var resultDictionary = new Dictionary<Type, Func<IMapperBase, object, TSource>>();
        
        foreach (var type in types)
        {
            var sourceMapType = type.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapToInterfaceDefinition)
                .GetGenericArguments()[0];
            
            var mapperParameterExpression = Expression.Parameter(MapperType);
            
            var sourceTypeExpression = Expression.Constant(sourceMapType);
            var destinationTypeExpression = Expression.Constant(type);
            
            var sourceObjectParameter = Expression.Parameter(typeof(object));
            
            var mapCallExpression = Expression.Call(mapperParameterExpression, MapMethodInfo,
                sourceObjectParameter, sourceTypeExpression, destinationTypeExpression);
            
            var mapResultCastedExpression = Expression.Convert(mapCallExpression, type);
            
            var compiled = Expression.Lambda<Func<IMapperBase, object, TSource>>(mapResultCastedExpression,
                    mapperParameterExpression,
                    sourceObjectParameter)
                .Compile();
            
            resultDictionary.Add(sourceMapType, compiled);
        }

        return resultDictionary;
    }
}