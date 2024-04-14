using AutoMapper;

namespace DomovoiBackend.Application.Mapping.Interfaces;

/// <summary>
/// Интерфейс мапинга от источника.
/// </summary>
/// <typeparam name="T">Источник.</typeparam>
public interface IMapFrom<T> : IMapFrom
{
    /// <summary>
    /// Созадть Map.
    /// </summary>
    /// <param name="profile">Профиль автомапера.</param>
    public new void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());

    void IMapFrom.Mapping(Profile profile) =>
        Mapping(profile);
}

/// <summary>
/// Интерфейс мапинга от источника.
/// </summary>
public interface IMapFrom
{
    /// <summary>
    /// Создать Map.
    /// </summary>
    /// <param name="profile">Профиль автомапера.</param>
    void Mapping(Profile profile);
}