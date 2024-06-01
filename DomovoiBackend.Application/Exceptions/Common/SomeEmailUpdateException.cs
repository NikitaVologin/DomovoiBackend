namespace DomovoiBackend.Application.Exceptions.Common;

public class SomeEmailUpdateException : Exception
{
    public SomeEmailUpdateException(string email) : base($"Email {email} is unavaiable") { } 
}