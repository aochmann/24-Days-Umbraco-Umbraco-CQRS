using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features;
using CleanArchitecture.SharedAbstractions.Mappers;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Mappers
{
#pragma warning disable SA1649 // File name should match first type name

    internal interface IFeatureItemMapper : IMapper<FeatureDto, Feature>
    {
    }

    internal interface IFeatureItemsMapper : IMapper<IEnumerable<FeatureDto>, IEnumerable<Feature>>
    {
    }

    internal class FeatureMapper : IFeatureItemMapper, IFeatureItemsMapper
    {
        public Feature Map(FeatureDto model)
            => new(model.Name, model.Status);

        public IEnumerable<Feature> Map(IEnumerable<FeatureDto> items)
            => items
                .Select(Map)
                .ToList();
    }

#pragma warning restore SA1649 // File name should match first type name
}