using System.Reflection;

namespace DomovoiBackend.Application.Persistence.Exceptions;

public class DbNotFoundException : Exception
{
    public DbNotFoundException(MemberInfo type, object indexValue) : base($"{type.Name} with {indexValue} not found!") { }
}