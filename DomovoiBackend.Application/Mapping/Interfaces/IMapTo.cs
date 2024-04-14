using AutoMapper;

namespace DomovoiBackend.Application.Mapping.Interfaces;

/// <summary>
/// Интерфейс мапинга до назначения.
/// </summary>
/// <typeparam name="T">Назначение.</typeparam>
public interface IMapTo<T> : IMapTo
{
    /// <summary>
    /// Создать Map.
    /// </summary>
    /// <param name="profile">Профиль Мапера.</param>
    public new void Mapping(Profile profile)
    {
        var destination = typeof(T);
        var source = GetType();
        profile.CreateMap(source, destination);
        var destinationBaseHierarchyType = destination.BaseType;
        while (destinationBaseHierarchyType != null && destinationBaseHierarchyType != typeof(object))
        {
            profile.CreateMap(source, destinationBaseHierarchyType);
            destinationBaseHierarchyType = destinationBaseHierarchyType.BaseType;
        }profile.CreateMap(GetType(), typeof(T));
    }

    void IMapTo.Mapping(Profile profile) =>
        Mapping(profile);
}

/// <summary>
/// Интерфейс мапинга до назначения.
/// </summary>
public interface IMapTo
{
    /// <summary>
    /// Создать Map.
    /// </summary>
    /// <param name="profile">Профиль Автомапера.</param>
    public void Mapping(Profile profile);
}