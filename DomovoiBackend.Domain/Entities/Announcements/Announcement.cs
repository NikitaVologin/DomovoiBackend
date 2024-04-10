using System.ComponentModel.DataAnnotations;
using DomovoiBackend.Domain.Entities.Announcements.Deals;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Realities;

namespace DomovoiBackend.Domain.Entities.Announcements;

public class Announcement
{
    [Key]
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public string? ConnectionType { get; set; }
    public virtual Reality? Reality { get; set; }
    public virtual Deal? Deal { get; set; }
    public virtual CounterAgent? CounterAgent { get; set; }
}