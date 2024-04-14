using AutoMapper;

namespace DomovoiBackend.Application.Mapping.Interfaces;

/// <summary>
/// Интерфейс двусвязанного маппинга..
/// </summary>
/// <typeparam name="T">Источник.</typeparam>
public interface IMapTwoSide<T> : IMapTwoSide
{
    /// <summary>
    /// Созадть Map.
    /// </summary>
    /// <param name="profile">Профиль автомапера.</param>
    public new void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
        profile.CreateMap(GetType(), typeof(T));
    }

    void IMapTwoSide.Mapping(Profile profile) =>
        Mapping(profile);
}

/// <summary>
/// Интерфейс двусвязанного маппинга.
/// </summary>
public interface IMapTwoSide
{
    /// <summary>
    /// Создать Map.
    /// </summary>
    /// <param name="profile">Профиль автомапера.</param>
    void Mapping(Profile profile);
}