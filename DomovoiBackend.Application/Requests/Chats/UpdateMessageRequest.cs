namespace DomovoiBackend.Application.Requests.Chats
{
    public class UpdateMessageRequest
    {
        public Guid Id { get; set; }    
        public string Text { get; set; }
    }
}
