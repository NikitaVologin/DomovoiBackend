using JsonSubTypes;
using Newtonsoft.Json;

namespace DomovoiBackend.API.JsonInheritance.Abstraction;

public abstract class JsonInheritanceConfiguration<TBaseClass> : JsonInheritanceConfiguration
{
    protected abstract Dictionary<Type, string> Subtypes { get; set; }

    public override JsonConverter Create()
    {
        var builder = JsonSubtypesConverterBuilder
            .Of(typeof(TBaseClass), "type");

        foreach (var subtypePair in Subtypes)
            builder.RegisterSubtype(subtypePair.Key, subtypePair.Value);

        builder.SerializeDiscriminatorProperty();

        return builder.Build();
    }
}

public abstract class JsonInheritanceConfiguration
{
    public abstract JsonConverter Create();
}