using System.Reflection;

namespace DomovoiBackend.Application.Persistence.Exceptions;

/// <summary>
/// Исключение не найденной записи.
/// </summary>
public class DbNotFoundException : Exception
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="type">Тип записи.</param>
    /// <param name="indexValue">Значение ключа.</param>
    public DbNotFoundException(MemberInfo type, object indexValue) : base($"{type.Name} with {indexValue} not found!") { }
}