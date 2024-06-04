using DomovoiBackend.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.ChatEntities
{
    public class Message : UpdatableEntity<Message>
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Id получателя.
        /// </summary>
        public Guid IdReceiver { get; set; }

        /// <summary>
        /// Id отправителя.
        /// </summary>
        public Guid IdSender { get; set; }

        /// <summary>
        /// Содержание сообщения
        /// </summary>
        public string Text { get; set; } = "";
    
        /// <summary>
        /// Статус сообщения.
        /// </summary>
        public MessageStatus Status { get; set; } = MessageStatus.NotSend;

        public override void Update(Message entity)
        {
            Text = entity.Text;
        }
    }
}