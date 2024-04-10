using AutoMapper;

namespace DomovoiBackend.Application.Mapping.Interfaces;

public interface IMapFrom<T> : IMapFrom
{
    public new void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());

    void IMapFrom.Mapping(Profile profile) =>
        Mapping(profile);
}

public interface IMapFrom
{
    void Mapping(Profile profile);
}