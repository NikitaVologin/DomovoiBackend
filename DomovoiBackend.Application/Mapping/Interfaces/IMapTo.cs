using AutoMapper;

namespace DomovoiBackend.Application.Mapping.Interfaces;

public interface IMapTo<T> : IMapTo
{
    public new void Mapping(Profile profile) =>
        profile.CreateMap(GetType(), typeof(T));

    void IMapTo.Mapping(Profile profile) =>
        Mapping(profile);
}

public interface IMapTo
{
    public void Mapping(Profile profile);
}