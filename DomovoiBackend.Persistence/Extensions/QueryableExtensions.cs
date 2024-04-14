using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Extensions;

public static class QueryableExtensions
{
    private static IEnumerable<Type> _assemblyTypes = Array.Empty<Type>();
    
    public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, DbContext context) where T : class
    {
        var queryableType = typeof(T);
        var queryableTypeAssembly = Assembly.GetAssembly(queryableType);
        if (queryableTypeAssembly == null) return queryable;
        _assemblyTypes = queryableTypeAssembly.GetTypes();
        var paths = GetNavigationPaths(context, typeof(T)).Distinct();
        return paths.Aggregate(queryable, (current, path) => current.Include(path.TrimEnd('.')));
    }

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