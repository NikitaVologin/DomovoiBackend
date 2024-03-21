using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Factories.AnnouncementFactory.Infos;

namespace DomovoiBackend.Domain.Factories.AnnouncementFactory.Interfaces;

public interface IAnnouncementFactory
{
    Announcement Generate(AnnouncementInfo info);
}