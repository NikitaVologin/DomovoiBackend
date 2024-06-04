using DomovoiBackend.Domain.Entities.ChatEntities;
using DomovoiBackend.Domain.Entities.CounterAgents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.ChatConfigurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable(nameof(Message));
            builder.HasIndex(a => a.Id).IsUnique();
            builder.HasKey(a => a.Id);
            builder.HasOne<CounterAgent>()
                .WithMany()
                .HasForeignKey(d => d.IdReceiver);

            builder.HasOne<CounterAgent>()
                .WithMany()
                .HasForeignKey(r => r.IdSender);
        }
    }
}