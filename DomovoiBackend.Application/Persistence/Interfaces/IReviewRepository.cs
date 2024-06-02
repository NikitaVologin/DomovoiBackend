using DomovoiBackend.Domain.Entities.Common;

namespace DomovoiBackend.Application.Persistence.Interfaces;

public interface IReviewRepository
{
    /// <summary>
    /// Добавить отзыв.
    /// </summary>
    /// <param name="review">Отзыв.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция Review</returns>
    Task<Guid> AddReviewAsync(Review review, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить отзывы по ID-автора.
    /// </summary>
    /// <param name="id">ID-автора.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция Review</returns>
    Task<IList<Review>> GetReviewsByAuthorIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить отызывы поставленные пользователю.
    /// </summary>
    /// <param name="id">ID-пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция Review.</returns>
    Task<IList<Review>> GetReviewsByDestinationIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить отзыв по ID.
    /// </summary>
    /// <param name="id">ID отзыва.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Отзыв.</returns>
    Task<Review> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить отзыв.
    /// </summary>
    /// <param name="id">Id отзыва.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Таска.</returns>
    Task RemoveReviewByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить отьзыв.
    /// </summary>
    /// <param name="id">Id отзыва.</param>
    /// <param name="updatedReview">Обновлённый отзыв.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Таска.</returns>
    Task UpdateReviewByIdAsync(Guid id, Review updatedReview, CancellationToken cancellationToken);
}