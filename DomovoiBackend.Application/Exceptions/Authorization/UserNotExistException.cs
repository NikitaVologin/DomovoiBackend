namespace DomovoiBackend.Application.Exceptions.Authorization;

/// <summary>
/// Исключение при не существовании пользователя.
/// </summary>
public class UserNotExistException : Exception
{
    
    /// <summary>
    /// Констуктор
    /// </summary>
    /// <param name="email">Не найденная почта.</param>
    public UserNotExistException(string email) : base($"User with {email} email is not exist") { }

}