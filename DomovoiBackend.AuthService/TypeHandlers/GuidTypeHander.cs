using System.Data;
using Dapper;

namespace DomovoiBackend.AuthService.TypeHandlers;

public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override Guid Parse(object value)
    {
        return new Guid((string) value);
    }

    public override void SetValue(IDbDataParameter parameter, Guid value)
    {
        parameter.Value = value.ToString();
    }
}
