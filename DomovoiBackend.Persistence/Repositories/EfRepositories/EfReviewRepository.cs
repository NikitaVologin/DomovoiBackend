using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Persistence.EfSettings;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Repositories.EfRepositories;

public class EfReviewRepository : IReviewRepository
{
    private readonly DomovoiContext _context;

    public EfReviewRepository(DomovoiContext context) => _context = context;

    public async Task<Guid> AddReviewAsync(Review review, CancellationToken cancellationToken)
    {
        review.ReviewDate = DateTime.UtcNow;
        await _context.Reviews.AddAsync(review, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return review.Id;
    }

    public async Task<IList<Review>> GetReviewsByAuthorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var reviews = await _context.Reviews
            .Include(r => r.Author)
            .Where(r => r.Author.Id == id)
            .ToListAsync(cancellationToken);
        return reviews;
    }

    public async Task<IList<Review>> GetReviewsByDestinationIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var reviews = await _context.Reviews
            .Include(r => r.Author)
            .Where(r => r.DestinationId == id)
            .ToListAsync(cancellationToken);
        return reviews;
    }

    public async Task<Review> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews
            .Include(r => r.Author)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        if (review == default) throw new DbNotFoundException(typeof(Review), id);

        return review;
    }

    public async Task RemoveReviewByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var review = await GetReviewByIdAsync(id, cancellationToken);
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateReviewByIdAsync(Guid id, Review updatedReview, CancellationToken cancellationToken)
    {
        var review = await GetReviewByIdAsync(id, cancellationToken);
        review.Update(updatedReview);
        await _context.SaveChangesAsync(cancellationToken);
    }
}