using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.Queries;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Repositories;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Mappers;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Queries.Handlers
{
    internal class GetFeatureHandler : IQueryHandler<GetFeature, FeatureDto>
    {
        private readonly IUmbracoFeatureRepository _featureRepository;
        private readonly IFeatureItemDtoMapper _featureDtoMapper;

        public GetFeatureHandler(IUmbracoFeatureRepository featureRepository, IFeatureItemDtoMapper featureDtoMapper)
        {
            _featureRepository = featureRepository;
            _featureDtoMapper = featureDtoMapper;
        }

        public async Task<FeatureDto> Handle(GetFeature query, CancellationToken cancellationToken)
        {
            var feature = await _featureRepository.GetAsync(query.FeatureId.ToFeatureId());

            return feature is not null
                ? _featureDtoMapper.Map(feature)
                : null;
        }
    }
}