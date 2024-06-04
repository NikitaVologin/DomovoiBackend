namespace DomovoiBackend.API.Exceptions
{
    public class UnknownUser : Exception
    {
        public UnknownUser(string message) : base(message) { }
    }
}
