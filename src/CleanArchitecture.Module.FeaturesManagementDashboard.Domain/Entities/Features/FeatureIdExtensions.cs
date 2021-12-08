namespace CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features
{
    public static class FeatureIdExtensions
    {
        public static FeatureId ToFeatureId(this string featureId)
            => new(featureId);
    }
}