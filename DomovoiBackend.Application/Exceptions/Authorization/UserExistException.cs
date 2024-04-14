namespace DomovoiBackend.Application.Exceptions.Authorization;

/// <summary>
/// Исключение при существовании пользователя.
/// </summary>
public class UserExistException : Exception
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="email">Существующая почта.</param>
    public UserExistException(string email) : base($"User with {email} email is exist") { }
}