namespace DomovoiBackend.Application.Information.Announcements;

/// <summary>
/// Коллекция информаций о объявлениях.
/// </summary>
public class AnnouncementInformationCollection
{
    /// <summary>
    /// Информации.
    /// </summary>
    public List<AnnouncementInformation> AnnouncementInformation { get; set; } = new();
}