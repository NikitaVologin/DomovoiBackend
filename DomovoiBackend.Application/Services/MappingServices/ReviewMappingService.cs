using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Information.Reviews;
using DomovoiBackend.Application.Mapping.Tools;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;
using DomovoiBackend.Domain.Entities.Common;

namespace DomovoiBackend.Application.Services.MappingServices;

public class ReviewMappingService : IReviewMappingService
{
    private readonly IMapper _mapper;

    private readonly ICounterAgentMappingService _counterAgentMapping;
    
    public ReviewMappingService(IMapper mapper, ICounterAgentMappingService counterAgentMapping) =>
        (_mapper, _counterAgentMapping) = (mapper, counterAgentMapping);

    public Review MapEntityFromInformation(ReviewInformation information)
    {
        var author = _counterAgentMapping.MapEntityFromInformation(information.Author);
        var informationWithoutAuthor = _mapper.Map<ReviewInformationWithoutAuthor>(information);
        var review = _mapper.Map<Review>(informationWithoutAuthor);
        review.Author = author;
        return review;
    }

    public ReviewInformation MapInformationFromEntity(Review review)
    {
        var author = _counterAgentMapping.MapInformationFromEntity(review.Author);
        var informationWithoutAuthor = _mapper.Map<ReviewInformationWithoutAuthor>(review);
        var information = _mapper.Map<ReviewInformation>(informationWithoutAuthor);
        information.Author = author;
        return information;
    }
}