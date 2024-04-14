using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Extensions;

/// <summary>
/// Расширения IQueryable
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Типы из сборки.
    /// </summary>
    private static IEnumerable<Type> _assemblyTypes = Array.Empty<Type>();
    
    /// <summary>
    /// Включить все вложенные сущности включая наследуемые.
    /// </summary>
    /// <param name="queryable">Коллеция.</param>
    /// <param name="context">Контекст БД.</param>
    /// <typeparam name="T">Тип коллекции.</typeparam>
    /// <returns>Подгруженная коллекция.</returns>
    public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, DbContext context) where T : class
    {
        var queryableType = typeof(T);
        var queryableTypeAssembly = Assembly.GetAssembly(queryableType);
        if (queryableTypeAssembly == null) return queryable;
        _assemblyTypes = queryableTypeAssembly.GetTypes();
        var paths = GetNavigationPaths(context, typeof(T)).Distinct();
        return paths.Aggregate(queryable, (current, path) => current.Include(path.TrimEnd('.')));
    }

    /// <summary>
    /// Получить все возможные навигационные пути.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    /// <param name="type">Тип, для которого ищется навигационные свойства.</param>
    /// <param name="navigationPath">Навигационный путь.</param>
    /// <returns>Дополненный навигационный путь.</returns>
    private static IEnumerable<string> GetNavigationPaths(DbContext context, Type type, string navigationPath = "")
    {
        var assembly = Assembly.GetAssembly(type);
        if(assembly == null) yield break;
        var derivedTypes = _assemblyTypes.Where(t => t.IsSubclassOf(type) || t == type);
        foreach (var derivedType in derivedTypes)
        {
            var entityType = context.Model.FindEntityType(derivedType);
            if (entityType == null) continue;
            var navigations = entityType.GetNavigations().ToArray();

            if (navigations.Length == 0) yield return navigationPath;
            
            foreach (var navigation in navigations)
            {
                var newNavigation = navigationPath + navigation.Name + ".";
                var newNavigations = GetNavigationPaths(context, navigation.ClrType, newNavigation);
                foreach (var navigationNested in newNavigations)
                    yield return navigationNested;
            }
        }
    }
}