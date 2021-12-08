using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Application.Queries
{
    public record GetFeature(string FeatureId) : IQuery<GetFeature, FeatureDto>;
}