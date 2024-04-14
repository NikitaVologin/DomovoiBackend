using DomovoiBackend.Domain.Entities.Deals;

namespace DomovoiBackend.Application.Persistence.Interfaces;

public interface IDealRepository
{
    Task<Deal> GetDealAsync(Guid id, CancellationToken cancellationToken);
    Task AddDealAsync(Deal deal, CancellationToken cancellationToken);
}