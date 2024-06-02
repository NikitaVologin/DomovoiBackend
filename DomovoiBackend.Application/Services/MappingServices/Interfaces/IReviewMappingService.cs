using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Information.Reviews;
using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Entities.Deals;

namespace DomovoiBackend.Application.Services.MappingServices.Interfaces;

public interface IReviewMappingService
{
    /// <summary>
    /// Создать сделку. из информации.
    /// </summary>
    /// <param name="information">Информация о отзыве.</param>
    /// <returns>Отзыв.</returns>
    Review MapEntityFromInformation(ReviewInformation information);
    
    /// <summary>
    /// Создать информацию из отзыва.
    /// </summary>
    /// <param name="review">Отзыв.</param>
    /// <returns>Информация о отзыве.</returns>
    ReviewInformation MapInformationFromEntity(Review review);
}