namespace DomovoiBackend.Application.Requests.Chats
{
    public class AddMessageRequest
    {
        /// <summary>
        /// Id получателя.
        /// </summary>
        public Guid IdReceiver { get; set; }

        /// <summary>
        /// Id отправителя.
        /// </summary>
        public Guid IdSender { get; set; }

        /// <summary>
        /// Содержание сообщения.
        /// </summary>
        public string Text { get; set; }
    }
}
