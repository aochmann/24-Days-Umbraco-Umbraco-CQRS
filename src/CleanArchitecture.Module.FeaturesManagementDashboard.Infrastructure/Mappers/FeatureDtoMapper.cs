using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features;
using CleanArchitecture.SharedAbstractions.Mappers;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Mappers
{
#pragma warning disable SA1649 // File name should match first type name

    internal interface IFeatureItemDtoMapper : IMapper<Feature, FeatureDto>
    {
    }

    internal interface IFeatureItemsDtoMapper : IMapper<IEnumerable<Feature>, IEnumerable<FeatureDto>>
    {
    }

    internal class FeatureDtoMapper : IFeatureItemDtoMapper, IFeatureItemsDtoMapper
    {
        public FeatureDto Map(Feature model)
            => new()
            {
                Id = model.Id.Id,
                Name = model.Name,
                Status = model.Status
            };

        public IEnumerable<FeatureDto> Map(IEnumerable<Feature> items)
            => items
                .Select(Map)
                .ToList();
    }

#pragma warning restore SA1649 // File name should match first type name
}