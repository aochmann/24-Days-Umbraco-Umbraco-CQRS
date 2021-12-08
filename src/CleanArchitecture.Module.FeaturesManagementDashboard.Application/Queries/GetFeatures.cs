using System.Collections.Generic;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Application.Queries
{
    public record GetFeatures : IQuery<GetFeatures, IEnumerable<FeatureDto>>;
}