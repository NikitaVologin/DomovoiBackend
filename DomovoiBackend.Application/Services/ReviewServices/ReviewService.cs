using DomovoiBackend.Application.Information.Reviews;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Requests.Reviews;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;
using DomovoiBackend.Application.Services.ReviewServices.Interfaces;
using DomovoiBackend.Domain.Entities.Common;

namespace DomovoiBackend.Application.Services.ReviewServices;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepositoryRepository;
    private readonly ICounterAgentRepository _counterAgentRepository;
    private readonly IReviewMappingService _mappingService;

    public ReviewService(IReviewRepository reviewRepositoryRepository,
        ICounterAgentRepository counterAgentRepository,
        IReviewMappingService mappingService)
    {
        _reviewRepositoryRepository = reviewRepositoryRepository;
        _counterAgentRepository = counterAgentRepository;
        _mappingService = mappingService;
    }
    
    public async Task<Guid> AddReviewAsync(AddReviewRequest review, CancellationToken cancellationToken)
    {
        var destination = await _counterAgentRepository.GetCounterAgentAsync(review.DestinationId, cancellationToken);
        var author = await _counterAgentRepository.GetCounterAgentAsync(review.AuthorId, cancellationToken);

        var reviewEntity = new Review
        {
            Rate = review.Rate,
            Author = author,
            DestinationId = destination.Id
        };

        var id = await _reviewRepositoryRepository.AddReviewAsync(reviewEntity, cancellationToken);

        return id;
    }

    public async Task<ReviewInformationCollection> GetReviewsByAuthorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepositoryRepository.GetReviewsByAuthorIdAsync(id, cancellationToken);
        
        var reviewsVm = reviews.Select(r => _mappingService.MapInformationFromEntity(r));

        return new ReviewInformationCollection { Reviews = reviewsVm.ToList() };
    }

    public async Task<ReviewInformationCollection> GetReviewsByDestinationIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepositoryRepository.GetReviewsByDestinationIdAsync(id, cancellationToken);
        
        var reviewsVm = reviews.Select(r => _mappingService.MapInformationFromEntity(r));

        return new ReviewInformationCollection { Reviews = reviewsVm.ToList() };
    }

    public async Task<ReviewInformation> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var review = await _reviewRepositoryRepository.GetReviewByIdAsync(id, cancellationToken);

        return _mappingService.MapInformationFromEntity(review);
    }

    public async Task RemoveReviewByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _reviewRepositoryRepository.RemoveReviewByIdAsync(id, cancellationToken);

    public async Task UpdateReviewByIdAsync(Guid id, UpdateReviewRequest updatedReview, CancellationToken cancellationToken)
    {
        var review = new Review()
        {
            Rate = updatedReview.Rate,
            Header = updatedReview.Header,
            Text = updatedReview.Text
        };
        await _reviewRepositoryRepository.UpdateReviewByIdAsync(id, review, cancellationToken);
    }
    
}